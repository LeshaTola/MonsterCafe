using System;
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

    public event Action OnOrderWaiting;
    public event Action OnOrderCompleted;

    public ToolTipUI ToolTipUI { get; private set; }

    private void Start()
    {
        transform.parent.TryGetComponent(out queue);
        ToolTipUI = queue.ToolTipUI;
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
        move.MoveToPoint(OnStartOrderWaiting, targetPoint.Value);
    }

    private void OnStartOrderWaiting()
    {
        OnOrderWaiting?.Invoke();
        isClicable = true;
        timer = new Timer(config.WaitDuration,endAction:OnOrderComplite);

        StartCoroutine(timer.Start());
    }

    private void OnOrderComplite()
    {
        OnOrderCompleted?.Invoke();
        queue.UnlockTargetPoint(targetPoint);
        isClicable = false;
        move.MoveToPoint(queue.OnQueueComplite, this, transform.parent);
    }
}
