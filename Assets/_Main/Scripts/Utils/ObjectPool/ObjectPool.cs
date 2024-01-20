using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
{
	private Func<T> preloadFunc;
	private Action<T> getAction;
	private Action<T> releaseAction;

	private Queue<T> pool = new();
	private List<T> active = new();

	private bool isAutoExpand;

	public IReadOnlyCollection<T> Active { get => active; }

	public ObjectPool(Func<T> preloadFunc, Action<T> getAction, Action<T> releaseAction, int preloadCount, bool isAutoExpand)
	{
		this.preloadFunc = preloadFunc;
		this.getAction = getAction;
		this.releaseAction = releaseAction;
		this.isAutoExpand = isAutoExpand;

		if (this.preloadFunc == null)
		{
			Debug.LogError("There is no preloadFunc");
		}

		for (int i = 0; i < preloadCount; i++)
		{
			Release(this.preloadFunc.Invoke());
		}
	}

	public object GetPreloadFunc()
	{
		return preloadFunc;
	}

	public T Get()
	{
		if(pool.Count == 0 && !isAutoExpand)
		{
			return default;
		}

		if (pool.Count == 0)
		{
			pool.Enqueue(preloadFunc.Invoke());
		}

		T pooledObject = pool.Dequeue();
		active.Add(pooledObject);

		getAction.Invoke(pooledObject);
		return pooledObject;
	}

	public void Release(T obj)
	{
		active.Remove(obj);
		pool.Enqueue(obj);

		releaseAction?.Invoke(obj);
	}
}
