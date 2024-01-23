using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
	[SerializeField] private GameObject hasProgressBarGameObject;
	[SerializeField] private Image barImage;

	private IHasProgressBar hasProgressBar;

	private void Start()
	{
		if (!hasProgressBarGameObject.TryGetComponent(out hasProgressBar))
		{
			Debug.LogError("Object: " + hasProgressBarGameObject + "don't have IHasProgressBar");
			return;
		}

		hasProgressBar.OnProgressChanged += ChangeProgressUI;
	}

	private void OnDestroy()
	{
		hasProgressBar.OnProgressChanged -= ChangeProgressUI;
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
