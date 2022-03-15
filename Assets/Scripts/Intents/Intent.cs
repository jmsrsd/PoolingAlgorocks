using System;

public class Intent
{
    private readonly Action action = () => { };
    private readonly IntentType type;

    public Intent(IntentType type, Action action)
    {
        this.type = type;
        this.action = action;
    }

    public IntentType Type
    {
        get => type;
    }

    public void Execute() => action();

    public void Push() {
        IntentQueue.Instance.Push(this);
    }

    public void Pop() {
        IntentQueue.Instance.Pop(this);
    }
}