using UnityEngine;
using UnityEngine.UI;

public class ProcessingUI : MonoBehaviour
{
	[SerializeField] private Button close;

	[SerializeField] private Texture2D cursor;

	private void Awake()
	{
		Init();
	}

	protected virtual void Init()
	{
		close.onClick.AddListener(() => Hide());
	}

	public virtual void Show()
	{
		gameObject.SetActive(true);
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}

	public virtual void Hide()
	{
		gameObject.SetActive(false);
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
