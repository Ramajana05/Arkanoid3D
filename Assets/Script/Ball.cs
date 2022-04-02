using System.Net.WebSockets;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    Vector3 velocity;
    public float maxX;
    public float maxZ;

    public bool isPressed = false;
    public GameObject startText; 
    public GameObject gameOverText; 

    public AudioSource audioDataDead;

    public TextMeshPro scoreText;
    public int score = 0;

    public TextMeshPro lifeText;
    public int lifeAmount;
  
    // Start is called before the first frame update
    void Start()
    {
        startText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OnStart();
        transform.position +=  velocity * Time.deltaTime;
        scoreText.SetText("Score: " + score);
        lifeText.SetText("Life: " + lifeAmount);
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
            lifeAmount--;

        if(lifeAmount == 0){
                gameOverText.gameObject.SetActive(true);
                isPressed = true;
        }
            
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
            if(other.gameObject.GetComponent<Block>().breakable){
                if(other.gameObject.GetComponent<Block>().hitCount != 0){
                other.gameObject.GetComponent<Block>().hitCount--;
                Block affectedBlock = other.gameObject.GetComponent<Block>();
                //affectedBlock.destroyYourself();
            } else {
            //other.gameObject.GetComponent<Block>().hitCount++;
            Destroy(other.gameObject); 
            }
        }
            
            
            
            
        }
 
        score++;
        GameManager.score++;
    }

    private void BounceSound(){
         gameObject.GetComponent<AudioSource>().Play();
    }


}