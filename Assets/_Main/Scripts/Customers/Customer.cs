using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private CustomerSO config;
    private QueueSentry queue;
    private Tweener tween;
    private Timer timer;
    private bool isClicable;

    private void Awake()
    {
        transform.parent.TryGetComponent<QueueSentry>(out var queueSentry);
        queue = queueSentry;
    }

    private void Start()
    {
        tween = transform.DOMove(queue.TargetPoint.position, config.MoveDuration);
        tween.SetEase(Ease.Linear).OnComplete(() => Wait());
    }

    private void OnMouseDown()
    {
        if(!isClicable) { return; }
        StopCoroutine(timer.Start());
        OrderComplite();
    }

    private void Wait()
    {
        isClicable = true;
        timer = new Timer(config.WaitDuration,endAction:OrderComplite);
        StartCoroutine(timer.Start());
    }

    private void OrderComplite()
    {
        isClicable = false;
        tween = transform.DOMove(transform.parent.position, config.MoveDuration);
        tween.SetEase(Ease.Linear).OnComplete(() => queue.Complite(this));
    }
}
