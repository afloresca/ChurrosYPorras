using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    Vector3 moveBallons;
    // Update is called once per frame
    void Update()
    {
      moveBallons = new Vector3 (0, 45, 0);

      transform.Rotate (moveBallons * Time.deltaTime);
    }
}
