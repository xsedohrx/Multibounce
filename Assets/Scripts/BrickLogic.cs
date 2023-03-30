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
            Destroy(gameObject);
        }
    }
}

public class Brick
{
    public int brickHealth = 3;
    public enum BrickType { GREEN, BLUE}
    public BrickType brickType;
    
}
