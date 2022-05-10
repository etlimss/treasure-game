using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI flowerText;
    // Start is called before the first frame update
    void Start()
    {
        flowerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateFlowerText(PlayerInventory playerInventory)
    {
        flowerText.text = playerInventory.NumberOfFlowers.ToString();
    }
}
