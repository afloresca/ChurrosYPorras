using UnityEngine;
using TMPro;

public class MostrarNombre : MonoBehaviour
{
    public TMP_Text Nombre;

    void Start()
    {
        // Recupera el nombre almacenado en PlayerPrefs
        string nombre = PlayerPrefs.GetString("NombreJugador", "Player1");

        // Muestra el nombre en un TextMeshPro Text (o donde prefieras)
        Nombre.text = "" + nombre + "";
    }
}