using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    // Variable para almacenar la velocidad de movimiento de la nave
    private float vel;

    // Start es llamado una vez, al inicio del juego
    void Start()
    {
        // Inicializamos la velocidad de la nave a 8
        vel = 8;
    }

    // Update es llamado en cada frame del juego
    void Update()
    {
        // Obtenemos la dirección horizontal (izquierda/derecha) según la entrada del jugador
        float direccionIndicadaX = Input.GetAxisRaw("Horizontal");
        // Obtenemos la dirección vertical (arriba/abajo) según la entrada del jugador
        float direccionIndicadaY = Input.GetAxisRaw("Vertical");

        // Creamos un vector con la dirección indicada por el jugador
        Vector2 direccionIndicada = new Vector2(direccionIndicadaX, direccionIndicadaY).normalized;

        // Obtenemos la posición actual del objeto
        Vector2 nuevoPosi = transform.position;

        // Calculamos la nueva posición sumando la dirección por la velocidad y el tiempo entre frames
        nuevoPosi = nuevoPosi + direccionIndicada * vel * Time.deltaTime;

        //asignar la nueva posición calculada a la nave

        transform.position = nuevoPosi;
    }
}
