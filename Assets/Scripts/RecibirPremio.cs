using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecibirPremio : MonoBehaviour
{
    public MostrarMarcador marcador;
    public int puntosPremio;
    public Timer timer;

    void Start()
    {
        // Asegúrate de que el marcador esté asignado
        if (marcador == null)
        {
            Debug.LogError("El objeto de marcador no está asignado en el Inspector.");
        }
        else
        {
            marcador.EstablecerPuntuacionInicial(); // Llama al método para establecer la puntuación inicial
        }
    }

    // Método que se llama cuando se presiona el botón
    public void OnBotonPremiosClick()
    {
        // Verifica si el jugador tiene suficientes puntos para el premio
        if (marcador.score >= puntosPremio)
        {
            // Resta el costo del premio del marcador
            marcador.score -= puntosPremio;
            marcador.ActualizarMarcador();
            float tiempoTranscurrido = timer.GetTiempoTranscurrido();

            Debug.Log($"Enhorabuena, disfruta de tu premio. Puntos restantes: {marcador.score}. Tiempo transcurrido: {tiempoTranscurrido} segundos.\nEl juego ha terminado, disfruta de la cerveza");
            Invoke("TerminarJuego", 5f);


        }
        else
        {
            Debug.Log("No tienes puntos suficientes para este premio. ¡ Sigue jugando ! ");
        }
    }

    // Método para manejar el final del juego
    void TerminarJuego()
    {
        Application.Quit();

    }


}
