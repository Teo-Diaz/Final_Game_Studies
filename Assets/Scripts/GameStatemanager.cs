using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;

    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameStateManager");
                _instance = go.AddComponent<GameStateManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    // Puedes agregar más variables de estado según sea necesario
    public ChooseScene currentChooseScene;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
