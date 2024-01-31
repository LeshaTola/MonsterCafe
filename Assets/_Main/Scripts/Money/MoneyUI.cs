using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI moneyText;
	[SerializeField] private Money money;

	private void Start()
	{
		money.OnValueChanged += UpdateUI;

		UpdateUI(money.Value);
	}

	private void OnDestroy()
	{
		money.OnValueChanged += UpdateUI;
	}

	private void UpdateUI(int value)
	{
		moneyText.text = $"Money: {value}";
	}
}
