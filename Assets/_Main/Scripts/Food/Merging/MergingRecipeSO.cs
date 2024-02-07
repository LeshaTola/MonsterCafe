using UnityEngine;

[CreateAssetMenu(fileName = "MergingRecipe", menuName = "MergingRecipe/Recipe", order = 51)]
public class MergingRecipeSO : ScriptableObject
{
	[field: SerializeField] public string Name { get; private set; }
	[field: SerializeField] public IngredientSO FirstInput { get; private set; }
	[field: SerializeField] public IngredientSO SecondInput { get; private set; }
	[field: SerializeField] public IngredientSO Output { get; private set; }

}
