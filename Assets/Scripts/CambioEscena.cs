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
            Debug.LogError("El nombre no puede estar vacío.");
            return;
        }
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        //Almacena el nombre en playersPref
        PlayerPrefs.SetString("NombreJugador", nombre);

        // Cambia a la siguiente escena
        SceneManager.LoadScene("ChurrosYPorras");
    }

    // Método para mostrar mensajes de advertencia (opcional)
    private void MostrarMensaje(string mensaje)
    {
        Debug.Log("Mensaje de advertencia: " + mensaje);
        // Puedes implementar aquí la lógica para mostrar un mensaje en tu UI, activar un objeto Canvas, etc.
    }
}
