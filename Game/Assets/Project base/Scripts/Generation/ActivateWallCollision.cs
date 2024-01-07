using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<WallCollision>().enabled = true; //enable wall collision component
    }

}