using UnityEngine;
using TMPro;

public class MostrarMarcador : MonoBehaviour
{
    public TMP_Text Marcador;
    public int puntuacionActual;
    private bool puntosDePetaGlobosAgregados = false;
    private bool puntosDeCarreraCaballosAgregados = false;


    void Start()
    {
        EstablecerPuntuacionInicial();
    }

    void Update()
    {
        if (!puntosDePetaGlobosAgregados)
        {
            int pMinijuego1 = PlayerPrefs.GetInt("PuntuacionMinijuego1", 0);


            puntuacionActual += pMinijuego1;
            ActualizarMarcador(puntuacionActual);

            // Marca los puntos de PetaGlobos como ya agregados
            puntosDePetaGlobosAgregados = true;
        }

        if (!puntosDeCarreraCaballosAgregados)
        {
            int pMinijuego2 = PlayerPrefs.GetInt("PuntuacionMinijuego2", 0);


            puntuacionActual += pMinijuego2;
            ActualizarMarcador(puntuacionActual);

            // Marca los puntos de PetaGlobos como ya agregados
            puntosDeCarreraCaballosAgregados = true;
        }
    }

    void EstablecerPuntuacionInicial()
    {
        puntuacionActual = 0;
        ActualizarMarcador(puntuacionActual);
    }

    public void ActualizarMarcador(int nuevaPuntuacion)
    {
        Marcador.text = nuevaPuntuacion.ToString();
    }

    public void RestarPuntuacion(int puntosPremio)
    {
        // Resta puntos a la puntuación actual
        puntuacionActual -= puntosPremio;

        // Actualiza el marcador después de restar puntos
        ActualizarMarcador(puntuacionActual);

    }
}
