using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private List<GameObject> objetosColisionados = new List<GameObject>();
    private int puntos = 0;

    public SpawnFronts spawnFronts;

    private void Start()
    {
        // Asigna la referencia al script SpawnFronts
        spawnFronts = FindObjectOfType<SpawnFronts>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckCollisionAndScore(spawnFronts.colorQ);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            CheckCollisionAndScore(spawnFronts.colorW);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CheckCollisionAndScore(spawnFronts.colorE);
        }
    }

    private void CheckCollisionAndScore(Color colorTecla)
    {
        foreach (var front in GameObject.FindGameObjectsWithTag("objetovalido"))
        {
            Collider frontCollider = front.GetComponent<Collider>();

            // Verifica si el "front" tiene un componente Collider
            if (frontCollider != null && frontCollider.CompareTag("objetovalido"))
            {
                // Verifica si el Collider está tocando el Box Collider del objeto "front"
                if (ColliderIntersects(frontCollider, GetComponent<Collider>()))
                {
                    Renderer frontRenderer = front.GetComponent<Renderer>();
                    if (frontRenderer != null && frontRenderer.material.color == colorTecla)
                    {
                        puntos++;
                        Debug.Log("Puntos: " + puntos);
                        break;
                    }
                }
            }
        }
    }

    // Método para verificar si dos colliders están intersectados
    private bool ColliderIntersects(Collider collider1, Collider collider2)
    {
        // Obtiene las bounds de ambos colliders
        Bounds bounds1 = collider1.bounds;
        Bounds bounds2 = collider2.bounds;

        // Verifica si las bounds están intersectadas
        return bounds1.Intersects(bounds2);
    }
}
