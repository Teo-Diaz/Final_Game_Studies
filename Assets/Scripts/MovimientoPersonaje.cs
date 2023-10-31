using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de movimiento hacia la derecha

    void Update()
    {
        // Mover el objeto horizontalmente hacia la derecha
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }
}