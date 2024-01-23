using UnityEngine;
using UnityEngine.UI;

public class CuttingUI : MonoBehaviour
{

	[SerializeField] Button closeButton;
	[SerializeField] Button foodButton;

	[Header("Other")]
	[SerializeField] private Texture2D knifeCursor;
	[SerializeField] private CuttingBoard cuttingBoard;

	private void Awake()
	{
		closeButton.onClick.AddListener(() => Hide());
		foodButton.onClick.AddListener(() =>
		{
			cuttingBoard.Cut();
		});
	}

	private void Start()
	{
		cuttingBoard.OnCuttingEnded += OnCuttingEnded;
		Hide();
	}

	private void OnDestroy()
	{
		cuttingBoard.OnCuttingEnded -= OnCuttingEnded;
	}

	private void UpdateUI(Sprite foodSprite)
	{
		foodButton.image.sprite = foodSprite;
	}

	public void Show()
	{
		gameObject.SetActive(true);
		Cursor.SetCursor(knifeCursor, Vector2.zero, CursorMode.Auto);
		UpdateUI(cuttingBoard.CurrentIngredient?.Config.UISprite);
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
