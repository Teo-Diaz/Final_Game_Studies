using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    private static ControladorJuego instancia;
    private bool multiplicadorActivado = false;

    public static ControladorJuego Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = FindObjectOfType<ControladorJuego>();
                if (instancia == null)
                {
                    Debug.LogError("No se encontró el ControladorJuego en la escena.");
                }
            }
            return instancia;
        }
    }

    private float velocidadInicial = 6.5f;
    private float velocidadActual;
    private float multiplicadorPuntos = 1.5f;
    private float ActivarMultiplicador = 1.5f;

    void Start()
    {
        velocidadActual = velocidadInicial;
    }

    public void AumentarVelocidadYMultiplicador()
    {
        velocidadActual = 9f;
        multiplicadorPuntos = 1.5f;
    }

    public float VelocidadActual
    {
        get { return velocidadActual; }
    }

    public float MultiplicadorPuntos
    {
        get { return multiplicadorPuntos; }
    }
    public void SetMultiplicadorActivado()
    {
        multiplicadorActivado = true;
    }

    public bool MultiplicadorActivado
    {
        get { return multiplicadorActivado; }
    }
}