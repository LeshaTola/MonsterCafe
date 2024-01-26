using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private Vector3 prevMousePosition;
	private Camera cameraMain;

	public bool IsPressed { get; private set; }
	public Vector3 MouseDelta { get; private set; }

	private void Awake()
	{
		cameraMain = Camera.main;
	}

	private void OnEnable()
	{
		IsPressed = false;
	}

	private void Update()
	{
		if (IsPressed)
		{
			MouseDelta = prevMousePosition - GetMousePosition();
			prevMousePosition = GetMousePosition();
		}
	}

	private void OnDisable()
	{
		IsPressed = false;
	}

	public void OnPointerUp(PointerEventData _)
	{
		IsPressed = false;
	}

	public void OnPointerDown(PointerEventData _)
	{
		prevMousePosition = GetMousePosition();
		MouseDelta = Vector3.zero;
		IsPressed = true;
	}

	private Vector3 GetMousePosition()
	{
		return cameraMain.ScreenToWorldPoint(Input.mousePosition);
	}
}
