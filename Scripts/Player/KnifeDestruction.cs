using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDestruction : MonoBehaviour
{

    public float lifespan = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            
            Destroy(this.gameObject);
        }

    }
}
