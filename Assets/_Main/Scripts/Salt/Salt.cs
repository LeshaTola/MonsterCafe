using System;
using UnityEngine;

public class Salt : MonoBehaviour
{
	public event Action<float> OnValueChanged;
	public event Action OnSaltingEnded;

	private float maxValue = 1f;

	public float Value { get; private set; }

	public void Salting(float value)
	{
		if (value <= 0 || Value.Equals(maxValue))
		{
			return;
		}

		Value += value;

		if (Value >= maxValue)
		{
			Value = maxValue;
		}
	}
}
