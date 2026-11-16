using UnityEngine;

// Red de seguridad: si el jugador cae o sale del escenario, vuelve al punto de inicio.
public class LimiteEscenario : MonoBehaviour
{
    [SerializeField] ControladorPrimeraPersona controlador;
    [SerializeField] Bounds limites = new Bounds(new Vector3(9f, 5f, 3f), new Vector3(30f, 20f, 20f));

    Vector3 puntoInicio;

    void Start()
    {
        puntoInicio = transform.position;
    }

    void Update()
    {
        if (!limites.Contains(transform.position))
        {
            controlador.Teletransportar(puntoInicio);
            Debug.Log("El jugador volvió al punto de inicio.");
        }
    }

    // Dibuja los límites en la vista Scene cuando el objeto está seleccionado.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.6f);
        Gizmos.DrawWireCube(limites.center, limites.size);
    }
}
