using System.Collections.Generic;
using UnityEngine;

public class ColorReader : MonoBehaviour
{
    public Texture2D texture;

    void Start()
    {
        if (texture == null)
        {
            Debug.LogError("No hay textura asignada.");
            return;
        }

        Color32[] pixels = texture.GetPixels32();
        Dictionary<Color32, int> colorToNumber = new Dictionary<Color32, int>();
        int counter = 1;

        foreach (Color32 color in pixels)
        {
            if (!colorToNumber.ContainsKey(color))
            {
                colorToNumber[color] = counter;
                counter++;
            }
        }

        Debug.Log("Colores únicos encontrados: " + colorToNumber.Count);

        foreach (var pair in colorToNumber)
        {
            Debug.Log($"Color {pair.Key} → Número {pair.Value}");
        }
    }
}
