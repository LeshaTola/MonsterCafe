using System;
using UnityEngine;

public class MixingTool : ProcessingTool, IHasProgressBar
{
	public event Action<float> OnProgressChanged;
	public event Action OnCuttingEnded;

	[SerializeField] private float mixingTime = 3f;

	private float mixingTimer;

	private void Update()
	{
		ReduceProgress();
	}

	public override void Processing()
	{
		mixingTimer += 2 * Time.deltaTime;
		float progress = mixingTimer / mixingTime;
		OnProgressChanged?.Invoke(progress);

		if (mixingTimer > mixingTime)
		{
			FinishProcessing();
			ResetTimer();
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

	private void ReduceProgress()
	{
		if (mixingTimer > 0)
		{
			mixingTimer -= Time.deltaTime;
		}
		else
		{
			mixingTimer = 0;
		}

		float progress = mixingTimer / mixingTime;
		OnProgressChanged?.Invoke(progress);
	}

	private void ResetTimer()
	{
		mixingTimer = 0f;
		OnProgressChanged?.Invoke(0f);
	}

}
