using TMPro;
using UnityEngine;

// Letrero que cambia de color, de texto y de ritmo. Su material usa el Shader Graph SG_Senal:
// _ColorBase es el color y _Pulso dice cuánto parpadea (0 = luz fija, 1 = parpadeo completo).
public class SenalEstado : MonoBehaviour
{
    [SerializeField] Renderer panel;
    [SerializeField] TMP_Text texto;
    [SerializeField] Color colorCerrada = new Color(0.85f, 0.1f, 0.1f);
    [SerializeField] Color colorLibre = new Color(0.1f, 0.7f, 0.25f);

    static readonly int idColor = Shader.PropertyToID("_ColorBase");
    static readonly int idPulso = Shader.PropertyToID("_Pulso");
    MaterialPropertyBlock bloque;

    void Awake()
    {
        bloque = new MaterialPropertyBlock();
        MostrarCerrada();
    }

    public void MostrarCerrada()
    {
        Aplicar(colorCerrada, 1f, "CERRADA");
    }

    public void MostrarPasoLibre()
    {
        Aplicar(colorLibre, 0f, "PASO LIBRE");
    }

    void Aplicar(Color color, float pulso, string mensaje)
    {
        panel.GetPropertyBlock(bloque);
        bloque.SetColor(idColor, color);
        bloque.SetFloat(idPulso, pulso);
        panel.SetPropertyBlock(bloque);
        texto.text = mensaje;
    }
}
