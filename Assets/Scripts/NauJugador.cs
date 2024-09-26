using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    // Variable para almacenar la velocidad de movimiento de la nave
    private float vel;
    private Vector2 minPantalla;
    private Vector2 maxPantalla;


    [SerializeField] private GameObject prefabProjectil;

    // Start es llamado una vez, al inicio del juego
    void Start()
    {
        // Inicializamos la velocidad de la nave a 8
        vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        float tama�onavex = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float tama�onavey = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //minPantalla.x = (float)(minPantalla.x + -0.75);
        minPantalla.x += tama�onavex;
        maxPantalla.x -= tama�onavex;
        minPantalla.y += tama�onavey;
        maxPantalla.y -= tama�onavey;
    }

    // Update es llamado en cada frame del juego
    void Update()
    {
        MovimentNau();
        DisparaProjectil();

    }

    private void MovimentNau()
    {
        // Obtenemos la direcci�n horizontal (izquierda/derecha) seg�n la entrada del jugador
        float direccionIndicadaX = Input.GetAxisRaw("Horizontal");
        // Obtenemos la direcci�n vertical (arriba/abajo) seg�n la entrada del jugador
        float direccionIndicadaY = Input.GetAxisRaw("Vertical");
        // Creamos un vector con la direcci�n indicada por el jugador
        Vector2 direccionIndicada = new Vector2(direccionIndicadaX, direccionIndicadaY).normalized;
        // Obtenemos la posici�n actual del objeto
        Vector2 nuevoPosi = transform.position;
        // Calculamos la nueva posici�n sumando la direcci�n por la velocidad y el tiempo entre frames
        nuevoPosi = nuevoPosi + direccionIndicada * vel * Time.deltaTime;

        nuevoPosi.x = Mathf.Clamp(nuevoPosi.x, minPantalla.x, maxPantalla.x);
        nuevoPosi.y = Mathf.Clamp(nuevoPosi.y, minPantalla.y, maxPantalla.y);

        //asignar la nueva posici�n calculada a la nave
        transform.position = nuevoPosi;
    }

    private void DisparaProjectil()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject Proyectil = Instantiate(prefabProjectil);
            Proyectil.transform.position = transform.position;
        }
    }
}