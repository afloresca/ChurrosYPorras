using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems; // Asegúrate de incluir esta librería para eventos.

public class StartRaceTrigger : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] horses; // Arreglo de caballos para iniciar la carrera.

    public void OnPointerClick(PointerEventData eventData)
    {
        StartRace();
    }

    private void StartRace()
    {
        foreach (GameObject horse in horses)
        {
            // Intenta obtener el script AIAHorseControl y, si está presente, inicia la carrera para ese caballo
            AIAHorseControl aiHorseControl = horse.GetComponent<AIAHorseControl>();
            if (aiHorseControl != null)
            {
                aiHorseControl.StartRace();
            }

            // Intenta obtener el script PlayerHorseControl2 y, si está presente, inicia la carrera para ese caballo
            PlayerHorseControl2 playerHorseControl = horse.GetComponent<PlayerHorseControl2>();
            if (playerHorseControl != null)
            {
                playerHorseControl.StartRace();
            }
        }
    }
}

























//private void StartRace()
//{
//    foreach (GameObject horse in horses)
//    {
//        horse.GetComponent<AIAHorseControl>().StartRace();
//    }

// Aquí puedes añadir cualquier otra lógica necesaria para iniciar la carrera.
//}
//}
