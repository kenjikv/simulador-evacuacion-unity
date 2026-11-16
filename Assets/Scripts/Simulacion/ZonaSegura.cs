using UnityEngine;

// Caja invisible (trigger) en el punto de encuentro. Avisa al gestor cuando entra el jugador.
[RequireComponent(typeof(Collider))]
public class ZonaSegura : MonoBehaviour
{
    [SerializeField] GestorSimulacion gestor;

    void OnTriggerEnter(Collider otro)
    {
        if (otro.GetComponent<ControladorPrimeraPersona>() != null)
        {
            gestor.LlegarZonaSegura();
        }
    }
}
