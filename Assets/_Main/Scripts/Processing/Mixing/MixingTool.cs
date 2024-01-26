using System;
using UnityEngine;

public class MixingTool : ProcessingTool, IHasProgressBar
{
	public event Action<float> OnProgressChanged;
	public event Action OnMixingEnded;

	[SerializeField] private float mixingTime = 3f;

	private float mixingTimer;

	private void Update()
	{
		ReduceProgress();
	}

	public override void Processing()
	{
		float mixingPower = 2;
		mixingTimer += mixingPower * Time.deltaTime;
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

		OnMixingEnded?.Invoke();
		Instantiate(recipeOutput.Prefab, transform.position, Quaternion.identity);
		Destroy(CurrentIngredient.gameObject);
	}

	private void ReduceProgress()
	{
		mixingTimer -= Time.deltaTime;

		if (mixingTimer <= 0)
		{
			mixingTimer = 0f;
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
