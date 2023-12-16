using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalB = 12;
    public int currentScore = 0;
    public Text scoreText; // Referencia al texto en pantalla para mostrar la puntuación

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
        /*
         * Aquí podrías añadir efectos de sonido, animaciones, etc., relacionados con obtener puntos.
         * Por ejemplo Cuando llega se ha cargado todos los globos salen confetis y espera 10 segundos
         */
        if (totalB-- <= 1)
        {
            //SpawnConfetti sc = new SpawnConfetti();
            SpawnConfetti sc = gameObject.AddComponent<SpawnConfetti>();
            sc.Spawn();
            StartCoroutine(final(10));
  
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    IEnumerator final(int seg)
    {
        yield return new WaitForSeconds(seg);
        SceneManager.LoadScene("ChurrosYPorras");
    }
}
