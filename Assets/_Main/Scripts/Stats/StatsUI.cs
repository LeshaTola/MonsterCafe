using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI moneyText;
	[SerializeField] private TextMeshProUGUI ratingText;

	[SerializeField] private Stats stats;

	private void Start()
	{
		stats.Money.OnValueChanged += UpdateMoneyUI;
		stats.Rating.OnValueChanged += UpdateRatingUI;

		UpdateRatingUI(stats.Rating.Value);
		UpdateMoneyUI(stats.Money.Value);
	}

	private void OnDestroy()
	{
		stats.Money.OnValueChanged -= UpdateMoneyUI;
		stats.Rating.OnValueChanged -= UpdateRatingUI;
	}


	private void UpdateMoneyUI(float money)
	{
		moneyText.text = $"Money: {money}";
	}

	private void UpdateRatingUI(float rating)
	{
		ratingText.text = $"Rating: {rating}";
	}
}
