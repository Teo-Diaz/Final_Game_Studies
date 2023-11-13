using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    //public KeyCode teclaEsperada;
    private List<GameObject> objetosColisionados = new List<GameObject>();
    private int puntos = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W))
        {
            VerificarTecla();
        }
    }

    private void VerificarTecla()
    {
        bool teclaCorrecta = false;

        foreach (var objeto in objetosColisionados)
        {
            PrefabKey prefabKey = objeto.GetComponent<PrefabKey>();

            if (prefabKey != null && Input.GetKeyDown(prefabKey.TeclaEsperada))
            {
                teclaCorrecta = true;
                break;
            }
        }

        if (teclaCorrecta)
        {
            puntos++;
            Debug.Log("Punto! Puntos totales: " + puntos);
        }
        else
        {
            Debug.Log("Botón incorrecto");
        }

        objetosColisionados.Clear();
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
