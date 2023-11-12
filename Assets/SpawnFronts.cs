using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFronts : MonoBehaviour
{
    public GameObject frontPrefab; // El prefab de "front" que deseas instanciar
    public int cantidadFronts = 6; // El n�mero de "fronts" a generar
    public GameObject colorIndicatorPrefab;
    public Vector3 rangoInicio; // La posici�n de inicio del rango en el eje x
    public Vector3 rangoFin; // La posici�n de fin del rango en el eje x
    public float distanciaMinima = 20f; // Distancia m�nima entre "fronts"

    public Color colorQ = Color.red;
    public Color colorW = Color.green;
    public Color colorE = Color.blue;

    private List<GameObject> frontsGenerados = new List<GameObject>(); // Almacena los "fronts" generados

    private void Start()
    {
        GenerateFronts();
    }

    private void GenerateFronts()
    {
        for (int i = 0; i < cantidadFronts; i++)
        {
            float randomX = Random.Range(rangoInicio.x, rangoFin.x);
            float randomZ = Random.Range(rangoInicio.z, rangoFin.z); // Agrega un valor aleatorio en z

            Vector3 spawnPosition = new Vector3(randomX, rangoInicio.y, randomZ); // Utiliza el nuevo valor aleatorio en z

            // Comprueba la distancia m�nima entre "fronts"
            bool distanciaValida = true;
            foreach (var front in frontsGenerados)
            {
                if (Vector3.Distance(spawnPosition, front.transform.position) < distanciaMinima)
                {
                    distanciaValida = false;
                    break;
                }
            }

            if (distanciaValida)
            {
                GameObject newFront = Instantiate(frontPrefab, spawnPosition, Quaternion.identity);

                // Asigna colores espec�ficos a cada tecla
                if (i % 3 == 0)
                {
                    newFront.GetComponent<Renderer>().material.color = colorQ;
                }
                else if (i % 3 == 1)
                {
                    newFront.GetComponent<Renderer>().material.color = colorW;
                }
                else
                {
                    newFront.GetComponent<Renderer>().material.color = colorE;
                }

                frontsGenerados.Add(newFront);

                // Instancia el indicador de color sobre el "front"
                GameObject colorIndicator = Instantiate(colorIndicatorPrefab, newFront.transform.position + Vector3.up * 2f, Quaternion.identity);
                colorIndicator.GetComponent<Renderer>().material.color = newFront.GetComponent<Renderer>().material.color;
            }
            else
            {
                // Si la distancia no es v�lida, intenta nuevamente con una nueva posici�n
                i--;
            }
        }
    }
}
