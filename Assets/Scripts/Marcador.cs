using UnityEngine;
using UnityEngine.UI;
using TMPro;

public  class Marcador : MonoBehaviour
{
    public TextMeshProUGUI textoMarcador;
    public int score = 0;

    // Método para actualizar el marcador
    public void ActualizarMarcador(int nuevoPuntaje)
    {
        score = nuevoPuntaje;
        textoMarcador.text = score.ToString();
    }
}
