using System;
using UnityEngine;

public class CuttingTool : ProcessingTool, IHasProgressBar
{
	public event Action<float> OnProgressChanged;
	public event Action OnCuttingEnded;

	[Header("Cutting")]
	[SerializeField] private int maxCutAmount;

	private int cutAmount;

	public override void Processing()
	{
		cutAmount++;

		var cuttingProgress = (float)cutAmount / maxCutAmount;
		OnProgressChanged?.Invoke(cuttingProgress);

		float maxProgress = 1f;
		if (cuttingProgress.Equals(maxProgress))
		{
			ResetCuttingProgress();
			FinishProcessing();
		}
	}

	protected override void FinishProcessing()
	{
		if (recipeOutput == null || CurrentIngredient == null)
		{
			return;
		}

		OnCuttingEnded?.Invoke();
		Instantiate(recipeOutput.Prefab, transform.position, Quaternion.identity);
		Destroy(CurrentIngredient.gameObject);
	}

	private void ResetCuttingProgress()
	{
		cutAmount = 0;
		OnProgressChanged?.Invoke(0f);
	}
}
