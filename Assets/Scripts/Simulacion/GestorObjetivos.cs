using TMPro;
using UnityEngine;

// Lista de objetivos en pantalla: [ ] pendiente, [x] cumplido.
public class GestorObjetivos : MonoBehaviour
{
    [SerializeField] TMP_Text texto;
    [SerializeField] string[] objetivos = { "Activa la alarma", "Llega a la zona segura" };

    bool[] cumplidos;

    void Awake()
    {
        cumplidos = new bool[objetivos.Length];
        Dibujar();
    }

    // Marca un objetivo por su número de orden: 0 es el primero de la lista.
    public void Cumplir(int numero)
    {
        if (numero < 0 || numero >= cumplidos.Length || cumplidos[numero])
        {
            return;
        }
        cumplidos[numero] = true;
        Dibujar();
    }

    public string Resumen()
    {
        int hechos = 0;
        foreach (bool c in cumplidos)
        {
            if (c) hechos++;
        }
        return "Objetivos: " + hechos + " de " + cumplidos.Length;
    }

    void Dibujar()
    {
        string lista = "OBJETIVOS";
        for (int i = 0; i < objetivos.Length; i++)
        {
            lista += "\n" + (cumplidos[i] ? "[x] " : "[ ] ") + objetivos[i];
        }
        texto.text = lista;
    }
}
