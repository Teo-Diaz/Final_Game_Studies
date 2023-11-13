using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFronts : MonoBehaviour
{
    public GameObject frontPrefab; // El prefab de "front" que deseas instanciar
    public int cantidadFronts = 6; // El n�mero de "fronts" a generar
    public Vector3 rangoInicio; // La posici�n de inicio del rango en el eje x
    public Vector3 rangoFin; // La posici�n de fin del rango en el eje x
    public float distanciaMinima = 20f; // Distancia m�nima entre "fronts"

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
            Vector3 spawnPosition = new Vector3(randomX, rangoInicio.y, rangoInicio.z);

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
                GameObject nuevoFront = Instantiate(frontPrefab, spawnPosition, Quaternion.identity);
                frontsGenerados.Add(nuevoFront);
            }
            else
            {
                // Si la distancia no es v�lida, intenta nuevamente con una nueva posici�n
                i--;
            }
        }
    }
}