using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class RaceManager : MonoBehaviour
{
    private List<string> orderOfArrival = new List<string>();
    public Marcador marcador; // Referencia al script del marcador
    private int totalHorses; // Total de caballos en la carrera

    private void Start()
    {
        // Inicializa totalHorses con el número de caballos que participan
        totalHorses = FindObjectsOfType<AIAHorseControl>().Length + FindObjectsOfType<PlayerHorseControl2>().Length;
    }

    public void BeginRace()
    {
        // Lógica para manejar el inicio de la carrera
        // Reinicia la lista de orden de llegada para una nueva carrera
        orderOfArrival.Clear();
    }

    public void RecordFinish(string horseName)
    {
        orderOfArrival.Add(horseName);

        // Verifica si todos los caballos han llegado
        if (orderOfArrival.Count == totalHorses)
        {
            // Todos los caballos han llegado, la carrera ha terminado
            UpdateScores();
        }
    }

    private void UpdateScores()
    {
        for (int i = 0; i < orderOfArrival.Count; i++)
        {
            UnityEngine.Debug.Log("Caballo " + orderOfArrival[i] + " en posición " + (i + 1));
            if (orderOfArrival[i] == "Horse_003") // Reemplaza con el nombre del caballo del jugador
            {
                int points = CalculatePoints(i + 1);
                UnityEngine.Debug.Log("Asignando " + points + " puntos al caballo del jugador");
                marcador.ActualizarMarcador(marcador.score + points); // Asegúrate de que se suman los puntos
                break; // Sale del bucle una vez que se encuentra y actualiza el caballo del jugador
            }
        }
    }



    private int CalculatePoints(int position)
    {
        switch (position)
        {
            case 1: return 10;
            case 2: return 8;
            case 3: return 6;
            case 4: return 4;
            default: return 2;
        }
    }

    public void EndRace()
    {
        // Lógica para manejar el final de la carrera
        // Aquí podrías realizar cualquier limpieza o preparación para una nueva carrera
    }
}


