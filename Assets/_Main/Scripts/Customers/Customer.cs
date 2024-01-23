using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private CustomerSO config;
    [SerializeField] private CustomerMove move;

    private bool isClicable;

    private QueueSentry queue;
    private Timer timer;
    private KeyValuePair<bool,Transform> targetPoint;

    private void Start()
    {
        transform.parent.TryGetComponent<QueueSentry>(out queue);
    }

    private void OnMouseDown()
    {
        if(!isClicable) { return; }

        StopCoroutine(timer.Start());

        OnOrderComplite();
    }

    public void MoveToOrder(KeyValuePair<bool,Transform> targetPoint)
    {
        this.targetPoint = targetPoint;
        move.MoveToPoint(WaitForOrder, targetPoint.Value);
    }

    private void WaitForOrder()
    {
        isClicable = true;
        timer = new Timer(config.WaitDuration,endAction:OnOrderComplite);

        StartCoroutine(timer.Start());
    }

    private void OnOrderComplite()
    {
        queue.UnlockTargetPoint(targetPoint);
        isClicable = false;
        move.MoveToPoint(queue.OnQueueComplite, this, transform.parent);
    }
}
