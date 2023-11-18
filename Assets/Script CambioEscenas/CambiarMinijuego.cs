using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarMinijuego : MonoBehaviour
{
    public ChooseScene AriaParque1; // Asigna tu objeto Scriptable "Aria Parque 1" desde el inspector
    public string nombreEscenaMinijuego = "Game";

    public void CambiarAEscenaMinijuego()
    {
        // Guarda el estado actual del ChooseScene
        GameStateManager.Instance.currentChooseScene = AriaParque1;

        // Cambia a la escena del minijuego
        SceneManager.LoadScene("minijuego");
    }
}
