using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorScript : MonoBehaviour
{
    // --- Prefabs ---
    public GameObject obstaculoPrefab; // El par de pinchos principal
    public GameObject monedaPrefab;    // La moneda

    // --- Temporizador ---
    public float tiempoEntreSpawns = 2f;
    private float temporizador = 0f;

    // --- Alturas Obstáculo Principal (El hueco) ---
    public float alturaMinima = -2f;
    public float alturaMaxima = 2f;

    // --- Alturas Moneda (Toda la pantalla) ---
    public float alturaMinimaMoneda = -4f;
    public float alturaMaximaMoneda = 4f;

    // --- ¡AÑADE ESTAS DOS LÍNEAS! ---
    [Header("Ajustes de Seguridad de la Moneda")]
    public float tamanoDelHueco = 6f; // IMPORTANTE: El tamaño del hueco de tu prefab
    public float tamanoDelPincho = 1f; // El tamaño (alto) de tu pincho

    // --- Probabilidad Moneda (Opcional) ---
    // (Puedes borrar esta línea y el 'if' de abajo si quieres que SIEMPRE salga una)
    [Range(0f, 1f)] // Esto crea un slider en el Inspector
    public float probabilidadMoneda = 0.7f; // 0.7 = 70% de probabilidad


    // Update se llama en cada fotograma
    void Update()
    {
        // Acumulamos el tiempo
        temporizador += Time.deltaTime;

        // Si ha pasado el tiempo suficiente
        if (temporizador >= tiempoEntreSpawns)
        {
            // Generamos las cosas
            GenerarCosas();

            // Reiniciamos el temporizador
            temporizador = 0f;
        }
    }

    // Función para crear el obstáculo y la moneda
    // Función para crear el obstáculo y la moneda
    void GenerarCosas()
    {
        // --- 1. LÓGICA DE LOS PINCHOS (El par principal) ---

        // Calculamos la altura aleatoria para el hueco
        float alturaAleatoriaObstaculo = Random.Range(alturaMinima, alturaMaxima);

        // Creamos la posición para los pinchos
        Vector3 posicionSpawnObstaculo = new Vector3(transform.position.x, alturaAleatoriaObstaculo, 0);

        // Creamos el par de pinchos
        Instantiate(obstaculoPrefab, posicionSpawnObstaculo, Quaternion.identity);


        // --- 2. LÓGICA DE LA MONEDA (Con probabilidad) ---

        // Comprobamos si, según la probabilidad, debe salir una moneda
        if (Random.value <= probabilidadMoneda)
        {
            // --- INICIO DE LA LÓGICA DE SEGURIDAD ---

            // 1. Calculamos los bordes del hueco basándonos en la altura del obstáculo
            float bordeInferiorHueco = alturaAleatoriaObstaculo - (tamanoDelHueco / 2);
            float bordeSuperiorHueco = alturaAleatoriaObstaculo + (tamanoDelHueco / 2);

            // 2. Calculamos la altura aleatoria para la moneda
            float alturaAleatoriaMoneda = Random.Range(alturaMinimaMoneda, alturaMaximaMoneda);

            // 3. Comprobamos si la moneda está en una ZONA PELIGROSA

            // ¿Está en el pincho de abajo? 
            // (Entre el borde inferior y el fin del pincho)
            bool enPinchoDeAbajo = (alturaAleatoriaMoneda <= bordeInferiorHueco) &&
                                   (alturaAleatoriaMoneda >= bordeInferiorHueco - tamanoDelPincho);

            // ¿Está en el pincho de arriba?
            // (Entre el borde superior y el fin del pincho)
            bool enPinchoDeArriba = (alturaAleatoriaMoneda >= bordeSuperiorHueco) &&
                                   (alturaAleatoriaMoneda <= bordeSuperiorHueco + tamanoDelPincho);


            // 4. Solo creamos la moneda SI NO ESTÁ en ninguna zona peligrosa
            if (!enPinchoDeAbajo && !enPinchoDeArriba)
            {
                // ¡Es seguro! Creamos la moneda
                Vector3 posicionSpawnMoneda = new Vector3(transform.position.x, alturaAleatoriaMoneda, 0);
                Instantiate(monedaPrefab, posicionSpawnMoneda, Quaternion.identity);
            }
            // Si está en una zona peligrosa, esta función simplemente
            // termina y no se crea ninguna moneda en este ciclo.

            // --- FIN DE LA LÓGICA DE SEGURIDAD ---
        }
    }
}