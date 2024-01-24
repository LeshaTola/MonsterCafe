using UnityEngine;
using UnityEngine.UI;

public class CuttingUI : MonoBehaviour
{

	[SerializeField] Button close;
	[SerializeField] Button food;

	[Header("Other")]
	[SerializeField] private Texture2D knifeCursor;
	[SerializeField] private CuttingTool cuttingTool;

	private void Awake()
	{
		close.onClick.AddListener(() => Hide());
		food.onClick.AddListener(() =>
		{
			cuttingTool.Processing();
		});
	}

	private void Start()
	{
		cuttingTool.OnCuttingEnded += OnCuttingEnded;
		Hide();
	}

	private void OnDestroy()
	{
		cuttingTool.OnCuttingEnded -= OnCuttingEnded;
	}

	private void UpdateUI(Sprite foodSprite)
	{
		food.image.sprite = foodSprite;
	}

	public void Show()
	{
		gameObject.SetActive(true);
		Cursor.SetCursor(knifeCursor, Vector2.zero, CursorMode.Auto);
		UpdateUI(cuttingTool.CurrentIngredient?.Config.UISprite);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

	private void OnCuttingEnded()
	{
		Hide();
	}
}
