using UnityEngine;
using UnityEngine.UI;

public class AcceptUI : MonoBehaviour
{
	[SerializeField] private Button accept;
	[SerializeField] private CuttingUI cuttingUI;

	private void Awake()
	{
		accept.onClick.AddListener(() =>
		{
			cuttingUI.Show();
		});
	}
}
