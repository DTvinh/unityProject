using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Singleton<Observer>
{
    private static Dictionary<string, List<Action<object[]>>> _listeners = new Dictionary<string, List<Action<object[]>>>();

    protected override void Awake()
    {
        base.Awake();
    }
    public static bool AddListener(string key, Action<object[]> action)
    {
        List<Action<object[]>> actions = new List<Action<object[]>>();
        if (_listeners.ContainsKey(key))
        {
            actions = _listeners[key];
        }
        else
        {
            _listeners.TryAdd(key, actions);
        }
        _listeners[key].Add(action);
        return true;

    }
    public static void RemoveListener(string key, Action<object[]> action)
    {
        if (!_listeners.ContainsKey(key))
        {
            return;
        }
        _listeners[key].Remove(action);
    }
    public static void Notify(string key, params object[] datas)
    {
        if (_listeners.ContainsKey(key))
        {
            foreach (Action<object[]> i in _listeners[key])
            {
                try
                {
                    i?.Invoke(datas);

                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            }
            return;
        }

        Debug.LogError("Key not exits" + key);

    }




}
