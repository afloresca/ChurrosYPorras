using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfController : MonoBehaviour
{
    [SerializeField]
    private Transform bulletPoint;
   public float sensitivity = 5.0f;
   public GameObject bullet;
   public float bulletSpeed = 10.0f;

   private Vector3 _angles = Vector3.zero;
   private float _maxAngles = 120.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1))
        {
            FireBullet();
        }

        if (Input.GetMouseButton(0))
         {
            Cursor.lockState = CursorLockMode.Locked;
            float rotateHorizontal = Input.GetAxis("Mouse X");
            float rotateVertical = Input.GetAxis("Mouse Y");

            _angles.y += rotateHorizontal * sensitivity;
            _angles.y = Mathf.Clamp(_angles.y, -_maxAngles, _maxAngles);

            _angles.x -= rotateVertical * sensitivity;
            _angles.x = Mathf.Clamp(_angles.x, -_maxAngles, _maxAngles);

            gameObject.transform.rotation = Quaternion.Euler(_angles);
         }
        else{
            Cursor.lockState = CursorLockMode.None;
         }


    }
    private void FireBullet ()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = bulletPoint.position;
        newBullet.transform.rotation = bulletPoint.rotation;

        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
    
    }
}

