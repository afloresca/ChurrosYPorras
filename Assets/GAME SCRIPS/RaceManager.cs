using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    private List<string> orderOfArrival = new List<string>();
    public MarcadorCaballos marcadorCaballos; // Referencia al script del marcador
    private int totalHorses; // Total de caballos en la carrera
    private int puntosTotales = 0;

    // Este es el método Start donde debes incluir el código
    private void Start()
    {
        // Calcula el número total de caballos en la carrera
        totalHorses = FindObjectsOfType<AIAHorseControl>().Length + FindObjectsOfType<PlayerHorseControl2>().Length;
        UnityEngine.Debug.Log("Total de caballos en la carrera: " + totalHorses);

        // Otra lógica de inicialización si es necesaria
    }

    public void BeginRace()
    {
        // Lógica para manejar el inicio de la carrera
        // Reinicia la lista de orden de llegada para una nueva carrera
        orderOfArrival.Clear();
        {
            orderOfArrival.Clear();
            UnityEngine.Debug.Log("Comenzando una nueva carrera. Lista de orden de llegada limpiada.");
            // Otras acciones al comenzar la carrera
        }
    }


    public void RecordFinish(string horseName)
    {
        orderOfArrival.Add(horseName);
        UnityEngine.Debug.Log("Caballo registrado: " + horseName + ". Posición: " + orderOfArrival.Count);

        // Verifica si todos los caballos han llegado
        if (orderOfArrival.Count == totalHorses)
        {
            UnityEngine.Debug.Log("Todos los caballos han llegado. Fin de la carrera.");
            UpdateScores();
            EndRace(); // Llamada a EndRace aquí
        }
    }


    public void UpdateScores()
    {
        for (int i = 0; i < orderOfArrival.Count; i++)
        {
            UnityEngine.Debug.Log("Caballo " + orderOfArrival[i] + " en posición " + (i + 1));
            if (orderOfArrival[i] == "Horse_003") // Reemplaza con el nombre del caballo del jugador
            {
                int points = CalculatePoints(i + 1);
                UnityEngine.Debug.Log("Asignando " + points + " puntos al caballo del jugador");
                marcadorCaballos.AgregarPuntos(points); // Utiliza el método para agregar puntos
                break; // Sale del bucle una vez que se encuentra y actualiza el caballo del jugador
            }
        }
    }



    private int CalculatePoints(int position)
    {
        switch (position)
        {
            case 1: return 120;
            case 2: return 60;
            case 3: return 30;
            case 4: return 15;
            default: return 60;
        }
    }

    public void EndRace()
    {
        puntosTotales = marcadorCaballos.ObtenerPuntajeActual();
        UnityEngine.Debug.Log("Finalizando la carrera actual. Puntos totales: " + puntosTotales);

        // Guardar la puntuación acumulativa en PlayerPrefs
        PlayerPrefs.SetInt("PuntuacionMinijuego2", puntosTotales);
        UnityEngine.Debug.Log("Puntuación guardada en PlayerPrefs: " + PlayerPrefs.GetInt("PuntuacionMinijuego2"));

        // Prepararse para cambiar de escena
        StartCoroutine(CambiarDeEscenaDespuesDeEspera(15f));
        UnityEngine.Debug.Log("Preparando para cambiar de escena en 5 segundos.");
    }

    IEnumerator CambiarDeEscenaDespuesDeEspera(float tiempoDeEspera)
    {
        yield return new WaitForSeconds(tiempoDeEspera);

        // Cambia a la escena "ChurrosYPorras" después de esperar unos segundos
        UnityEngine.Debug.Log("Cambiando a la escena 'ChurrosYPorras'.");
        SceneManager.LoadScene("ChurrosYPorras");
    }

}


