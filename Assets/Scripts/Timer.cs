using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    public float tiempo = 0;
    public TextMeshProUGUI textoTimerPro;
    private static Timer instance;

    public static Timer Instance
    {
        get
        {
            if (instance == null)
            {
                // Si no hay una instancia existente, busca en la escena
                instance = FindObjectOfType<Timer>();

                // Si aún no hay instancia, crea una nueva GameObject y añade el script
                if (instance == null)
                {
                    GameObject obj = new GameObject("Timer");
                    instance = obj.AddComponent<Timer>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        TimeSpan tiempoFormato = TimeSpan.FromSeconds(tiempo);
        string tiempoFormateado = string.Format("{0:D2}:{1:D2}", tiempoFormato.Minutes, tiempoFormato.Seconds);

        textoTimerPro.text = tiempoFormateado;
    }

    // Método para guardar el tiempo antes de cambiar de escena
    public void GuardarTiempo()
    {
        PlayerPrefs.SetFloat("TiempoGuardado", tiempo);
        PlayerPrefs.Save();
    }

    // Método para cargar el tiempo al cambiar de escena
    public void CargarTiempo()
    {
        tiempo = PlayerPrefs.GetFloat("TiempoGuardado", 0f);
    }

    public float GetTiempoTranscurrido()
    {
        return tiempo;
    }

}

