using DG.Tweening;
using System;
using UnityEngine;

public class CuttingArea : MonoBehaviour
{
	public event Action<float> OnCuttingProgressChanged;
	public event Action OnCuttingEnded;

	[SerializeField] private Transform showPoint;
	[SerializeField] private Transform hidePoint;

	[SerializeField] private Collider2D areaCollider;

	[SerializeField] private int maxCutCount;

	private float animationTime = 1f;
	private int cutCount;

	private void Start()
	{
		Hide();
	}

	private void OnMouseDown()
	{
		Cut();
	}

	private void Cut()
	{
		cutCount++;

		var cuttingProgress = (float)cutCount / maxCutCount;
		OnCuttingProgressChanged?.Invoke(cuttingProgress);
		Debug.Log(cuttingProgress);

		if (cuttingProgress.Equals(1f))
		{
			Debug.Log("ended");
			OnCuttingEnded?.Invoke();
			ResetCuttingProgress();
		}
	}

	private void ResetCuttingProgress()
	{
		cutCount = 0;
		OnCuttingProgressChanged?.Invoke(0f);
	}

	public void Show()
	{
		gameObject.SetActive(true);

		transform.DOKill();
		transform.DOMove(showPoint.position, animationTime).OnComplete(() => areaCollider.enabled = true);
	}

	public void Hide()
	{
		areaCollider.enabled = false;

		transform.DOKill();
		transform.DOMove(hidePoint.position, animationTime).OnComplete(() => gameObject.SetActive(false));

		ResetCuttingProgress();
	}
}
