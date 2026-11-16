using UnityEngine;
using UnityEngine.InputSystem;

// Lanza un rayo desde la cámara. Si toca algo interactuable, muestra la indicación
// y, al pulsar E, lo usa.
public class InteractorJugador : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] Camera camara;
    [SerializeField] InputActionReference accionInteractuar;
    [SerializeField] IndicacionHUD indicacion;

    [Header("Rayo")]
    [SerializeField] float alcance = 2.5f;
    [SerializeField] LayerMask capas;   // Escenario e Interactuable: las paredes tapan el rayo

    void OnEnable()
    {
        accionInteractuar.action.Enable();
    }

    // Si otro script apaga este componente, que no quede un texto colgado en pantalla.
    void OnDisable()
    {
        indicacion.Ocultar();
    }

    void Update()
    {
        IInteractuable objetivo = null;
        Ray rayo = new Ray(camara.transform.position, camara.transform.forward);
        if (Physics.Raycast(rayo, out RaycastHit golpe, alcance, capas, QueryTriggerInteraction.Ignore))
        {
            objetivo = golpe.collider.GetComponentInParent<IInteractuable>();
        }

        if (objetivo == null)
        {
            indicacion.Ocultar();
            return;
        }

        indicacion.Mostrar(objetivo.PuedeInteractuar ? objetivo.TextoIndicacion : objetivo.MotivoBloqueo);

        if (accionInteractuar.action.WasPressedThisFrame() && objetivo.PuedeInteractuar)
        {
            objetivo.Interactuar();
        }
    }
}
