using UnityEngine;

public class ColorSingleton
{
    public Color color = Color.white;

    private ColorSingleton() { }

    private static ColorSingleton instance;

    public static ColorSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ColorSingleton();
            }

            return instance;
        }
    }
}