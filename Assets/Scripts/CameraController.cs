using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform player1;
    [SerializeField] public Transform player2;
    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float zoomSpeed = 5f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        // Calculate the midpoint between the players' X positions
        float midpointX = (player1.position.x + player2.position.x) / 2f;

        // Set the camera's X position to the midpointX
        Vector3 newPosition = transform.position;
        newPosition.x = midpointX;
        transform.position = newPosition;

        // Calculate the distance between the players' X positions
        float distanceX = Mathf.Abs(player1.position.x - player2.position.x);

        // Adjust the camera's orthographic size (zoom level) based on player X distance
        float targetSize = Mathf.Clamp(distanceX, minZoom, maxZoom);
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
    }
}
