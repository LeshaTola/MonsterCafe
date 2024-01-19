using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredients/Ingredient", order = 51)]
public class IngredientSO : ScriptableObject
{
	[field: SerializeField] public string Name { get; private set; }
	[field: SerializeField] public Sprite UISprite { get; private set; }
	[field: SerializeField] public Ingredient Prefab { get; private set; }
}
