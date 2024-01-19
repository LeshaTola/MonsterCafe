using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "List", menuName = "FoodIngredient/List")]
public class FoodIngredientsListSO : ScriptableObject
{
	[field: SerializeField] public List<FoodIngredientSO> List { get; private set; }
}
