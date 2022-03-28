using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public Transform floor;

    // Start is called before the first frame update
    void Start()
    {
       // this.GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float inputSpeed = Input.GetAxis("Horizontal");
        float maxZ = floor.localScale.z * 38f * 0.4f - transform.localScale.z * 1f * 0.4f;
        float posZ = transform.position.z + inputSpeed * (-1) * speed * Time.deltaTime;
        float clampedZ = Mathf.Clamp(posZ, -maxZ, +maxZ);
        
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);
    }
}

