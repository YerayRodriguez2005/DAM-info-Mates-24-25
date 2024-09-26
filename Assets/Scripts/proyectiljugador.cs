using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectiljugador : MonoBehaviour
{
    private float vel;
    private Vector2 maxpantalla;

    // Start is called before the first frame update
    void Start()
    {
        vel = 13;
        maxpantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posactual = transform.position;
        posactual = posactual + new Vector2(0,1) *vel * Time.deltaTime;
        transform.position = posactual; 
        if (transform.position.y > maxpantalla.y) {
            Destroy(gameObject);
        }
    }
}
