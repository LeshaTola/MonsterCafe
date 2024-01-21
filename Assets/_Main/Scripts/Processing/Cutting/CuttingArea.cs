using DG.Tweening;
using System;
using UnityEngine;

public class CuttingArea : MonoBehaviour, IHasProgressBar
{
	public event Action<float> OnProgressChanged;
	public event Action OnCuttingEnded;

	[Header("Cutting")]
	[SerializeField] private int maxCutCount;

	[Header("Other")]
	[SerializeField] private Collider2D areaCollider;
	[SerializeField] private ProgressBarUI progressBar;

	[Header("DoTween")]
	[SerializeField] private Transform showPoint;
	[SerializeField] private Transform hidePoint;

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
		OnProgressChanged?.Invoke(cuttingProgress);
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
		OnProgressChanged?.Invoke(0f);
	}

	public void Show()
	{
		gameObject.SetActive(true);

		transform.DOKill();
		transform.DOMove(showPoint.position, animationTime).OnComplete(() =>
		{
			areaCollider.enabled = true;
			progressBar.Show();
		});
	}

	public void Hide()
	{
		areaCollider.enabled = false;
		progressBar.Hide();

		transform.DOKill();
		transform.DOMove(hidePoint.position, animationTime).OnComplete(() => gameObject.SetActive(false));

		ResetCuttingProgress();
	}
}
