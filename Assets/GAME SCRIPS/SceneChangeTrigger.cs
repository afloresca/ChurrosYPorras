using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // Necesario para cargar escenas
using UnityEngine.EventSystems; // Para eventos de puntero

public class SceneChangeTrigger : MonoBehaviour, IPointerClickHandler
{
    public string sceneNameToLoad; // Nombre de la escena que quieres cargar

    public void OnPointerClick(PointerEventData eventData)
    {
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("ChurrosYPorras"); // Carga la escena
    }
}
