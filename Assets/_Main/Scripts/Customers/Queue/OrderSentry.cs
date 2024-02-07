using UnityEngine;

public class OrderSentry : MonoBehaviour
{
    private MergingRecipesListSO mergingRecipes;

    private void Start()
    {
        mergingRecipes = RecipeSentry.Instance.MergingRecipes;
    }

    public MergingRecipeSO ChooseOrder()
    {
        return mergingRecipes.List[Random.Range(0, mergingRecipes.List.Count)];
    }
}
