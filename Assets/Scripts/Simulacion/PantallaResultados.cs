using TMPro;
using UnityEngine;

// Todo lo que el jugador lee en pantalla sobre la simulación:
// el panel de inicio, el panel de resultados y el reloj.
public class PantallaResultados : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text titulo;
    [SerializeField] TMP_Text detalle;
    [SerializeField] TMP_Text reloj;

    [SerializeField] Color colorExito = new Color(0.35f, 0.9f, 0.45f);
    [SerializeField] Color colorFracaso = new Color(1f, 0.4f, 0.35f);

    public void MostrarInicio()
    {
        MostrarPanel("SIMULACRO DE EVACUACIÓN",
            "Busca el pulsador de alarma y actívalo con E.\nDespués sal por la ruta que esté libre.\n\nPulsa Enter para empezar",
            Color.white);
        reloj.gameObject.SetActive(false);
    }

    public void OcultarPanel()
    {
        panel.SetActive(false);
    }

    int ultimoSegundo = -1;

    public void MostrarReloj(float segundosRestantes)
    {
        int segundos = Mathf.CeilToInt(Mathf.Max(0f, segundosRestantes));

        // Solo se arma el texto cuando cambia el número. Antes se creaba un texto nuevo
        // en cada cuadro, y esa basura de memoria es la que mostró el Profiler.
        if (segundos == ultimoSegundo)
        {
            return;
        }
        ultimoSegundo = segundos;
        reloj.gameObject.SetActive(true);
        reloj.text = "Tiempo: " + segundos + " s";
    }

    public void MostrarResultado(bool exito, string texto)
    {
        MostrarPanel(exito ? "EVACUACIÓN EXITOSA" : "EVACUACIÓN FALLIDA",
            texto + "\n\nPulsa R para reiniciar",
            exito ? colorExito : colorFracaso);
    }

    void MostrarPanel(string textoTitulo, string textoDetalle, Color color)
    {
        panel.SetActive(true);
        titulo.text = textoTitulo;
        titulo.color = color;
        detalle.text = textoDetalle;
    }
}
