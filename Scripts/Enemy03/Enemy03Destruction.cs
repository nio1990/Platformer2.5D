using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Destruction : MonoBehaviour
{
    public float lifespan = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
