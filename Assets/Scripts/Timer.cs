using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime = 0f;
    public float gameTime = 0f;
    public float countDown = 3f;
    public bool gameStarted = false;
    private float startTime = 0f;
    private float elapsedTime = 0f;

    void Start()
    {
        // Start the countdown
        InvokeRepeating("CountDown", 0f, 1f);
    }

    void Update()
    {
        // If the game has started, update the game timer
        if (gameStarted)
        {
            elapsedTime = Time.time - startTime;
            gameTime = elapsedTime + totalTime;
        }

        // If the player taps the screen, log a message
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            
        }
    }

    void CountDown()
    {
        countDown -= 1f;
        if (countDown == 0f)
        {
            // Stop the countdown and start the game timer
            CancelInvoke("CountDown");
            startTime = Time.time;
            gameStarted = true;
        }
    }

    public void ResetTimer()
    {
        // Reset the timer and total time
        elapsedTime = 0f;
        totalTime = 0f;
        gameTime = 0f;
        gameStarted = false;
        countDown = 3f;

        // Start the countdown again
        InvokeRepeating("CountDown", 0f, 1f);
    }

}
