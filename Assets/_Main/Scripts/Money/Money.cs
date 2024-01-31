using System;
using UnityEngine;

public class Money : MonoBehaviour
{
	public event Action<int> OnValueChanged;

	public int Value { get; private set; }

	public void AddMoney(int count)
	{
		if (count <= 0)
		{
			return;
		}

		Value += count;
		OnValueChanged?.Invoke(Value);
	}

	public void DenyMoney(int count)
	{
		if (count <= 0)
		{
			return;
		}

		Value -= count;
		OnValueChanged?.Invoke(Value);
	}

}
