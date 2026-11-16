using TMPro;
using UnityEngine;

// Muestra u oculta el texto de ayuda en la parte inferior de la pantalla.
public class IndicacionHUD : MonoBehaviour
{
    [SerializeField] TMP_Text texto;

    void Start()
    {
        Ocultar();
    }

    public void Mostrar(string mensaje)
    {
        texto.text = mensaje;
        texto.enabled = true;
    }

    public void Ocultar()
    {
        texto.enabled = false;
    }
}
