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
        // Movemos este objeto (el "Obstaculo") hacia la izquierda
        // usando 'transform.Translate'.
        // Vector2.left es lo mismo que (-1, 0)
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
}