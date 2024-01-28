using DG.Tweening;
using System;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    [SerializeField] private CustomerSO config;

    public void MoveToPoint(Action func, Transform point)
    {
        transform.DOMove(point.position, config.MoveDuration).SetEase(Ease.Linear).OnComplete(() => func());
    }

    public void MoveToPoint(Action<Customer> func, Customer customer, Transform point)
    {
        transform.DOMove(point.position, config.MoveDuration).SetEase(Ease.Linear).OnComplete(() => func(customer));
    }
}
