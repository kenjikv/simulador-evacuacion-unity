using UnityEngine;

// Caja trigger con humo. Le avisa al jugador cuando entra y cuando sale.
[RequireComponent(typeof(Collider))]
public class ZonaRiesgo : MonoBehaviour
{
    [SerializeField] float danioPorSegundo = 25f;   // cuánto sube la exposición cada segundo

    public float DanioPorSegundo => danioPorSegundo;

    void OnTriggerEnter(Collider otro)
    {
        ExposicionJugador exposicion = otro.GetComponent<ExposicionJugador>();
        if (exposicion != null)
        {
            exposicion.Entrar(this);
        }
    }

    void OnTriggerExit(Collider otro)
    {
        ExposicionJugador exposicion = otro.GetComponent<ExposicionJugador>();
        if (exposicion != null)
        {
            exposicion.Salir(this);
        }
    }
}
