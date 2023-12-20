using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MarcadorCaballos : MonoBehaviour
{
    public TextMeshProUGUI textoMarcador;  // Referencia pública al componente TextMeshProUGUI
    public int score = 0;  // Variable para almacenar la puntuación

    // Start se llama antes de la primera actualización de frame
    void Start()
    {
        ActualizarMarcador(0);  // Inicia el marcador con 0 puntos
    }

    // Método para agregar puntos al marcador
    public void AgregarPuntos(int puntos)
    {
        score += puntos;  // Suma los puntos a la puntuación actual
        ActualizarMarcador(score);  // Actualiza el marcador con la nueva puntuación
    }

    // Método privado para actualizar el texto del marcador
    public void ActualizarMarcador(int nuevoPuntaje)


    {
        textoMarcador.text = "Puntuación: " + nuevoPuntaje.ToString();  // Actualiza el texto en la interfaz de usuario
    }

    public int ObtenerPuntajeActual()
    {
        return score;
    }

}




