using UnityEngine;
using TMPro;

public class MostrarMarcador : MonoBehaviour
{
    public TMP_Text marcador;
    public int puntuacionActual;
    private bool puntosDePetaGlobosAgregados = false;
    private bool puntosDeCarreraCaballosAgregados = false;

    void Start()
    {
        EstablecerPuntuacionInicial();
    }

    void Update()
    {
        int pMinijuego1 = PlayerPrefs.GetInt("PuntuacionMinijuego1", 0);
        int pMinijuego2 = PlayerPrefs.GetInt("PuntuacionMinijuego2", 0);

        if (!puntosDePetaGlobosAgregados)
        {
            puntuacionActual += pMinijuego1;
            puntosDePetaGlobosAgregados = true;
        }

        if (!puntosDeCarreraCaballosAgregados)
        {
            puntuacionActual += pMinijuego2;
            puntosDeCarreraCaballosAgregados = true;
        }

        ActualizarMarcador(puntuacionActual);
    }

    void EstablecerPuntuacionInicial()
    {
        puntuacionActual = 0;
        ActualizarMarcador(puntuacionActual);
    }

    public void ActualizarMarcador(int nuevaPuntuacion)
    {
        marcador.text = nuevaPuntuacion.ToString();
    }

    public void RestarPuntuacion(int puntosPremio)
    {
        // Resta puntos a la puntuación actual
        puntuacionActual -= puntosPremio;

        // Actualiza el marcador después de restar puntos
        ActualizarMarcador(puntuacionActual);

    }
}
