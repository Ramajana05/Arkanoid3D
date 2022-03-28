using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitCount;
    public Material[] materials;

    public void destroyYourself()
    {
        GetComponent<Renderer>().material = materials[hitCount];
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = GameManager.Instance.defaultMaterial;
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hitCount);
    }
}
