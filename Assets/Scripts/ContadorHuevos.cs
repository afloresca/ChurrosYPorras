using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorHuevos : MonoBehaviour
{
    private int contador = 0;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        // Obtén el componente TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogError("No se encontró TextMeshProUGUI en el objeto.");
        }

        ActualizarTexto();
    }

    public void IncrementarContador()
    {
        // Incrementa el contador al tocar un huevo
        contador++;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        // Actualiza el texto en el componente TextMeshProUGUI
        if (textMeshPro != null)
        {
            textMeshPro.text = ": " + contador;
        }
    }
}