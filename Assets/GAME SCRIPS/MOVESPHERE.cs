using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento de la esfera

    // Start is called before the first frame update
    void Start()
    {
        // Puedes inicializar cosas aquí si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve la esfera hacia adelante a la velocidad especificada
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
