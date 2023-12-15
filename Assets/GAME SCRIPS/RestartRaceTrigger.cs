using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RestartRaceTrigger : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] horses; // Arreglo de caballos para reiniciar la carrera.

    public void OnPointerClick(PointerEventData eventData)
    {
        RestartRace();
    }

    private void RestartRace()
    {
        foreach (GameObject horse in horses)
        {
            // Restablecer la posición de los caballos controlados por IA
            AIAHorseControl aiHorseControl = horse.GetComponent<AIAHorseControl>();
            if (aiHorseControl != null)
            {
                aiHorseControl.ResetPosition();
            }

            // Restablecer la posición del caballo del jugador
            PlayerHorseControl2 playerHorseControl = horse.GetComponent<PlayerHorseControl2>();
            if (playerHorseControl != null)
            {
                playerHorseControl.ResetPosition();
            }
        }

        // Aquí puedes añadir cualquier otra lógica necesaria para reiniciar la carrera
    }
}


