using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Merge : MonoBehaviour
{
	[SerializeField] private Ingredient ingredient;
	[SerializeField] private DragAndDrop dragAndDrop;

	private float mergeRadius;
	private CircleCollider2D myCollider;

	public event Action OnMerge;

	private void Awake()
	{
		myCollider = GetComponent<CircleCollider2D>();

	}

	private void Start()
	{
		dragAndDrop.OnDragEnded += MergeIngredients;
		CalculateMergeRadius();
	}

	private void OnDestroy()
	{
		dragAndDrop.OnDragEnded -= MergeIngredients;
	}

	private void MergeIngredients()
	{
		List<Collider2D> colliders = FindNearestColiders();

		foreach (Collider2D collider in colliders)
		{
			if (!collider.TryGetComponent(out Ingredient otherIngredient))
			{
				continue;
			}

			var recipeOutput = RecipeSentry.Instance.GetMergingOutput(ingredient.Config, otherIngredient.Config);
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

	private List<Collider2D> FindNearestColiders()
	{
		var colliders = Physics2D.OverlapCircleAll(transform.position, mergeRadius).ToList();
		colliders.Remove(myCollider);
		return colliders;
	}

	private void CalculateMergeRadius()
	{
		mergeRadius = myCollider.radius;
		float multiplier = 0.6f;
		mergeRadius *= multiplier;
	}
}
