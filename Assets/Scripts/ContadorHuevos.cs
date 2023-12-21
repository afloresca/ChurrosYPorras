using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ContadorHuevos : MonoBehaviour
{
    private int contador = 0;
    private TextMeshProUGUI textMeshPro;
    public AudioClip[] clipsDeAudio; // Array que contiene los clips de audio
    private AudioSource audioSource;
    public AudioClip felicitacion;
    public AudioClip FF7; 
    public AudioClip musicaFondo;
    private AudioSource musicaFondoAudioSource;

    private void Start()
    {
        // Obtén el componente TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        if (textMeshPro == null)
        {
            Debug.LogError("No se encontró TextMeshProUGUI en el objeto.");
        }

        // Obtén el componente AudioSource directamente (sin buscar en los hijos)
        audioSource = GetComponent<AudioSource>();
        musicaFondoAudioSource = gameObject.AddComponent<AudioSource>(); // Agrega un nuevo AudioSource para la música de fondo


        if (audioSource == null || musicaFondoAudioSource == null)
        {
            // Si no hay un AudioSource adjunto directamente al objeto, muestra un error
            Debug.LogError("No se encontró AudioSource en el objeto.");
        }

        if (musicaFondo != null)
        {                    
            musicaFondoAudioSource.clip = musicaFondo;
            musicaFondoAudioSource.volume = 0.10f;
            musicaFondoAudioSource.loop = true; // Asegúrate de que la música de fondo se repita
            musicaFondoAudioSource.playOnAwake = true;
            musicaFondoAudioSource.Play();
        }

        ActualizarTexto();
    }

    public void IncrementarContador()
    {
        // Incrementa el contador al tocar un huevo
        contador += 10;
        ActualizarTexto();

        // Verifica si el contador es un múltiplo de 50
        if (contador % 50 == 0 && clipsDeAudio.Length > 0)
        {
            ReproducirAudioAleatorio();
        }

        if (contador == 200 && felicitacion != null)
        {
            ReproducirFelicitacion();
            ReproducirFF7();

            // Llama al método LlamarAlmacenarYCambiarEscena después de 10 segundos
            Invoke("LlamarAlmacenarYCambiarEscena", 10f);
        }
    }


    private void ActualizarTexto()
    {
        // Actualiza el texto en el componente TextMeshProUGUI
        if (textMeshPro != null)
        {
            textMeshPro.text = ": " + contador;
        }
    }

    private void ReproducirAudioAleatorio()
    {
        if (audioSource != null && clipsDeAudio.Length > 0)
        {
            int indiceAleatorio = Random.Range(0, clipsDeAudio.Length);
            audioSource.clip = clipsDeAudio[indiceAleatorio];
            audioSource.volume = 1f;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se encontró AudioSource activo y habilitado o no hay clips de audio asignados.");
        }
    }

    private void ReproducirFelicitacion()
    {
        if (audioSource != null && felicitacion != null)
        {
            audioSource.volume = 1.25f;
            audioSource.PlayOneShot(felicitacion);
        }
        else
        {
            Debug.LogWarning("No se encontró AudioSource activo y habilitado o no hay clip de felicitación asignado.");
        }
    }

    private void ReproducirFF7()
    {
        if (audioSource != null && FF7 != null)
        {
            audioSource.volume = 0.10f;
            audioSource.PlayOneShot(FF7);
        }
        else
        {
            Debug.LogWarning("No se encontró AudioSource activo y habilitado o no hay clip de felicitación asignado.");
        }
    }
}
