using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numero : MonoBehaviour
{
    private float _vel;
    private Vector2 minPantalla;
    public Sprite[] PossiNum = new Sprite[10];
    private int valorNumero;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 5;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        System.Random aleatorio = new System.Random();
        valorNumero = aleatorio.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite= PossiNum[valorNumero];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos = novaPos + new Vector2(0, -1) * _vel * Time.deltaTime;
        transform.position= novaPos;
        if (transform.position.y < minPantalla.y) {

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D ObjecteTocat)
    {
        if (ObjecteTocat.tag == "ProyectilJugador" || ObjecteTocat.tag == "NauJugador")
        {
            Destroy(gameObject);
        }
    }
}
