using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
   // public Vector3 cameraOffset;
   // public GameObject target;

   // bool doRotate = false;

    //updates only then the player has moved
    void LateUpdate () {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }

    // void Update () {
    //     this.transform.position = target.transform.position + cameraOffset;

    //     if (Input.GetKeyDown("r"))
    //         doRotate = !doRotate;

    //     if (doRotate)
    //         this.transform.eulerAngles = new Vector3(90, 0, -target.transform.eulerAngles.y);
    //     else
    //     {
    //         this.transform.eulerAngles = new Vector3(90, 0, 0);
    //     }
    // }
}
