using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) 
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if(playerInventory != null) {
            playerInventory.FlowerCollected();
            gameObject.SetActive(false);
        }
    }
}
