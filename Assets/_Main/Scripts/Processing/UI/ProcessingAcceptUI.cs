using UnityEngine;
using UnityEngine.UI;

public class ProcessingAcceptUI : MonoBehaviour
{
	[SerializeField] private Button accept;
	[SerializeField] private ProcessingUI processingUI;

	private void Awake()
	{
		accept.onClick.AddListener(() =>
		{
			processingUI.Show();
		});
	}
}
