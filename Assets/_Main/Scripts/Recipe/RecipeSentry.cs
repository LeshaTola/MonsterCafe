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

	public IngredientSO GetCuttingOutput(IngredientSO input)
	{
		return GetProcessingOutput(input, cuttingRecipes.List);
	}

	public IngredientSO GetMixingOutput(IngredientSO input)
	{
		return GetProcessingOutput(input, mixingRecipes.List);
	}

	public IngredientSO GetThermalProcessingOutput(IngredientSO input)
	{
		return GetProcessingOutput(input, thermalProcessingRecipes.List);
	}

	public IngredientSO GetMergingOutput(IngredientSO firstInput, IngredientSO secondInput)
	{
		foreach (var recipe in mergingRecipes.List)
		{
			bool isFirstInputMatch = recipe.FirstInput == firstInput || recipe.FirstInput == secondInput;
			bool isSecondInputMatch = recipe.SecondInput == firstInput || recipe.SecondInput == secondInput;

			if (isFirstInputMatch && isSecondInputMatch)
			{
				return recipe.Output;
			}
		}

		return null;
	}

	public IngredientSO GetProcessingOutput(IngredientSO input, List<ProcessingRecipeSO> list)
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
