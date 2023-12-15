using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHorseControl2 : MonoBehaviour
{
    public float speed = 5f; // Velocidad del caballo
    public Transform targetDiana; // Asigna la Transform de la diana
    private bool isMoving = false;
    public Camera playerCamera; // Agrega esta línea
    private bool raceFinished = false; // Variable para controlar si la carrera ha terminado
    public Transform finishLine;
    public Transform startPoint;
    private bool raceStarted = false;
    public float maxSpeed = 10f; // Velocidad máxima del caballo
    private float currentSpeed; // Velocidad actual del caballo


    private void Update()
    {
        if (raceStarted && !raceFinished)
        {
            CheckIfAimingAtTarget();
            if (isMoving)
            {
                MoveHorse();
            }
        }
    }

    public void StartRace()
    {
        raceStarted = true;
    }


    private void CheckIfAimingAtTarget()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == targetDiana)
            {
                // El jugador está apuntando directamente a la diana
                currentSpeed = maxSpeed;
                isMoving = true;
            }
            else
            {
                // El jugador no está apuntando directamente a la diana
                currentSpeed = 0; // O podrías establecer esto a una velocidad mínima
                isMoving = false;
            }
        }
        else
        {
            isMoving = false;
        }
    }


    private void MoveHorse()
    {
        transform.position = Vector3.MoveTowards(transform.position, finishLine.position, currentSpeed * Time.deltaTime);
        // Usa currentSpeed en lugar de speed

        if (transform.position == finishLine.position)
        {
            isMoving = false;
            raceStarted = false; // El caballo ha llegado a la meta y se detiene
        }
    }


    public void ResetPosition()
    {
        transform.position = startPoint.position;
        // Restablece otras propiedades necesarias, como la rotación si es necesario
        raceStarted = false;
        isMoving = false;
    }

}

