using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "FoodIngredient/Ingredient")]
public class FoodIngredientSO : ScriptableObject
{
	[field: SerializeField] public string Name { get; private set; }
	[field: SerializeField] public Sprite UISprite { get; private set; }
	[field: SerializeField] public FoodIngredient Prefab { get; private set; }
}
