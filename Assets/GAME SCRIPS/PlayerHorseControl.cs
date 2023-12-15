using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHorseControl : MonoBehaviour
{
    public float speed = 5f; // Velocidad del caballo
    public Transform targetDiana; // Asigna la Transform de la diana
    private bool isMoving = false;
    public Camera playerCamera; // Agrega esta línea
    public Transform finishLine;
    public Transform startPoint;
    private bool raceStarted = false;
    public float maxSpeed = 10f; // Velocidad máxima del caballo
    private float currentSpeed;



    void Update()
    {
        if (raceStarted)
        {
            CheckIfAimingAtTarget();
            if (isMoving)
            {
                MoveHorse(currentSpeed);
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

        if (Physics.Raycast(ray, out hit) && hit.transform == targetDiana)
        {
            // Calcula la velocidad basada en la precisión de la mira
            float distanceToCenter = Vector2.Distance(new Vector2(hit.point.x, hit.point.y), new Vector2(targetDiana.position.x, targetDiana.position.y));
            float speed = (5 - distanceToCenter) * maxSpeed;
            speed = Mathf.Clamp(speed, 0, maxSpeed);

            isMoving = true;
            MoveHorse(speed);
        }
        else
        {
            isMoving = false;
        }
    }

    private void MoveHorse(float speed)

    {
        transform.position = Vector3.MoveTowards(transform.position, finishLine.position, speed * Time.deltaTime);
   
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

