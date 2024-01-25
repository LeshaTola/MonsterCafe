using UnityEngine;

public abstract class ProcessingTool : MonoBehaviour
{
	[Header("Other")]
	[SerializeField] protected ProcessingRecipesListSO recipes;
	[SerializeField] protected ProcessingUIAnimation processingUI;

	protected IngredientSO recipeOutput;

	public Ingredient CurrentIngredient { get; protected set; }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlaceIngredient(collision);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		RemoveIngredient(collision);
	}

	protected virtual void PlaceIngredient(Collider2D collision)
	{
		if (!collision.TryGetComponent(out Ingredient ingredient))
		{
			return;
		}

		CurrentIngredient = ingredient;
		recipeOutput = GetOutputFromInput(ingredient.Config);
		if (recipeOutput != null)
		{
			processingUI.Show();
		}
	}

	protected virtual void RemoveIngredient(Collider2D collision)
	{
		if (!collision.TryGetComponent(out Ingredient ingredient))
		{
			return;
		}

		recipeOutput = null;
		CurrentIngredient = null;
		processingUI.Hide();
	}

	protected IngredientSO GetOutputFromInput(IngredientSO input)
	{
		foreach (var recipe in recipes.List)
		{
			if (recipe.Input == input)
			{
				return recipe.Output;
			}
		}

		return null;
	}

	public abstract void Processing();

	protected abstract void FinishProcessing();
}
