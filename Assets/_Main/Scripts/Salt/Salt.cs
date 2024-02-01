using System;

public class Salt
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
			OnSaltingEnded?.Invoke();
			return;
		}

		OnValueChanged?.Invoke(Value);
	}
}
