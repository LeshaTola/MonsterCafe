using UnityEngine;

[CreateAssetMenu(fileName = "ProcessingRecipe", menuName = "ProcessingRecipes/Recipe", order = 51)]
public class ProcessingRecipeSO : ScriptableObject
{
	[field: SerializeField] public string Name { get; private set; }
	[field: SerializeField] public Ingredient Input { get; private set; }
	[field: SerializeField] public Ingredient Output { get; private set; }

}
