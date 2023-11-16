using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI puntosText;  // Arrastra tu objeto de texto al Inspector

    void Start()
    {
        // Asegúrate de que el objeto de texto esté asignado
        if (puntosText == null)
        {
            Debug.LogError("No se ha asignado el objeto de texto en el Inspector.");
        }
    }

    // Método para actualizar el texto de puntos en la UI
    public void ActualizarPuntos(double puntos)
    {
        puntosText.text = "PUNTOS: " + puntos.ToString();
    }
}
