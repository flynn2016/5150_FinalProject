using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdvantagePoint : MonoBehaviour {

    private int mine=0;
    private int enemy=0;
    public int zone_control=0;


    private void Update()
    {
        if (mine > enemy)
        {
            zone_control = 1;
        }
        else if (enemy > mine)
        {
            zone_control = 2;
        }
        if (enemy == mine)
        {
            zone_control = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Mine")
        {
            mine++;
        }
        else if(other.tag == "Enemy")
        {
            enemy++;
        }
    }


}
