using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reventar : MonoBehaviour
{
    public int scoreValue = 10; // Valor de la puntuación por reventar un globo

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que colisionamos es la bala

       if (other.gameObject.name.Contains("RealBullet"))
        {
            // Destruir el globo que colisiona con la bala
            Destroy(gameObject); // Esta línea de código destruirá el GameObject actual que tiene el script Reventar

            // Incrementar la puntuación
            GameManager.instance.AddScore(scoreValue);
        }
    }
}
