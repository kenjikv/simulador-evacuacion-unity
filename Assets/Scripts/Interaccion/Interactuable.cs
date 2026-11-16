using UnityEngine;

// Clase base: guarda lo que todos los objetos interactuables tienen en común.
// Es abstracta: no se pone sola en un objeto, se usan sus hijas (Puerta, Interruptor...).
public abstract class Interactuable : MonoBehaviour, IInteractuable
{
    [SerializeField] protected string textoIndicacion = "E: Usar";
    [SerializeField] protected string motivoBloqueo = "No se puede usar";

    public virtual string TextoIndicacion => textoIndicacion;
    public virtual bool PuedeInteractuar => true;
    public virtual string MotivoBloqueo => motivoBloqueo;

    public abstract void Interactuar();
}
