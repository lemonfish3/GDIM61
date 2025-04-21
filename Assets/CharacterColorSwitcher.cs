using UnityEngine;

public class CharacterColorSwitcher : MonoBehaviour
{
    public Material targetMaterial; // Assign the material using the Shader Graph

    public Color colorPlayer1 = Color.red;
    public Color colorPlayer2 = Color.green;
    public Color colorPlayer3 = Color.blue;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetColor(colorPlayer1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetColor(colorPlayer2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetColor(colorPlayer3);
        }
    }

    void SetColor(Color newColor)
    {
        targetMaterial.SetColor("CharacterColor", newColor);
    }
}
