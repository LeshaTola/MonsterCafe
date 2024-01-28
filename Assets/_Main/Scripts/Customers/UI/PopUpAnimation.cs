using DG.Tweening;
using UnityEngine;

public class PopUpAnimation : MonoBehaviour
{
    [SerializeField] private Transform hidePoint;
    [SerializeField] private Transform showPoint;

    [SerializeField] private float animationTime;

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);

        transform.DOKill();
        transform.DOMove(showPoint.position, animationTime);
    }

    public void Hide()
    {
        transform.DOKill();
        transform.DOMove(hidePoint.position, animationTime).OnComplete(() => gameObject.SetActive(false));
    }
}
