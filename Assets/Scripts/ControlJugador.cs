using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// El nombre de la clase debe ser EXACTO al nombre del archivo (ControlJugador)
public class ControlJugador : MonoBehaviour
{
    // Esta variable la podremos cambiar desde el Inspector de Unity
    // para ajustar la fuerza del "salto" del globo.
    public float fuerzaSalto = 5f;

    // Esta variable es para guardar la referencia al componente de f�sicas
    private Rigidbody2D rb;


    // Start se llama una sola vez, al principio del juego
    void Start()
    {
        // Buscamos el componente Rigidbody2D que est� EN EL MISMO
        // GameObject que este script, y lo guardamos en nuestra variable 'rb'.
        // (Visto en Tema 9)
        rb = GetComponent<Rigidbody2D>();
 
    }

    // Update se llama en cada fotograma
    void Update()
    {
        // Comprobamos si el jugador ha pulsado la barra espaciadora
        // o ha hecho clic con el bot�n izquierdo del rat�n (bot�n 0)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // Si lo ha hecho, llamamos a nuestra funci�n de saltar
            Saltar();
        }
    }

    // Creamos nuestra propia funci�n para que el c�digo sea m�s ordenado
    void Saltar()
    {
        // Esta es la f�sica clave del "Flappy Bird".
        // En lugar de "a�adir" fuerza, "establecemos" la velocidad vertical (Y)
        // a un valor fijo (nuestra 'fuerzaSalto'), reseteando la ca�da.
        // La velocidad horizontal (X) la dejamos como estaba (que ser� 0).
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
    }

    // Esta función se llama automáticamente cuando nuestro 'Collider 2D'
    // choca con OTRO 'Collider 2D'.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobamos si el objeto con el que hemos chocado
        // tiene el Tag "Obstaculo".
        if (collision.gameObject.tag == "Obstaculo")
        {
            // Si chocamos, de momento escribimos en la consola
            Debug.Log("¡CHOQUE! Has perdido.");

            // Y cargamos la escena de Fin de Partida
            SceneManager.LoadScene("FinPartida");
        }
    }
}