using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "List", menuName = "Ingredients/List", order = 51)]
public class IngredientsListSO : ScriptableObject
{
	[field: SerializeField] public List<IngredientSO> List { get; private set; }
}
