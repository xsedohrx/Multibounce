using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Variables for ball movement
    private bool hasGameStarted = false;
    private float baseSpeed = 1f;
    private float currentSpeed = 1f;
    private Vector2 direction;

    // Variables for collision detection
    public event Action OnTopBarrierHit;
    public event Action OnBottomBarrierHit;

    // Start is called before the first frame update
    void Start()
    {
        // Set the ball to the target position
        transform.position = new Vector3(0f, 0f, -1f);

        // Set a random direction for the ball to start moving in
        direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        
        // Wait for player input to start the game
        if (Input.touchCount > 0 && !hasGameStarted)
        {
            // Start the game
            hasGameStarted = true;
        }

        if (hasGameStarted)
        {
            // Move the ball in the current direction
            transform.Translate(direction * currentSpeed * Time.deltaTime);

            // Increase the speed over time
            currentSpeed += Time.deltaTime * 0.5f;

            // Bounce the ball off of objects
            int layerMask = ~(1 << gameObject.layer); // ignore collisions with the ball's own layer
            float radius = GetComponent<CircleCollider2D>().radius;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, radius, layerMask);

            if (hit.collider != null)
            {

                if (hit.collider.tag == "BarrierTop" || hit.collider.tag == "BarrierBottom")
                {
                    ResetBall();
                    return;
                }
                //Debug.Log(hit.collider.gameObject);
                direction = Vector2.Reflect(direction, hit.normal);
            }

            // Check if the ball has hit the top or bottom barriers
            if (transform.position.y > 4.5f)
            {
                // Trigger the OnTopBarrierHit event
                if (OnTopBarrierHit != null)
                {
                    OnTopBarrierHit();
                }
            }
            else if (transform.position.y < -4.5f)
            {
                // Trigger the OnBottomBarrierHit event
                if (OnBottomBarrierHit != null)
                {
                    OnBottomBarrierHit();
                }
            }
        }
    }

    // Function to reset the ball's position and speed
    public void ResetBall()
    {
        // Set the ball to the target position
        transform.position = new Vector3(0f, 0f, -1f);

        // Set a random direction for the ball to start moving in
        direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

        // Reset the ball's movement variables
        hasGameStarted = false;
        currentSpeed = baseSpeed;
    }
}
