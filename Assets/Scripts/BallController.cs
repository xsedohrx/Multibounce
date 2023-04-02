using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Ball ball = new Ball();

    public event Action OnTopBarrierHit, OnBottomBarrierHit;

    void Start(){ ResetBall(); }

    void FixedUpdate()
    {
        DrawRay();
        InputDetection();

        if (ball.canMove)
        {
            MoveBall();
            ball.IncreaseSpeed();
            DetectCollision();
        }
        else return;
        
    }

    private bool InputDetection()
    {
        // Wait for player input to start the game
        if (Input.touchCount > 0 && !ball.canMove)
            ball.canMove = true;
        return ball.canMove;
    }

    private void DrawRay()
    {
        //TODO update ball ray to point in direction + speed
        //Draw a ray from the ball in its direction
        Debug.DrawRay(transform.position, ball.direction * .5f, Color.blue, 0f);
    }

    private void MoveBall()
    {
        // Move the ball in the current direction
        transform.Translate(ball.direction * ball.currentSpeed * Time.deltaTime);
    }

    public void DetectCollision()
    {
        // Bounce the ball off of objects
        int layerMask = ~(1 << gameObject.layer); // ignore collisions with the ball's own layer
        float radius = GetComponent<CircleCollider2D>().radius;
        Vector2 center = (Vector2)transform.position + GetComponent<CircleCollider2D>().offset;
        float distance = ball.currentSpeed * Time.deltaTime;
        Vector2 endPoint = center + ball.direction.normalized * distance;

        RaycastHit2D hit = Physics2D.CircleCast(center, radius, ball.direction, distance, layerMask);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "BarrierTop" || hit.collider.tag == "BarrierBottom")
            {
                BarrierCheck();
                ResetBall();
                return;
            }

            ball.SetDirection(hit);
            return;
        }
    }


    // Check if the ball has hit the top or bottom barriers
    private void BarrierCheck()
    {
        if (transform.position.y > 4.5f)
        {
            OnTopBarrierHit?.Invoke();
        }
        else if (transform.position.y < -4.5f)
        {
            OnBottomBarrierHit?.Invoke();
        }
    }

    // Reset Ball properties
    public void ResetBall()
    {        
        transform.position = new Vector3(0f, 0f, -1f);
        ball.SetRandomDirection();
        ball.currentSpeed = ball.baseSpeed;
        ball.canMove = false;
    }
}


public class Ball {
    public float baseSpeed = 1f;
    public float currentSpeed = 1f;
    public Vector2 direction;
    public bool canMove = false;
    public float speedIncreaseStep = 0.5f;
    public void SetRandomDirection() {
        // Set a random direction for the ball to start moving in
        direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    public void SetDirection(RaycastHit2D hit)
    {
        direction = Vector2.Reflect(direction, hit.normal);
    }

    public void IncreaseSpeed()
    {
        // Increase the speed over time
        currentSpeed += Time.deltaTime * speedIncreaseStep;
    }

}