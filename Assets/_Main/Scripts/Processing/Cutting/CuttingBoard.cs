using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
	[SerializeField] private ProcessingRecipesListSO cuttingRecipes;
	[SerializeField] private CuttingArea cuttingArea;

	private Ingredient currentIngredient;
	private IngredientSO output;

	private void Start()
	{
		cuttingArea.OnCuttingEnded += OnCuttingEnded;
	}

	private void OnDestroy()
	{
		cuttingArea.OnCuttingEnded -= OnCuttingEnded;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Ingredient ingredient))
		{
			currentIngredient = ingredient;
			output = GetOutputFromInput(ingredient.Config);
			if (output != null)
			{
				cuttingArea.Show();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Ingredient ingredient))
		{
			output = null;
			currentIngredient = null;
			cuttingArea.Hide();
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

	private void OnCuttingEnded()
	{
		if (output == null || currentIngredient == null)
		{
			return;
		}

		Instantiate(output.Prefab, transform.position, Quaternion.identity);
		Destroy(currentIngredient.gameObject);
	}
}
