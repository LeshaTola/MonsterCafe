using UnityEngine;

public class Ingredient : MonoBehaviour, ISaltable
{
	[field: SerializeField] public IngredientSO Config { get; private set; }

	public Salt Salt { get; set; }

	private void Awake()
	{
		Salt = new();
	}
}
