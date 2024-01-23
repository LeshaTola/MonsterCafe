using System.Collections.Generic;
using UnityEngine;

public class QueueSentry : MonoBehaviour
{
    [SerializeField] private CustomerPool ObjectPool;
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
        StartQueueTimer();
    }

    public void StartQueue()
    {
        var targetPointIndex = targetPoints.FindIndex(kvp => kvp.Key == true);

        if (targetPointIndex < 0)
        {
            return;
        }

        KeyValuePair<bool, Transform> newKvp = new KeyValuePair<bool, Transform>(false, targetPoints[targetPointIndex].Value);
        targetPoints[targetPointIndex] = newKvp;

        StartQueueTimer();
        ObjectPool.CreateEnemie().MoveToOrder(newKvp);
    }

    public void UnlockTargetPoint(KeyValuePair<bool, Transform> item)
    {
        var targetPointIndex = targetPoints.FindIndex(kvp => kvp.Value == item.Value);
        item = new KeyValuePair<bool, Transform>(true, targetPoints[targetPointIndex].Value);
        targetPoints[targetPointIndex] = item;
    }

    public void OnQueueComplite(Customer customer)
    {
        ObjectPool.Deactivate(customer);
        StartQueue();
    }

    private void StartQueueTimer()
    {
        timer = new Timer(UnityEngine.Random.Range(1, queueTimer), endAction: StartQueue);

        StartCoroutine(timer.Start());
    }

}