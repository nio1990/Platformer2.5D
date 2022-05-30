using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExplode : MonoBehaviour
{

    public GameObject pickUpEffect;

    public void PickUp()
    {
        GameObject newPickUpEffect = (GameObject)Instantiate(pickUpEffect, transform.position, transform.rotation);
        Destroy(newPickUpEffect, 1);
    }
}
