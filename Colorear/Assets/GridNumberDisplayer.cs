using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GridNumberDisplayer : MonoBehaviour
{
    public Texture2D texture;
    public GameObject numberCellPrefab; // Tu Text (TMP) desactivado
    public Transform gridParent; // El objeto con GridLayoutGroup

    void Start()
    {
      
        if (texture == null || numberCellPrefab == null || gridParent == null)
        {
            Debug.LogError("Faltan referencias");
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

        int width = texture.width;
        int height = texture.height;

        for (int y = height - 1; y >= 0; y--) // De arriba hacia abajo
        {
            for (int x = 0; x < width; x++)
            {
                int index = y * width + x;
                Color32 color = pixels[index];
                int number = colorToNumber[color];

                GameObject cell = Instantiate(numberCellPrefab, gridParent);
                cell.SetActive(true);
                cell.GetComponent<TMP_Text>().text = number.ToString();
            }
        }

        Debug.Log("Grilla generada con " + (width * height) + " celdas.");


    Debug.Log("Start corriendo");
    Debug.Log("Tamaño textura: " + texture.width + "x" + texture.height);

    
    Debug.Log("Cantidad total de píxeles: " + pixels.Length);
    }
    
}
