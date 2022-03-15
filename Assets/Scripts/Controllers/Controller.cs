using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private readonly List<Intent> intents = new();

    protected void RegisterIntent(IntentType type, Action action)
    {
        intents.Add(new(type, action));
        intents.ForEach(intent => intent.Push());
    }

    public virtual void Awake()
    {
        SingletonProvider.Provide<IntentQueue>();
        SingletonProvider.Provide<CommonController>();
    }

    public virtual void OnEnable()
    {
        intents.ForEach(intent => intent.Push());
    }

    public virtual void OnDisable()
    {
        intents.ForEach(intent => intent.Pop());
    }


    public virtual void OnDestroy()
    {
        intents.ForEach(intent => intent.Pop());
    }
}
