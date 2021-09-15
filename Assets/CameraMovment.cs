using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public Transform player;
    Vector2 velocity = Vector2.zero;

    void Update()
    {
        transform.position = new Vector3(player.position.x +3, player.position.y +2, transform.position.z);
    }
}
