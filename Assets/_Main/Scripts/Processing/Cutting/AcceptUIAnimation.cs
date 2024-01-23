using DG.Tweening;
using UnityEngine;

public class AcceptUIAnimation : MonoBehaviour
{
	[Header("DoTween")]
	[SerializeField] private Transform showPoint;
	[SerializeField] private Transform hidePoint;

	private float animationTime = 0.5f;

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
