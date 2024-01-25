using DG.Tweening;
using System;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    [SerializeField] private CustomerSO config;

    private Tweener tween;

    private void OnDestroy()
    {
        transform.DOKill();
    }

    public void MoveToPoint(Action func, Transform point)
    {
        tween = transform.DOMove(point.position, config.MoveDuration);
        tween.SetEase(Ease.Linear).OnComplete(() => func());
    }

    public void MoveToPoint(Action<Customer> func, Customer customer, Transform point)
    {
        tween = transform.DOMove(point.position, config.MoveDuration);
        tween.SetEase(Ease.Linear).OnComplete(() => func(customer));
    }
}
