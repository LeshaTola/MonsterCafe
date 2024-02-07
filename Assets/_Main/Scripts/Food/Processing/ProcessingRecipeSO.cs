using UnityEngine;

[CreateAssetMenu(fileName = "ProcessingRecipe", menuName = "ProcessingRecipes/Recipe", order = 51)]
public class ProcessingRecipeSO : ScriptableObject
{
	[field: SerializeField] public string Name { get; private set; }
	[field: SerializeField] public IngredientSO Input { get; private set; }
	[field: SerializeField] public IngredientSO Output { get; private set; }

}
