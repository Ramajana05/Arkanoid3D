using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Vector3 velocity;
    public float maxX;
    public float maxZ;
    public int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(maxZ, 0, 0);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            float maxDist = transform.localScale.z * 0.5f + other.transform.localScale.z * 0.5f;
            float dist = transform.position.z - other.transform.position.z;
            float nDist = dist / maxDist;
            velocity = new Vector3(-velocity.x, velocity.y, nDist * maxZ);
        }
        if (other.CompareTag("Wall"))
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        }

        if (other.CompareTag("WallX"))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }
        
        if (other.CompareTag("Block"))
        {
             velocity = new Vector3(-velocity.x, velocity.y, -velocity.z);
            // other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            // other.gameObject.GetComponent<BoxCollider>().enabled = false;

            if (other.gameObject.GetComponent<Block>().hitCount >= 2)
            {
                Block affectedBlock = other.gameObject.GetComponent<Block>();
                affectedBlock.destroyYourself();
            }

            other.gameObject.GetComponent<Block>().hitCount++;

            Destroy(other.gameObject);
        }
 
        gameObject.GetComponent<AudioSource>().Play();
        score++;
        scoreText.text = score.ToString();
        GameManager.score++;
    }
}
