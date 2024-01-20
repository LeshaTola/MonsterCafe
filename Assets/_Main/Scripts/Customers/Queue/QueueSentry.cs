using UnityEditor.PackageManager;
using UnityEngine;

public class QueueSentry : MonoBehaviour
{
    [SerializeField] private CustomerObjectPool ObjectPool;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float queueTimer;
    private Timer timer;

    public Transform TargetPoint { get { return targetPoint; } }
    
    private void Start()
    {
        Begin();
    }

    public void Begin()
    {
        ObjectPool.Clients.Get();
        timer = new Timer(Random.Range(1, queueTimer), endAction: Begin);
        StartCoroutine(timer.Start());
    }

    public void Complite(Customer customer)
    {
        ObjectPool.Clients.Release(customer);
    }
}
