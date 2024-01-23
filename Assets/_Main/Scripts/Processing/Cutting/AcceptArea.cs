using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AcceptArea : MonoBehaviour
{
	[SerializeField] private Button acceptButton;
	[SerializeField] private CuttingUI cuttingUI;

	[Header("DoTween")]
	[SerializeField] private Transform showPoint;
	[SerializeField] private Transform hidePoint;

	private float animationTime = 0.5f;

	private void Awake()
	{
		acceptButton.onClick.AddListener(() =>
		{
			cuttingUI.Show();
		});
	}

	private void Start()
	{
		Hide();
	}

	private void OnDestroy()
	{
		transform.DOKill();
	}

	public void Show()
	{
		gameObject.SetActive(true);

		transform.DOKill();
		transform.DOMove(showPoint.position, animationTime);
	}

	public void Hide()
	{
		transform.DOKill();
		transform.DOMove(hidePoint.position, animationTime).OnComplete(() => gameObject.SetActive(false));
	}
}
