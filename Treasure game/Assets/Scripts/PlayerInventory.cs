using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfFlowers { get; private set; }
    [SerializeField] private AudioSource CollectingSound;

    public UnityEvent<PlayerInventory> OnFlowerCollected;

    public void FlowerCollected() 
    {
        CollectingSound.Play();
        NumberOfFlowers++;
        OnFlowerCollected.Invoke(this);
    }
}
