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
    public Text lifeText;
    public float lifeAmount;
    public bool isPressed = false;
    public GameObject startText; 
    public AudioSource audioDataDead;

    // Start is called before the first frame update
    void Start()
    {
        startText.gameObject.SetActive(true);
        //transform.position = new Vector3(-16f, 0.31f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        OnStart();
        transform.position +=  velocity * Time.deltaTime;
    }

    void OnStart()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPressed)
           {
            startText.gameObject.SetActive(false);
            isPressed = true;
            velocity = new Vector3(maxZ, 0, 0);
            }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            float maxDist = transform.localScale.z * 0.5f + other.transform.localScale.z * 0.5f;
            float dist = transform.position.z - other.transform.position.z;
            float nDist = dist / maxDist;
            velocity = new Vector3(-velocity.x, velocity.y, nDist * maxZ);
            BounceSound();
        }
        if (other.CompareTag("Wall"))
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
            BounceSound();
        }

        if (other.CompareTag("WallX"))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
            BounceSound();
        }

        if (other.CompareTag("WallBottom"))
        {
            audioDataDead.Play();
            velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(-16f, 0.3f, 0f);
            isPressed = false;
        } 

        //Fix thiwith Raycast
        //Bug that if it hits 2 Blocks it still turns once, not twice - Timer?
        //dont forget -z!
        if (other.CompareTag("Block"))
        {
             velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
             BounceSound();
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
 
        score++;
        scoreText.text = score.ToString();
        GameManager.score++;
    }

    private void BounceSound(){
         gameObject.GetComponent<AudioSource>().Play();
    }

}