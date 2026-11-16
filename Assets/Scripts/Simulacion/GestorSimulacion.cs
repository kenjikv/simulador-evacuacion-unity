using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Máquina de estados de la simulación: decide en qué estado estamos,
// cuándo se cambia de uno a otro y qué pasa en cada cambio.
public class GestorSimulacion : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] ControladorPrimeraPersona jugador;
    [SerializeField] InteractorJugador interactor;
    [SerializeField] PantallaResultados pantalla;
    [SerializeField] GestorObjetivos objetivos;
    [SerializeField] RegistroPenalizaciones penalizaciones;

    [Header("Tiempo (segundos)")]
    [SerializeField] float tiempoLimite = 60f;   // si se acaba, la evacuación falla
    [SerializeField] float tiempoIdeal = 30f;    // si se tarda más, se penaliza

    [Header("Eventos")]
    [SerializeField] UnityEvent alIniciarEmergencia;

    public EstadoSimulacion Estado { get; private set; }

    float tiempoEmergencia;

    void Start()
    {
        CambiarEstado(EstadoSimulacion.Inicio);
    }

    void Update()
    {
        Keyboard teclado = Keyboard.current;

        // En el ejecutable, Escape cierra el programa (en el editor no hace nada).
        if (teclado != null && teclado.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }

        if (Estado == EstadoSimulacion.Inicio)
        {
            if (teclado != null && teclado.enterKey.wasPressedThisFrame)
            {
                CambiarEstado(EstadoSimulacion.Normal);
            }
        }
        else if (Estado == EstadoSimulacion.Emergencia)
        {
            tiempoEmergencia += Time.deltaTime;
            pantalla.MostrarReloj(tiempoLimite - tiempoEmergencia);
            if (tiempoEmergencia >= tiempoLimite)
            {
                Terminar(false, "Se acabó el tiempo.");
            }
        }
        else if (Estado == EstadoSimulacion.Exito || Estado == EstadoSimulacion.Fracaso)
        {
            if (teclado != null && teclado.rKey.wasPressedThisFrame)
            {
                // Volver a cargar la escena la deja como estaba al dar Play.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // La llama el pulsador de alarma.
    public void ActivarAlarma()
    {
        if (Estado != EstadoSimulacion.Normal)
        {
            return;
        }
        CambiarEstado(EstadoSimulacion.Emergencia);
        objetivos.Cumplir(0);
        alIniciarEmergencia.Invoke();
    }

    // La llama la zona segura cuando el jugador entra.
    public void LlegarZonaSegura()
    {
        if (Estado != EstadoSimulacion.Emergencia)
        {
            return;
        }
        objetivos.Cumplir(1);
        if (tiempoEmergencia > tiempoIdeal)
        {
            penalizaciones.Agregar("Evacuación lenta", 10);
        }
        Terminar(true, "Llegaste a la zona segura.");
    }

    // La llaman los peligros (por ejemplo, el humo).
    public void Fallar(string motivo)
    {
        if (Estado == EstadoSimulacion.Emergencia)
        {
            Terminar(false, motivo);
        }
    }

    void Terminar(bool exito, string motivo)
    {
        CambiarEstado(exito ? EstadoSimulacion.Exito : EstadoSimulacion.Fracaso);
        string texto = motivo
            + "\n\nTiempo: " + tiempoEmergencia.ToString("0.0") + " s"
            + "\n" + objetivos.Resumen()
            + "\nPuntaje: " + penalizaciones.Puntaje
            + "\n\n" + penalizaciones.Resumen();
        pantalla.MostrarResultado(exito, texto);
    }

    void CambiarEstado(EstadoSimulacion nuevo)
    {
        Estado = nuevo;
        Debug.Log("Estado: " + nuevo);

        // El jugador solo se mueve y usa cosas en Normal y en Emergencia.
        bool jugando = nuevo == EstadoSimulacion.Normal || nuevo == EstadoSimulacion.Emergencia;
        jugador.enabled = jugando;
        interactor.enabled = jugando;

        if (nuevo == EstadoSimulacion.Inicio)
        {
            pantalla.MostrarInicio();
        }
        else if (jugando)
        {
            pantalla.OcultarPanel();
        }
    }
}
