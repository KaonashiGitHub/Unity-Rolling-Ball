using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 100.0f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Get input from arrow keys for rotating the camera
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the rotation around the player
        Quaternion rotation = Quaternion.Euler(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        offset = rotation * offset;

        // Set the camera's position and look at the player
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }
}