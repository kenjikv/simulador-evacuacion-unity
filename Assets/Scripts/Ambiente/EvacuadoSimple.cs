using UnityEngine;
using UnityEngine.AI;

// Una persona que evacúa sola. Espera la alarma y camina por el NavMesh
// hasta el punto de encuentro, pidiendo la ruta de nuevo cada medio segundo.
[RequireComponent(typeof(NavMeshAgent))]
public class EvacuadoSimple : MonoBehaviour
{
    [SerializeField] Transform puntoEncuentro;
    [SerializeField] float segundosEntreRutas = 0.5f;

    NavMeshAgent agente;
    bool evacuando;
    float proximaRuta;

    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // La llama el evento "Al Iniciar Emergencia" del gestor.
    public void Evacuar()
    {
        evacuando = true;
        proximaRuta = 0f;
    }

    void Update()
    {
        if (!evacuando)
        {
            return;
        }

        // Volver a pedir la ruta sirve por si se abrió una puerta o algo cerró el paso.
        if (Time.time >= proximaRuta)
        {
            agente.SetDestination(puntoEncuentro.position);
            proximaRuta = Time.time + segundosEntreRutas;
        }

        // Llegó si la ruta está completa y ya no le falta distancia.
        bool rutaCompleta = !agente.pathPending && agente.pathStatus == NavMeshPathStatus.PathComplete;
        if (rutaCompleta && agente.remainingDistance <= agente.stoppingDistance)
        {
            evacuando = false;
            Debug.Log(name + " llegó al punto de encuentro.");
        }
    }
}
