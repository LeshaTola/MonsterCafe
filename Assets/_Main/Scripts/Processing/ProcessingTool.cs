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
		if (!collision.TryGetComponent(out Ingredient ingredient) || CurrentIngredient != null)
		{
			return;
		}

		CurrentIngredient = ingredient;
		recipeOutput = RecipeSentry.Instance.GetProcessingRecipeOutput(ingredient.Config, recipes.List);
		if (recipeOutput != null)
		{
			processingUI.Show();
		}
	}

	protected virtual void RemoveIngredient(Collider2D collision)
	{
		if (!collision.TryGetComponent(out Ingredient ingredient) || ingredient != CurrentIngredient)
		{
			return;
		}

		recipeOutput = null;
		CurrentIngredient = null;
		processingUI.Hide();
	}

	public abstract void Processing();

	protected abstract void FinishProcessing();
}
