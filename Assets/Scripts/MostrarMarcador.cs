using UnityEngine;
using TMPro;

public class MostrarMarcador : MonoBehaviour
{
    public TMP_Text marcador;
    public int puntuacionActual;
    private bool puntosDePetaGlobosAgregados = false;
    private bool puntosDeCarreraCaballosAgregados = false;
    private bool puntosDeHuevosAgregados = false;

    void Start()
    {
        EstablecerPuntuacionInicial();
    }

    void Update()
    {
        int pMinijuego1 = PlayerPrefs.GetInt("PuntuacionMinijuego1", 0);
        int pMinijuego2 = PlayerPrefs.GetInt("PuntuacionMinijuego2", 0);
        int pMinijuego3 = PlayerPrefs.GetInt("PuntuacionMinijuego3", 0);

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

        if (!puntosDeHuevosAgregados)
        {
        puntuacionActual += pMinijuego3;
        puntosDeHuevosAgregados = true;
        }

    ActualizarMarcador(puntuacionActual);

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
        // Resta puntos a la puntuaci�n actual
        puntuacionActual -= puntosPremio;

        // Actualiza el marcador despu�s de restar puntos
        ActualizarMarcador(puntuacionActual);

    }
}
