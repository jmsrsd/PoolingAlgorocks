using System;
using System.Collections.Generic;
using UnityEngine;

public static class SingletonProvider
{
    private static Dictionary<Type, MonoBehaviour> singletons = new();

    public static T Provide<T>() where T : MonoBehaviour
    {
        T result;

        if (singletons.ContainsKey(typeof(T)))
        {
            result = singletons[typeof(T)] as T;
        }
        else
        {
            var name = typeof(T).Name;

            var go = GameObject.Find(name) ?? new GameObject(name);

            UnityEngine.Object.DontDestroyOnLoad(go);

            result = go.GetComponent<T>()  ?? go.AddComponent<T>();

            singletons[typeof(T)] = result;
        }

        return result;
    }
}