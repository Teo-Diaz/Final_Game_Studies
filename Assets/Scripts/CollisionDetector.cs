using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private List<GameObject> objetosColisionados = new List<GameObject>(); 
    private int puntos = 0; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var objeto in objetosColisionados)
            {
                if (objeto.CompareTag("objetovalido"))
                {
                    puntos++; 
                    Debug.Log("Puntos: " + puntos);
                }
            }
            objetosColisionados.Clear(); 
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