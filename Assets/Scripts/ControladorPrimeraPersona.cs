using UnityEngine;
using UnityEngine.InputSystem;

// Mueve al jugador en primera persona con CharacterController e Input Actions.
[RequireComponent(typeof(CharacterController))]
public class ControladorPrimeraPersona : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] Transform camara;
    [SerializeField] InputActionReference accionMover;
    [SerializeField] InputActionReference accionMirar;
    [SerializeField] InputActionReference accionCorrer;

    [Header("Velocidades (m/s)")]
    [SerializeField] float velocidadCaminar = 3.2f;
    [SerializeField] float velocidadCorrer = 5.4f;
    [SerializeField] float gravedad = -20f;

    [Header("Mirada")]
    [SerializeField] float sensibilidad = 0.12f;
    [SerializeField] float limiteVertical = 85f;

    CharacterController controlador;
    float velocidadVertical;
    float giroVertical;

    void Awake()
    {
        controlador = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        accionMover.action.Enable();
        accionMirar.action.Enable();
        accionCorrer.action.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        Mirar();
        Mover();
    }

    void Mirar()
    {
        Vector2 raton = accionMirar.action.ReadValue<Vector2>() * sensibilidad;

        // El cuerpo gira a los lados y solo la cámara mira arriba y abajo.
        transform.Rotate(0f, raton.x, 0f);
        giroVertical = Mathf.Clamp(giroVertical - raton.y, -limiteVertical, limiteVertical);
        camara.localRotation = Quaternion.Euler(giroVertical, 0f, 0f);
    }

    void Mover()
    {
        Vector2 entrada = accionMover.action.ReadValue<Vector2>();
        float velocidad = accionCorrer.action.IsPressed() ? velocidadCorrer : velocidadCaminar;

        // Convierte la tecla pulsada en una dirección según hacia dónde mira el jugador.
        Vector3 direccion = transform.right * entrada.x + transform.forward * entrada.y;
        Vector3 movimiento = direccion * velocidad;

        // La gravedad acumula velocidad hacia abajo mientras el jugador no toca el suelo.
        if (controlador.isGrounded && velocidadVertical < 0f)
        {
            velocidadVertical = -2f;
        }
        velocidadVertical += gravedad * Time.deltaTime;
        movimiento.y = velocidadVertical;

        controlador.Move(movimiento * Time.deltaTime);
    }

    // CharacterController impide mover al jugador directamente: se apaga, se mueve y se enciende.
    public void Teletransportar(Vector3 posicion)
    {
        controlador.enabled = false;
        transform.position = posicion;
        controlador.enabled = true;
        velocidadVertical = 0f;
    }
}
