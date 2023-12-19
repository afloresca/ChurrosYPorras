//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{
    public bool esBotonDeInicio;
    public RaceManager raceManager;
    public bool esBotonDeReinicio;
    private bool isGazingAt;
    private float gazeTimer;
    public float gazeTimeThreshold = 2.0f; // Tiempo en segundos que el usuario debe mirar el objeto para seleccionarlo
    public GameObject[] horses; // Arreglo de caballos para iniciar la carrera.
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    /// <summary>
    /// Teleports this instance randomly when triggered by a pointer click.
    /// </summary>
    public void TeleportRandomly()
    {
        // Picks a random sibling, activates it and deactivates itself.
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
        GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

        // Computes new object's location.
        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        float distance = Random.Range(_minObjectDistance, _maxObjectDistance);
        float height = Random.Range(_minObjectHeight, _maxObjectHeight);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * distance, height,
                                     Mathf.Sin(angle) * distance);

        // Moves the parent to the new position (siblings relative distance from their parent is 0).
        transform.parent.localPosition = newPos;

        randomSib.SetActive(true);
        gameObject.SetActive(false);
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetMaterial(true);
        isGazingAt = true;
        gazeTimer = 0f; // Reinicia el temporizador

    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetMaterial(false);
        isGazingAt = false;
        gazeTimer = 0f; // Reinicia el temporizador

    }

    void Update()
    {
        if (isGazingAt)
        {
            gazeTimer += Time.deltaTime; // Incrementa el temporizador

            if (gazeTimer >= gazeTimeThreshold) // Verifica si el usuario ha mirado el objeto suficiente tiempo
            {
                if (esBotonDeInicio)
                {
                    StartRace(); // Inicia la carrera si es el botón de inicio
                }
                else if (esBotonDeReinicio)
                {
                    RestartRace(); // Reinicia la carrera si es el botón de reinicio
                }
                else if (gameObject.CompareTag("CambiaAEscenaPrincipal"))
                {
                    SceneManager.LoadScene("ChurrosYPorras"); // Cambia a la escena "ChurrosYPorras"
                }
                else if (gameObject.CompareTag("CambiaAEscenaPrincipal"))
                {
                    SceneManager.LoadScene("HorseRACEv1"); // Cambia a la escena "EscenaPrincipal"
                }
            
                isGazingAt = false; // Restablece la variable para evitar que la acción se inicie continuamente
            }
        }
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        Debug.Log("OnPointerClick called"); // Este mensaje se mostrará en la consola de Unity cuando se haga clic en el objeto.

        StartRace(); // Llamada al método para iniciar la carrera.
    }


    private void StartRace()
    {
        foreach (GameObject horse in horses)
        {
            // Intenta obtener y llamar a StartRace en AIAHorseControl
            AIAHorseControl aiHorseControl = horse.GetComponent<AIAHorseControl>();
            if (aiHorseControl != null)
            {
                aiHorseControl.StartRace();
            }

            // Intenta obtener y llamar a StartRace en PlayerHorseControl2
            PlayerHorseControl2 playerHorseControl = horse.GetComponent<PlayerHorseControl2>();
            if (playerHorseControl != null)
            {
                playerHorseControl.StartRace();
            }
        }

        if (raceManager != null)
        {
            raceManager.BeginRace(); // Notifica a RaceManager que la carrera ha comenzado
        }
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

        // Notifica a RaceManager que la carrera ha terminado y se reiniciará
        if (raceManager != null)
        {
            raceManager.EndRace();
        }

        // Aquí puedes añadir cualquier otra lógica necesaria para reiniciar la carrera
    }



    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}








//void Update()
//{
  //  if (isGazingAt)
    //{
      //  gazeTimer += Time.deltaTime; // Incrementa el temporizador
      //
        //if (gazeTimer >= gazeTimeThreshold) // Verifica si el usuario ha mirado el objeto suficiente tiempo
        //{
          //  StartRace(); // Inicia la carrera
            //isGazingAt = false; // Restablece la variable para evitar que la carrera se inicie continuamente
        //}
    //}
//}










// Añade este método para iniciar la carrera.
//private void StartRace()
//{
//    foreach (GameObject horse in horses)
//    {
//        horse.GetComponent<AIAHorseControl>().StartRace();
//    }
//
//    // Aquí puedes añadir cualquier otra lógica necesaria para iniciar la carrera.
//}