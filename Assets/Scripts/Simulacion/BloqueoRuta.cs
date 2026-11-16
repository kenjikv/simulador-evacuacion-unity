using UnityEngine;

// Objetos que cierran una ruta (humo, escombros). Se ven en el editor para acomodarlos,
// se esconden al dar Play y aparecen cuando alguien llama a Bloquear().
public class BloqueoRuta : MonoBehaviour
{
    [SerializeField] GameObject[] objetosBloqueo;

    void Awake()
    {
        foreach (GameObject objeto in objetosBloqueo)
        {
            objeto.SetActive(false);
        }
    }

    public void Bloquear()
    {
        foreach (GameObject objeto in objetosBloqueo)
        {
            objeto.SetActive(true);
        }
        Debug.Log("Ruta bloqueada: " + name);
    }
}
