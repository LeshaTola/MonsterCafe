using System;
using UnityEngine;

public class ThermalProcessingTool : ProcessingTool, IHasProgressBar
{
	public event Action<float> OnProgressChanged;
	public event Action OnCuttingEnded;

	[SerializeField] private float maxProcessingTime = 5f;

	private float processingTimer;

	private void Start()
	{
		ResetTimer();
	}

	private void Update()
	{
		Processing();
	}

	public override void Processing()
	{
		if (recipeOutput == null || CurrentIngredient == null)
		{
			return;
		}

		processingTimer += Time.deltaTime;
		OnProgressChanged?.Invoke(processingTimer / maxProcessingTime);

		if (processingTimer > maxProcessingTime)
		{
			FinishProcessing();
			ResetTimer();
		}
	}

	protected override void FinishProcessing()
	{
		OnCuttingEnded?.Invoke();

		Instantiate(recipeOutput.Prefab, transform.position, Quaternion.identity);
		Destroy(CurrentIngredient.gameObject);
	}

	private void ResetTimer()
	{
		processingTimer = 0f;
		OnProgressChanged?.Invoke(0f);
	}

	protected override void RemoveIngredient(Collider2D collision)
	{
		base.RemoveIngredient(collision);
		ResetTimer();
	}
}
