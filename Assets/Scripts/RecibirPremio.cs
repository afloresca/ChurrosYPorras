using UnityEngine;
using UnityEngine.UI;

public class RecibirPremio : MonoBehaviour
{
    public Marcador marcador;  // Asigna tu objeto de marcador desde el Inspector
    public int puntosPremio;  // El costo del premio que se resta del marcador

    void Start()
    {
        // Asegúrate de que el marcador esté asignado
        if (marcador == null)
        {
            Debug.LogError("El objeto de marcador no está asignado en el Inspector.");
        }
    }

    // Método que se llama cuando se presiona el botón
    public void OnBotonPremiosClick()
    {
        // Verifica si el jugador tiene suficientes puntos para el premio
        if (marcador.score >= puntosPremio)
        {
            // Resta el costo del premio del marcador
            int nuevoPuntaje = marcador.score - puntosPremio;
            marcador.ActualizarMarcador(nuevoPuntaje);
        }
        else
        {
            Debug.Log("No tienes puntos suficientes para este premio");
        }
    }
}
