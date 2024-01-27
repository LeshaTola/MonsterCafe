using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Merge : MonoBehaviour
{
	public event Action OnMerge;

	[SerializeField] private Ingredient ingredient;
	[SerializeField] private DragAndDrop dragAndDrop;

	private float mergeRadius;
	private CircleCollider2D myCollider;

	private void Awake()
	{
		myCollider = GetComponent<CircleCollider2D>();

		mergeRadius = myCollider.radius;
	}

	private void Start()
	{
		dragAndDrop.OnDragEnded += OnDragEnded;
	}

	private void OnDestroy()
	{
		dragAndDrop.OnDragEnded -= OnDragEnded;
	}

	private void MergeIngredients()
	{
		List<Collider2D> colliders = FindNearestIngredients();

		foreach (Collider2D collider in colliders)
		{
			if (!collider.TryGetComponent(out Ingredient otherIngredient))
			{
				continue;
			}

			var recipeOutput = RecipeSentry.Instance.GetMergingRecipeOutput(ingredient.Config, otherIngredient.Config);
			if (recipeOutput == null)
			{
				continue;
			}

			OnMerge?.Invoke();
			Instantiate(recipeOutput.Prefab, transform.position, Quaternion.identity);

			Destroy(ingredient.gameObject);
			Destroy(otherIngredient.gameObject);
			return;
		}
	}

	private List<Collider2D> FindNearestIngredients()
	{
		var colliders = Physics2D.OverlapCircleAll(transform.position, mergeRadius).ToList();
		colliders.Remove(myCollider);
		return colliders;
	}

	private void OnDragEnded()
	{
		MergeIngredients();
	}
}
