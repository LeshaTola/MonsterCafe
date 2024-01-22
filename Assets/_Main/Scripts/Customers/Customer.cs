using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private CustomerSO config;
    private QueueSentry queue;
    private Tweener tween;
    private Timer timer;
    private bool isClicable;
    private KeyValuePair<bool,Transform> point;

    private void Start()
    {
        transform.parent.TryGetComponent<QueueSentry>(out var queueSentry);
        queue = queueSentry;
    }

    private void OnMouseDown()
    {
        if(!isClicable) { return; }
        StopCoroutine(timer.Start());
        OrderComplite();
    }

    public void GoGetOrder(KeyValuePair<bool,Transform> item)
    {
        point = item;
        MoveToTheTarget(WaitForOrder, item.Value);
    }

    private void WaitForOrder()
    {
        isClicable = true;
        timer = new Timer(config.WaitDuration,endAction:OrderComplite);
        StartCoroutine(timer.Start());
    }

    private void OrderComplite()
    {
        queue.ReturnFreePoint(point);
        isClicable = false;
        MoveToTheTarget(queue.Complite, this, transform.parent);
    }

    private void MoveToTheTarget(Action func,Transform point)
    {
        tween = transform.DOMove(point.position, config.MoveDuration);
        tween.SetEase(Ease.Linear).OnComplete(() => func());
    }

    private void MoveToTheTarget(Action<Customer> func, Customer customer, Transform point)
    {
        tween = transform.DOMove(point.position, config.MoveDuration);
        tween.SetEase(Ease.Linear).OnComplete(() => func(customer));
    }
}
