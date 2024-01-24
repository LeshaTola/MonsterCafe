using UnityEngine;
using UnityEngine.UI;

public class MixingUI : ProcessingUI
{
	[SerializeField] private Image foodImage;
	[SerializeField] private HoldButton foodButton;

	[SerializeField] private MixingTool mixingTool;

	private void Start()
	{
		mixingTool.OnCuttingEnded += OnProcessingEnded;
		Hide();
	}

	protected override void Init()
	{
		base.Init();
	}

	private void Update()
	{
		if (foodButton.IsPressed)
		{
			mixingTool.Processing();
		}
	}

	private void OnDestroy()
	{
		mixingTool.OnCuttingEnded -= OnProcessingEnded;
	}

	private void UpdateUI(Sprite foodSprite)
	{
		foodImage.sprite = foodSprite;
	}

	public override void Show()
	{
		base.Show();
		UpdateUI(mixingTool.CurrentIngredient?.Config.UISprite);
	}

	private void OnProcessingEnded()
	{
		Hide();
	}
}
