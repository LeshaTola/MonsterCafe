using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProcessingRecipesList", menuName = "ProcessingRecipes/List", order = 51)]
public class ProcessingRecipesListSO : ScriptableObject
{
	[field: SerializeField] public List<ProcessingRecipeSO> List { get; private set; }
}
