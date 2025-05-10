using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private float sensitivityX = 150f;
    private float sensitivityY = 150f;

    private float mouseX;
    private float mouseY;

    private float rotationX;
    private float rotationY;

    private float minAngleY = -45;
    private float maxAngleY = 45;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LookRotation();
    }

    private void LookRotation()
    {
        rotationY = Mathf.Clamp(rotationY, minAngleY, maxAngleY);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotationX += mouseX * sensitivityX * Time.deltaTime;
        rotationY -= mouseY * sensitivityY * Time.deltaTime;

        camera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, rotationX, 0);
    }
}
