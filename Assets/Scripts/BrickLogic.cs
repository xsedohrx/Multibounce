using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    Brick brick = new Brick();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            brick.brickHealth--;
            CheckDestruction();
        }
    }

    void CheckDestruction() {
        if (brick.brickHealth <=0)
        {
            brick.brickHealth = 0;
            DestroyBrick();
        }
    }

    private void DestroyBrick()
    {
        ItemSpawnCheck();
        Destroy(gameObject);
    }

    private void ItemSpawnCheck()
    {
        float random= UnityEngine.Random.Range(0, 100);
        if (random / 100 > 0.8f)
        {
            Debug.Log("Spawned Item");
        }
        else {
            Debug.Log("Nothing");
        }
        Debug.Log(random.ToString());
    }
}

public class Brick
{
    public int brickHealth = 3;
    public enum BrickType { GREEN, BLUE}
    public BrickType brickType;
    
}
