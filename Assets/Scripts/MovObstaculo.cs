using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    // Variable para la velocidad, la ajustaremos desde el Inspector
    public float velocidad = 3f;

    // Update se llama en cada fotograma
    void Update()
    {
        // Esto es lo que ya tenías:
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        // --- ¡AÑADE ESTO! ---
        // Comprobamos si el obstáculo se ha salido de la pantalla
        // (ej. si su posición 'X' es menor que -10)
        if (transform.position.x < -10f)
        {
            // Si es así, nos destruimos a nosotros mismos
            Destroy(gameObject);
        }
    }
}