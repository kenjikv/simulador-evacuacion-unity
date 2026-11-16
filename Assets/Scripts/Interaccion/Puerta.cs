using UnityEngine;

// Puerta que gira sobre su bisagra. Empieza bloqueada hasta que alguien llama a Desbloquear().
// Este script va en el objeto bisagra, que es el padre de la hoja.
public class Puerta : Interactuable
{
    [SerializeField] bool bloqueada = true;
    [SerializeField] float anguloAbierta = 90f;
    [SerializeField] float velocidad = 120f;   // grados por segundo

    bool abierta;
    Quaternion rotacionCerrada;

    void Awake()
    {
        rotacionCerrada = transform.localRotation;
    }

    public override string TextoIndicacion => abierta ? "E: Cerrar puerta" : "E: Abrir puerta";
    public override bool PuedeInteractuar => !bloqueada;

    public override void Interactuar()
    {
        abierta = !abierta;
    }

    public void Desbloquear()
    {
        bloqueada = false;
    }

    void Update()
    {
        Quaternion objetivo = abierta ? rotacionCerrada * Quaternion.Euler(0f, anguloAbierta, 0f) : rotacionCerrada;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, objetivo, velocidad * Time.deltaTime);
    }
}
