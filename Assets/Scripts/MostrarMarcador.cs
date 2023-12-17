using UnityEngine;
using UnityEngine.UI;
using TMPro;

public  class MostrarMarcador : MonoBehaviour
{
    public TMP_Text Marcador;
    public int score = 0;


    void Start()
    {
        EstablecerPuntuacionInicial();
    }

    void Update()
    {

    }

    public void EstablecerPuntuacionInicial()
    {
        score = 50; // Establece la puntuación inicial que desees
        ActualizarMarcador(); // Actualiza el marcador con la puntuación inicial
    }


    // Método para actualizar el marcador
    public void ActualizarMarcador()
    {
        Marcador.text = score.ToString();
    }
}
