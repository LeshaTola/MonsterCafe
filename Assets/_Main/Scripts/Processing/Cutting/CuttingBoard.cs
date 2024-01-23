using System;
using UnityEngine;

public class CuttingBoard : MonoBehaviour, IHasProgressBar
{
	public event Action<float> OnProgressChanged;
	public event Action OnCuttingEnded;

	[Header("Cutting")]
	[SerializeField] private int maxCutAmount;

	[Header("Other")]
	[SerializeField] private ProcessingRecipesListSO cuttingRecipes;
	[SerializeField] private AcceptUIAnimation acceptUIAnimation;

	private int cutAmount;
	private IngredientSO recipeOutput;
	public Ingredient CurrentIngredient { get; private set; }


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.TryGetComponent(out Ingredient ingredient))
		{
			return;
		}

		CurrentIngredient = ingredient;
		recipeOutput = GetOutputFromInput(ingredient.Config);
		if (recipeOutput != null)
		{
			acceptUIAnimation.Show();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!collision.TryGetComponent(out Ingredient ingredient))
		{
			return;
		}

		recipeOutput = null;
		CurrentIngredient = null;
		acceptUIAnimation.Hide();
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
		if (recipeOutput == null || CurrentIngredient == null)
		{
			return;
		}

		OnCuttingEnded?.Invoke();
		Instantiate(recipeOutput.Prefab, transform.position, Quaternion.identity);
		Destroy(CurrentIngredient.gameObject);
	}

	public void Cut()
	{
		cutAmount++;

		var cuttingProgress = (float)cutAmount / maxCutAmount;
		OnProgressChanged?.Invoke(cuttingProgress);

		float maxProgress = 1f;
		if (cuttingProgress.Equals(maxProgress))
		{
			ResetCuttingProgress();
			FinishCutting();
		}
	}

	private void ResetCuttingProgress()
	{
		cutAmount = 0;
		OnProgressChanged?.Invoke(0f);
	}
}
