using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvantagePoint : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mine")
        {
            Debug.Log("here");
        }
    }
}
