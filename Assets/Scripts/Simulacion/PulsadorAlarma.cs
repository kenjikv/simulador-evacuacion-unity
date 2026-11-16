using UnityEngine;

// El pulsador rojo de la pared. Al usarlo empieza la emergencia.
public class PulsadorAlarma : Interactuable
{
    [SerializeField] GestorSimulacion gestor;

    // Solo se puede pulsar una vez, y solo antes de la emergencia.
    public override bool PuedeInteractuar => gestor.Estado == EstadoSimulacion.Normal;

    public override void Interactuar()
    {
        gestor.ActivarAlarma();
    }
}
