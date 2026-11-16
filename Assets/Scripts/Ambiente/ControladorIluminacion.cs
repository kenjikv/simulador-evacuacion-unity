using UnityEngine;
using UnityEngine.Rendering;

// Cambia el ambiente cuando empieza la emergencia: baja la luz del sol,
// enciende luces rojas que laten y mezcla un Volume con efectos de cámara.
public class ControladorIluminacion : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] Light luzPrincipal;
    [SerializeField] Light[] lucesEmergencia;
    [SerializeField] Volume volumenEmergencia;

    [Header("Emergencia")]
    [SerializeField] float intensidadSolEmergencia = 0.2f;
    [SerializeField] float intensidadMaxima = 4f;
    [SerializeField] float velocidadParpadeo = 1.5f;
    [SerializeField] float segundosTransicion = 1.5f;

    bool emergencia;

    void Awake()
    {
        foreach (Light luz in lucesEmergencia)
        {
            luz.enabled = false;
        }
        volumenEmergencia.weight = 0f;
    }

    // La llama el evento "Al Iniciar Emergencia" del gestor.
    public void ActivarEmergencia()
    {
        emergencia = true;
        luzPrincipal.intensity = intensidadSolEmergencia;
        foreach (Light luz in lucesEmergencia)
        {
            luz.enabled = true;
        }
    }

    void Update()
    {
        if (!emergencia)
        {
            return;
        }

        // El Volume entra poco a poco: su peso pasa de 0 a 1 en segundosTransicion.
        volumenEmergencia.weight = Mathf.MoveTowards(volumenEmergencia.weight, 1f, Time.deltaTime / segundosTransicion);

        // PingPong sube de 0 a 1 y vuelve a bajar: así las luces laten.
        float latido = Mathf.PingPong(Time.time * velocidadParpadeo, 1f);
        foreach (Light luz in lucesEmergencia)
        {
            luz.intensity = latido * intensidadMaxima;
        }
    }
}
