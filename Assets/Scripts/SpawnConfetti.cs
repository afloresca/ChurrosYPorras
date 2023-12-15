using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConfetti : MonoBehaviour
{

    public GameObject confetti;

    public void Spawn()
    {
        GameObject gameObject = Instantiate(Resources.Load("Confetti", typeof(GameObject))) as GameObject;
        Destroy(gameObject, 10);
    }
}