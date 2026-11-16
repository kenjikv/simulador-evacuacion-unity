using System.Collections.Generic;
using UnityEngine;

// Anota cada error del jugador y lo resta del puntaje.
public class RegistroPenalizaciones : MonoBehaviour
{
    [SerializeField] int puntajeInicial = 100;

    readonly List<string> anotaciones = new List<string>();

    public int Puntaje { get; private set; }

    void Awake()
    {
        Puntaje = puntajeInicial;
    }

    public void Agregar(string motivo, int puntos)
    {
        Puntaje = Mathf.Max(0, Puntaje - puntos);
        anotaciones.Add("-" + puntos + "  " + motivo);
        Debug.Log("Penalización: " + motivo + " (-" + puntos + ")");
    }

    // Texto con todas las penalizaciones, una por línea.
    public string Resumen()
    {
        if (anotaciones.Count == 0)
        {
            return "Sin penalizaciones";
        }
        return string.Join("\n", anotaciones);
    }
}
