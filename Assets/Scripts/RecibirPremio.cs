using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections; // Agrega esta línea para usar IEnumerator

public class RecibirPremio : MonoBehaviour
{
    public MostrarMarcador marcador;
    public int puntosPremio = 0;

    public void OnBotonPremiosClick()
    {
        if (marcador.puntuacionActual >= puntosPremio)
        {
            marcador.RestarPuntuacion(puntosPremio);


            Debug.Log($"Enhorabuena, disfruta de tu premio. Puntos restantes: {marcador.puntuacionActual}.\nEl juego ha terminado");

            SpawnConfetti sc = gameObject.AddComponent<SpawnConfetti>();
            sc.Spawn();
            // Cierra la aplicación después de unos segundos
            StartCoroutine(CerrarJuegoDespuesDeEspera(5f));
        }
        else
        {
            Debug.Log("No tienes puntos suficientes para este premio. ¡Sigue jugando!");
        }
    }

   
    IEnumerator CerrarJuegoDespuesDeEspera(float tiempoDeEspera)
    {
        yield return new WaitForSeconds(tiempoDeEspera);

        // Cierra la aplicación después de esperar unos segundos
        Application.Quit();
    }
}
