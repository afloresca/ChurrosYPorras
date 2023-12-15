using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAHorseControl : MonoBehaviour
{
    public float speed = 5f;
    public Transform finishLine;
    public Transform startPoint;
    private bool raceStarted = false;

    void Update()
    {
        if (raceStarted)
        {
            MoveTowardsFinishLine();
        }
    }

    public void StartRace()
    {
        raceStarted = true;
    }

    private void MoveTowardsFinishLine()
    {
        transform.position = Vector3.MoveTowards(transform.position, finishLine.position, speed * Time.deltaTime);

        if (transform.position == finishLine.position)
        {
            raceStarted = false;
            // El caballo ha llegado a la meta y se detiene.
        }
    }

    public void ResetPosition()
    {
        transform.position = startPoint.position;
        // Restablece otras propiedades necesarias, como la rotación si es necesario.
    }
}

