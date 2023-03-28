using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    int Lives = 3;

    void DecreaseLife() {
        Lives--;
    }
}
