using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CambioEscena : MonoBehaviour
{
    public TMP_InputField InsertarNombre;

    public void AlmacenarYCambiarEscena()
    {
        string nombre = InsertarNombre.text;

        if (string.IsNullOrEmpty(nombre))
        {
            Debug.LogError("El nombre no puede estar vac�o.");
            return;
        }

        // Almacena el nombre en PlayerPrefs
        PlayerPrefs.SetString("NombreJugador", nombre);

        // Cambia a la siguiente escena
        SceneManager.LoadScene("ChurrosYPorras");
    }

    // M�todo para mostrar mensajes de advertencia (opcional)
    private void MostrarMensaje(string mensaje)
    {
        Debug.Log("Mensaje de advertencia: " + mensaje);
        // Puedes implementar aqu� la l�gica para mostrar un mensaje en tu UI, activar un objeto Canvas, etc.
    }

}
