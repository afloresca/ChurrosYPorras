using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalB = 12;
    public int currentScore = 0;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScoreText();

        if (totalB-- <= 1)
        {
            // Aquí podrías añadir efectos de sonido, animaciones, etc., relacionados con obtener puntos.
            // Por ejemplo, cuando se han cargado todos los globos, salen confetis y esperas 10 segundos.
            // SpawnConfetti sc = new SpawnConfetti();
            SpawnConfetti sc = gameObject.AddComponent<SpawnConfetti>();
            sc.Spawn();
            StartCoroutine(CerrarJuegoDespuesDeEspera(5f));
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    IEnumerator Final(int seg)
    {
        // Guardar la puntuación acumulativa en PlayerPrefs
        PlayerPrefs.SetInt("PuntuacionMinijuego1", currentScore);
        yield return new WaitForSeconds(seg);
        SceneManager.LoadScene("ChurrosYPorras");
    }

    IEnumerator CerrarJuegoDespuesDeEspera(float tiempoDeEspera)
    {
        yield return new WaitForSeconds(tiempoDeEspera);

        // Cierra la aplicación después de esperar unos segundos
        Application.Quit();
    }
}

