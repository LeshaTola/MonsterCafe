using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

	public bool IsPressed { get; private set; }

	private void OnEnable()
	{
		IsPressed = false;
	}

	private void OnDisable()
	{
		IsPressed = false;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		IsPressed = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		IsPressed = true;
	}
}
