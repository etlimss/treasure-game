using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfFlowers { get; private set; }

    public UnityEvent<PlayerInventory> OnFlowerCollected;

    public void FlowerCollected() 
    {
        NumberOfFlowers++;
        OnFlowerCollected.Invoke(this);
    }
}
