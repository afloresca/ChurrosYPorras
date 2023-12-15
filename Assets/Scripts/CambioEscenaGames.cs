using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CambioEscenaGames : MonoBehaviour
{
    public TMP_Text Nombre;

    public Timer timerScript;

    public void AlmacenarYCambiarJuego(string nombreJuego)
    {
        string nombre = Nombre.text;

        // Almacena el nombre en PlayerPrefs
        PlayerPrefs.SetString("NombreJugador", nombre);

        // Guarda el tiempo antes de cambiar de escena
        timerScript.GuardarTiempo();

        // Cambia a la escena especificada
        SceneManager.LoadScene(nombreJuego);
    }
}


