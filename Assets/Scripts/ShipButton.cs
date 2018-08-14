using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipButton : MonoBehaviour
{
    public int id;
    public TextMesh ss;

	void Start ()
    {
		
    }

    void OnMouseOver()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 9.0f);

        if (id == 1)
        {
            ss.text = "B15 Defender\nSpeed: 3\nHull: 5\nStorage: 15\nWeapons: 10";
        }
        else if (id == 2)
        {
            ss.text = "Speed Rogue\nSpeed: 5\nHull: 3\nStorage: 10\nWeapons: 5";
        }
        else if (id == 3)
        {
            ss.text = "Assult E13\nSpeed: 3\nHull: 10\nStorage: 10\nWeapons: 15";
        }
        else if (id == 4)
        {
            ss.text = "The Tank\nSpeed: 1\nHull: 7\nStorage: 20\nWeapons: 10";
        }
    }

    void OnMouseExit()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 10.0f);
        ss.text = "";
    }

    void OnMouseDown()
    {
        if (id == 1)
        {
            Singleton.data.plyr.shipname = "B15 Defender";
            Singleton.data.plyr.speed = 3;
            Singleton.data.plyr.hull = 5;
            Singleton.data.plyr.hullmax = 5;
            Singleton.data.plyr.capmax = 15;
            Singleton.data.plyr.weapons = 10;
        }
        else if (id == 2)
        {
            Singleton.data.plyr.shipname = "Speed Rogue";
            Singleton.data.plyr.speed = 5;
            Singleton.data.plyr.hull = 3;
            Singleton.data.plyr.hullmax = 3;
            Singleton.data.plyr.capmax = 10;
            Singleton.data.plyr.weapons = 5;
        }
        else if (id == 3)
        {
            Singleton.data.plyr.shipname = "Assult E13";
            Singleton.data.plyr.speed = 3;
            Singleton.data.plyr.hull = 10;
            Singleton.data.plyr.hullmax = 10;
            Singleton.data.plyr.capmax = 10;
            Singleton.data.plyr.weapons = 15;
        }
        else
        {
            Singleton.data.plyr.shipname = "The Tank";
            Singleton.data.plyr.speed = 1;
            Singleton.data.plyr.hull = 7;
            Singleton.data.plyr.hullmax = 7;
            Singleton.data.plyr.capmax = 20;
            Singleton.data.plyr.weapons = 10;
        }

        Singleton.data.plyr.ship = id;
        SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
    }
}
