using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
	[SerializeField] private CuttingArea cuttingArea;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Ingredient ingredient))
		{
			cuttingArea.Show();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Ingredient ingredient))
		{
			cuttingArea.Hide();
		}
	}

}
