using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ¡MUY IMPORTANTE! Añade esta línea para poder usar la UI

public class GameManagerScript : MonoBehaviour
{
    // --- Singleton Pattern ---
    // Esto crea una variable "publica" del script
    // para que otros scripts puedan llamarlo fácilmente.
    public static GameManagerScript Instance;

    void Awake()
    {
        // Esto es el patrón Singleton.
        // Se asegura de que SOLO exista un GameManager.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // --- Fin del Singleton ---


    // Variable para la puntuación
    public int puntos = 0;

    // Variable para conectar nuestro texto de la UI
    public TextMeshProUGUI textoPuntuacion;


    // Función pública para que otros scripts la llamen
    public void SumarPunto()
    {
        puntos = puntos + 1; // Suma 1 a la variable 'puntos'

        // Actualiza el texto de la pantalla
        textoPuntuacion.text = "Puntos: " + puntos;
    }
}