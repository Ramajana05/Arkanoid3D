using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        float inputSpeed = Input.GetAxisRaw("Horizontal");
    }
}
