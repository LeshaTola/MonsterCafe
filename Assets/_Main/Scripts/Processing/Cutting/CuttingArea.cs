using DG.Tweening;
using UnityEngine;

public class CuttingArea : MonoBehaviour
{
	[SerializeField] private Transform showPoint;
	[SerializeField] private Transform hidePoint;

	[SerializeField] private Collider2D collider;

	private float animationTime = 1f;

	private void Start()
	{
		Hide();
	}

	private void OnMouseDown()
	{
		Debug.Log("Click");
	}

	public void Show()
	{
		gameObject.SetActive(true);
		transform.DOKill();
		transform.DOMove(showPoint.position, animationTime).OnComplete(() => collider.enabled = true);
	}

	public void Hide()
	{
		collider.enabled = false;
		transform.DOKill();
		transform.DOMove(hidePoint.position, animationTime).OnComplete(() => gameObject.SetActive(false));
	}
}
