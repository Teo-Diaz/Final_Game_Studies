using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    private ControladorJuego controladorJuego;
    public float velocidad = 2.0f;

    void Start()
    {
        controladorJuego = FindObjectOfType<ControladorJuego>();
        if (controladorJuego == null)
        {
            Debug.LogError("No se encontró el ControladorJuego en la escena.");
        }
    }

    void Update()
    {
        // Mover el objeto horizontalmente hacia la derecha
        transform.Translate(Vector3.right * controladorJuego.VelocidadActual * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.S))
        {
            controladorJuego.AumentarVelocidadYMultiplicador();
        }
    }
}