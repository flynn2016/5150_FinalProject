using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text zone_red_text;
    public Text zone_blue_text;
    public AdvantagePoint zone_red;
    public AdvantagePoint zone_blue;
    // Use this for initialization
    void Start () {
        zone_red_text.text = "ZoneRed: Controlled by no one";
        zone_blue_text.text = "ZoneBlue: Controlled by no one";
    }
	
	// Update is called once per frame
	void Update () {
        if (zone_red.zone_control == 1)
        {
            zone_red_text.text = "ZoneRed: Controlled by you";
        }
        else if(zone_red.zone_control == 2)
        {
            zone_red_text.text = "ZoneRed: Controlled by enemy";
        }
        else
            zone_red_text.text = "ZoneRed: Controlled by no one";

        if (zone_blue.zone_control == 1)
        {
            zone_blue_text.text = "ZoneBlue: Controlled by you";
        }
        else if (zone_blue.zone_control == 2)
        {
            zone_blue_text.text = "ZoneBlue: Controlled by enemy";
        }
        else
            zone_blue_text.text = "ZoneBlue: Controlled by no one";
    }
}
