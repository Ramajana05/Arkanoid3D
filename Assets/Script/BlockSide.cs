using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSide : MonoBehaviour
{
    public int hitCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitCount = gameObject.GetComponent<Block>().hitCount;
        
    }
}
