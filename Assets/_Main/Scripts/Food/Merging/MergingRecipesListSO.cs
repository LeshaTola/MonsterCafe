using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MergingRecipesList", menuName = "MergingRecipe/List", order = 51)]
public class MergingRecipesListSO : ScriptableObject
{
	[field: SerializeField] public List<MergingRecipeSO> List { get; private set; }
}
