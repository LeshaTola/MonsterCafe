using System.Collections.Generic;
using UnityEngine;

public class RecipeSentry : MonoBehaviour
{
	[SerializeField] private ProcessingRecipesListSO cuttingRecipes;
	[SerializeField] private ProcessingRecipesListSO mixingRecipes;
	[SerializeField] private ProcessingRecipesListSO thermalProcessingRecipes;
	[SerializeField] private MergingRecipesListSO mergingRecipes;

	public static RecipeSentry Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public IngredientSO GetCuttingRecipeOutput(IngredientSO input)
	{
		return GetProcessingRecipeOutput(input, cuttingRecipes.List);
	}
	public IngredientSO GetMixingRecipeOutput(IngredientSO input)
	{
		return GetProcessingRecipeOutput(input, mixingRecipes.List);
	}
	public IngredientSO GetThermalProcessingRecipeOutput(IngredientSO input)
	{
		return GetProcessingRecipeOutput(input, thermalProcessingRecipes.List);
	}

	public IngredientSO GetMergingRecipeOutput(IngredientSO firstInput, IngredientSO secondInput)
	{
		foreach (var recipe in mergingRecipes.List)
		{
			if (recipe.FirstInput == firstInput || recipe.FirstInput == secondInput)
			{
				if (recipe.SecondInput == firstInput || recipe.SecondInput == secondInput)
				{
					return recipe.Output;
				}
			}
		}

		return null;
	}

	public IngredientSO GetProcessingRecipeOutput(IngredientSO input, List<ProcessingRecipeSO> list)
	{
		foreach (var recipe in list)
		{
			if (recipe.Input == input)
			{
				return recipe.Output;
			}
		}

		return null;
	}

}
