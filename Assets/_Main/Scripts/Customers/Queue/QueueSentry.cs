using System.Collections.Generic;
using UnityEngine;

public class QueueSentry : MonoBehaviour
{
    [SerializeField] private CustomerObjectPool ObjectPool;
    [SerializeField] private float queueTimer;
    private List<KeyValuePair<bool, Transform>> targetPoints = new();
    private Timer timer;

    public List<KeyValuePair<bool, Transform>> TargetPoints { get { return targetPoints; } }

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<Customer>(out var _))
            {
                continue;
            }
            targetPoints.Add(KeyValuePair.Create(true, child));
        }
    }

    private void Start()
    {
        BeginQueue();
    }

    public void BeginQueue()
    {
        var targetPointIndex = targetPoints.FindIndex(kvp => kvp.Key == true);
        if (targetPointIndex < 0)
        {
            return;
        }
        KeyValuePair<bool, Transform> newKvp = new KeyValuePair<bool, Transform>(false, targetPoints[targetPointIndex].Value);
        targetPoints[targetPointIndex] = newKvp;
        StartTimer();
        ObjectPool.Clients.Get().GoGetOrder(newKvp);
    }

    private void StartTimer()
    {
        timer = new Timer(UnityEngine.Random.Range(1, queueTimer), endAction: BeginQueue);
        StartCoroutine(timer.Start());
    }
    public void ReturnFreePoint(KeyValuePair<bool, Transform> item)
    {
        var targetPointIndex = targetPoints.FindIndex(kvp => kvp.Key == false);
        item = new KeyValuePair<bool, Transform>(true, targetPoints[targetPointIndex].Value);
        targetPoints[targetPointIndex] = item;
    }

    public void Complite(Customer customer)
    {
        ObjectPool.Clients.Release(customer);
        BeginQueue();
    }
}