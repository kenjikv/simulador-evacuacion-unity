using TMPro;
using UnityEngine;

// Va en el jugador. Suma la exposición al humo mientras está dentro de una ZonaRiesgo.
// Si llega al máximo, la evacuación falla.
public class ExposicionJugador : MonoBehaviour
{
    [SerializeField] GestorSimulacion gestor;
    [SerializeField] RegistroPenalizaciones penalizaciones;
    [SerializeField] TMP_Text texto;
    [SerializeField] float maximo = 100f;

    ZonaRiesgo zonaActual;
    float exposicion;

    public void Entrar(ZonaRiesgo zona)
    {
        zonaActual = zona;
        penalizaciones.Agregar("Entraste en una zona con humo", 20);
    }

    public void Salir(ZonaRiesgo zona)
    {
        if (zonaActual == zona)
        {
            zonaActual = null;
        }
    }

    void Update()
    {
        if (zonaActual == null || gestor.Estado != EstadoSimulacion.Emergencia)
        {
            return;
        }
        exposicion += zonaActual.DanioPorSegundo * Time.deltaTime;
        texto.text = "Humo: " + Mathf.RoundToInt(Mathf.Min(exposicion, maximo) / maximo * 100f) + " %";
        if (exposicion >= maximo)
        {
            gestor.Fallar("Respiraste demasiado humo.");
        }
    }
}
