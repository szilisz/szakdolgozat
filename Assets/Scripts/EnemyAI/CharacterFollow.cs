using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform playerCharacter; // Assign the player character's Transform in the Inspector
    public float xOffset = 10.0f; // Adjust this value to control the desired X-axis offset
    public float followDelay = 1.0f; // Delay in seconds

    private Vector3 targetPosition;
    private Vector3 initialPosition;
    private float elapsed = 0.0f;
    private Animator anim;




    void Start()
    {
        initialPosition = transform.position;
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        elapsed += Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");


        if (elapsed >= followDelay && playerCharacter != null)
        {
            Vector3 playerPosition = playerCharacter.position;
            targetPosition.x = playerPosition.x + xOffset;
            targetPosition.y = transform.position.y; // Maintain the same Y position
            targetPosition.z = transform.position.z; // Maintain the same Z position
            anim.SetBool("run", horizontalInput != 0);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }
        else
        {
            // Reset the position to the initial position while waiting
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime);
        }
    }
}
