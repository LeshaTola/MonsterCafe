using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DragAndDrop : MonoBehaviour
{
	private Vector3 offset;
	private Camera cameraMain;

	public event Action OnDragStarted;
	public event Action OnDragEnded;

	private void Awake()
	{
		cameraMain = Camera.main;
	}

	private void OnMouseDown()
	{
		OnDragStarted?.Invoke();
		offset = transform.position - GetMousePosition();
	}

	private void OnMouseDrag()
	{
		transform.position = GetMousePosition() + offset;
	}

	private void OnMouseUp()
	{
		OnDragEnded?.Invoke();
	}

	private Vector3 GetMousePosition()
	{
		var mousePos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		return mousePos;
	}
}
