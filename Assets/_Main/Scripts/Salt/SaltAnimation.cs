using DG.Tweening;
using UnityEngine;

public class SaltAnimation : MonoBehaviour
{
	[SerializeField] private DragAndDrop dragAndDrop;

	[SerializeField] private float animationDuration = 0.5f;

	private void Start()
	{
		dragAndDrop.OnDragStarted += OnDragStarted;
		dragAndDrop.OnDragEnded += OnDragEnded;
	}

	private void OnDestroy()
	{
		dragAndDrop.OnDragStarted -= OnDragStarted;
		dragAndDrop.OnDragEnded -= OnDragEnded;
	}

	private void OnDragEnded()
	{
		transform.DOKill();
		transform.DORotate(Vector3.zero, animationDuration, RotateMode.Fast);
	}

	private void OnDragStarted()
	{
		transform.DOKill();
		transform.DORotate(new Vector3(0, 0, -180), animationDuration, RotateMode.Fast);
	}
}
