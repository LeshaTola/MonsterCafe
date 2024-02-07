using System;

public class BasicValue
{
	public event Action<float> OnValueChanged;

	public float Value { get; private set; }

	public void Add(float count)
	{
		if (count <= 0)
		{
			return;
		}

		Value += count;
		OnValueChanged?.Invoke(Value);
	}

	public void Deny(float count)
	{
		if (count <= 0)
		{
			return;
		}

		Value -= count;
		OnValueChanged?.Invoke(Value);
	}
}
