using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _objectPool;

    public T Prefab { get; private set; }
    public bool AutoExpand { get; private set; }
    public Transform Container { get; private set; }

    public ObjectPool(T prefab, bool autoExpand, Transform container, int amount)
    {
        Prefab = prefab;
        AutoExpand = autoExpand;
        Container = container;

        CreatePool(amount);
    }

    private void CreatePool(int objectAmount)
    {
        _objectPool = new List<T>();

        for (int i = 0; i < objectAmount; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _objectPool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var obj in _objectPool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                element = obj;
                obj.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }
        if (AutoExpand)
        {
            return CreateObject(true);
        }
        throw new Exception($"You have no free objects in {typeof(T)} pool");
    }
}