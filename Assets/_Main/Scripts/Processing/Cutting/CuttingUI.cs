using UnityEngine;
using UnityEngine.UI;

public class CuttingUI : ProcessingUI
{
	[SerializeField] private Button food;

	[SerializeField] private CuttingTool cuttingTool;

	protected override void Init()
	{
		base.Init();

		food.onClick.AddListener(() =>
		{
			cuttingTool.Processing();
		});
	}

	private void Start()
	{
		cuttingTool.OnCuttingEnded += OnProcessingEnded;
		Hide();
	}

	private void OnDestroy()
	{
		cuttingTool.OnCuttingEnded -= OnProcessingEnded;
	}

	private void UpdateUI(Sprite foodSprite)
	{
		food.image.sprite = foodSprite;
	}

	public override void Show()
	{
		base.Show();
		UpdateUI(cuttingTool.CurrentIngredient?.Config.UISprite);
	}

	private void OnProcessingEnded()
	{
		Hide();
	}
}
