using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private List<GameObject> objetosColisionados = new List<GameObject>(); // Almacena los objetos "front" con los que has colisionado
    private int puntos = 0; // Variable para llevar un contador de puntos

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var objeto in objetosColisionados)
            {
                if (objeto.CompareTag("objetovalido"))
                {
                    puntos++; // Incrementa los puntos por cada objeto "front" con el que no has colisionado previamente
                    Debug.Log("Puntos: " + puntos);
                }
            }
            objetosColisionados.Clear(); // Limpia la lista después de otorgar puntos
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("objetovalido") && !objetosColisionados.Contains(other.gameObject))
        {
            objetosColisionados.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("objetovalido"))
        {
            objetosColisionados.Remove(other.gameObject);
        }
    }
}