using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Generadornumeros : MonoBehaviour
{
    [SerializeField] private GameObject prefabnumero;
    // Start is called before the first frame update
    void Start()
    {
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        InvokeRepeating("generarnumero",1f,2f);   
    }
    private void generarnumero() {
        GameObject numero = Instantiate(prefabnumero);
        numero.transform.position = new Vector2( Random.Range(minPantalla.x,maxPantalla.x), maxPantalla.y);

    }
    private Vector2 minPantalla, maxPantalla;
    // Update is called once per frame
    void Update()
    {
        
    }
}
