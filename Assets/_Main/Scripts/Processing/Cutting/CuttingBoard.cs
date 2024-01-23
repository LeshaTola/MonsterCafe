using System;
using UnityEngine;

public class CuttingBoard : MonoBehaviour, IHasProgressBar
{
	public event Action<float> OnProgressChanged;
	public event Action OnCuttingEnded;

	[Header("Cutting")]
	[SerializeField] private int maxCutCount;

	[Header("Other")]
	[SerializeField] private ProcessingRecipesListSO cuttingRecipes;
	[SerializeField] private AcceptArea acceptArea;

	private int cutCount;
	private IngredientSO output;
	public Ingredient CurrentIngredient { get; private set; }


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Ingredient ingredient))
		{
			CurrentIngredient = ingredient;
			output = GetOutputFromInput(ingredient.Config);
			if (output != null)
			{
				acceptArea.Show();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Ingredient ingredient))
		{
			output = null;
			CurrentIngredient = null;
			acceptArea.Hide();
		}
	}

	private IngredientSO GetOutputFromInput(IngredientSO input)
	{
		foreach (var recipe in cuttingRecipes.List)
		{
			if (recipe.Input == input)
			{
				return recipe.Output;
			}
		}

		return null;
	}

	private void FinishCutting()
	{
		if (output == null || CurrentIngredient == null)
		{
			return;
		}

		OnCuttingEnded?.Invoke();
		Instantiate(output.Prefab, transform.position, Quaternion.identity);
		Destroy(CurrentIngredient.gameObject);
	}

	public void Cut()
	{
		cutCount++;

		var cuttingProgress = (float)cutCount / maxCutCount;
		OnProgressChanged?.Invoke(cuttingProgress);

		if (cuttingProgress.Equals(1f))
		{
			ResetCuttingProgress();
			FinishCutting();
		}
	}

	private void ResetCuttingProgress()
	{
		cutCount = 0;
		OnProgressChanged?.Invoke(0f);
	}
}
