using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class IntentQueue : MonoBehaviour
{
    public static IntentQueue Instance
    {
        get
        {
            return SingletonProvider.Provide<IntentQueue>();
        }
    }

    private readonly List<Intent> queue = new();

    public void Push(Intent intent)
    {

        if (queue.Contains(intent) == false)
        {
            queue.Add(intent);

        }
    }

    public void Pop(Intent intent)
    {
        if (queue.Contains(intent) == true)
        {
            queue.Remove(intent);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            queue.Where(e => e.Type == IntentType.LeftClick).ToList().ForEach(e => e.Execute());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            queue.Where(e => e.Type == IntentType.Escape).ToList().ForEach(e => e.Execute());
        }

        if (Input.GetMouseButton(0))
        {
            queue.Where(e => e.Type == IntentType.LeftMouseButton).ToList().ForEach(e => e.Execute());
        }
    }
}
