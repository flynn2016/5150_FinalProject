using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy"){
            Debug.Log("here");
        }
    }
}
