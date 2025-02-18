using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Controller player;
    [SerializeField] private float disX;
    [SerializeField] private float disY;
    [SerializeField] private float disZ;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float dpi = 1000;

    private void LateUpdate()
    {
        Vector3 disVec = player.transform.position - new Vector3(disX, disY, disZ);
        transform.position = disVec;

        CameraRotation();
    }

    private void CameraRotation()
    {
        mouseX += Input.GetAxis("Mouse X") * dpi * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * dpi * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        mouseX = Mathf.Clamp(mouseX, -75f, 75f);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
