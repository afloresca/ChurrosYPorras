using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importa UnityEngine.UI para trabajar con Text

public class contador_2 : MonoBehaviour
{
    public Text contadorText; // Arrastra el objeto de texto (UI Text) aquí en el Inspector
    private int puntaje = 0;

    private void Start()
    {
        ActualizarContador();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que ingresó en el Trigger tiene la etiqueta "PlayerHorse"
        if (other.CompareTag("PlayerHorse"))
        {
            puntaje += 10; // Incrementa el puntaje en 10
            ActualizarContador();
        }
    }

    private void ActualizarContador()
    {
        // Actualiza el texto del contador con el puntaje actual
        contadorText.text = "Puntaje: " + puntaje.ToString();
    }
}
