using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarJuego : MonoBehaviour
{
    public string nombreEscenaHistoria = "Game";
    private ChooseScene AriaParque1;

    public void RegresarAEscenaHistoria()
    {
        SceneManager.LoadScene("Game");
        AriaParque1 = GameStateManager.Instance.currentChooseScene;

        // Recupera el estado guardado al volver a la escena de la historia
    }
}
