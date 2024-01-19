using System;
using System.Collections;
using UnityEngine;

public class Stopwatch
{
	public event Action<int, int> OnStopwatchUpdated;
	public event Action OnStopwatchEnded;

	private int lastMinute;

	public Stopwatch(int lastMinute)
	{
		this.lastMinute = lastMinute;
	}

	public IEnumerator StartStopwatch()
	{
		int minutes = 0;
		int seconds = 0;
		var cooldown = new WaitForSeconds(1f);
		while (minutes <= lastMinute)
		{
			yield return cooldown;
			seconds++;
			if (seconds >= 60)
			{
				minutes++;
				seconds = 0;
			}
			OnStopwatchUpdated?.Invoke(minutes, seconds);
		}
		OnStopwatchEnded?.Invoke();
	}
}
