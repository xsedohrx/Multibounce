using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed = 10.0f;
    PhotonView photonView;
    void Start()
    {
        targetPosition = transform.position;
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine)       
            return;
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Screen tapped");
        }
    }

    Vector3 GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return Camera.main.ScreenToWorldPoint(touch.position);
        }
        else
        {
            return transform.position;
        }
    }

    void FixedUpdate()
    {
        targetPosition.x = GetTouchPosition().x;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
