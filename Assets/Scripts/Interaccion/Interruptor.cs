using UnityEngine;
using UnityEngine.Events;

// Al usarlo, avisa por un evento. El interruptor no sabe quién escucha:
// la puerta y la señal se conectan en el Inspector.
public class Interruptor : Interactuable
{
    [SerializeField] UnityEvent alEncender;

    bool encendido;

    public override bool PuedeInteractuar => !encendido;

    public override void Interactuar()
    {
        encendido = true;
        alEncender.Invoke();
    }
}
