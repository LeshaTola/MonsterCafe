using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
	[SerializeField] private GameObject hasProgressBarGameObject;
	[SerializeField] private Image barImage;

	private IHasProgressBar hasProgressBar;

	private void Start()
	{
		hasProgressBar = hasProgressBarGameObject.GetComponent<IHasProgressBar>();
		if (hasProgressBar == null)
		{
			Debug.LogError("Object: " + hasProgressBarGameObject + "don't have IHasProgressBar");
		}

		hasProgressBar.OnProgressChanged += ChangeProgressUI;
	}

	private void ChangeProgressUI(float progress)
	{
		barImage.fillAmount = progress;
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
