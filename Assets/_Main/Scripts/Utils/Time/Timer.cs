using System;
using System.Collections;
using UnityEngine;

public class Timer
{
	private Action<float> stepAction;
	private Action endAction;

	public float CurrentTime { get; private set; }
	public float TargetTime { get; private set; }
	public float TimeStep { get; private set; }
	public bool Looping { get; private set; }

	public Timer
		(float targetTime, float timeStep = 1f, bool looping = false, Action<float> stepAction = null, Action endAction = null)
	{
		TargetTime = targetTime;
		TimeStep = timeStep;
		Looping = looping;
		this.stepAction = stepAction;
		this.endAction = endAction;
	}

	public IEnumerator Start()
	{
		do
		{
			CurrentTime = 0;
			while (CurrentTime < TargetTime)
			{
				yield return new WaitForSeconds(TimeStep);
				CurrentTime += TimeStep;
				stepAction?.Invoke(TimeStep);
			}

			endAction?.Invoke();
		}
		while (Looping);
	}
}
