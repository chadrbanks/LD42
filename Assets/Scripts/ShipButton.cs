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
            Singleton.data.shipname = "B15 Defender";
            Singleton.data.speed = 3;
            Singleton.data.hull = 5;
            Singleton.data.hullmax = 5;
            //Singleton.data.cap = 0;
            Singleton.data.capmax = 15;
            Singleton.data.weapons = 10;
        }
        else if (id == 2)
        {
            Singleton.data.shipname = "Speed Rogue";
            Singleton.data.speed = 5;
            Singleton.data.hull = 3;
            Singleton.data.hullmax = 3;
            //Singleton.data.cap = 0;
            Singleton.data.capmax = 10;
            Singleton.data.weapons = 5;
        }
        else if (id == 3)
        {
            Singleton.data.shipname = "Assult E13";
            Singleton.data.speed = 3;
            Singleton.data.hull = 10;
            Singleton.data.hullmax = 10;
            //Singleton.data.cap = 0;
            Singleton.data.capmax = 10;
            Singleton.data.weapons = 15;
        }
        else
        {
            Singleton.data.shipname = "The Tank";
            Singleton.data.speed = 1;
            Singleton.data.hull = 7;
            Singleton.data.hullmax = 7;
            //Singleton.data.cap = 0;
            Singleton.data.capmax = 20;
            Singleton.data.weapons = 10;
        }

        Singleton.data.ship = id;
        SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
    }

	void Update ()
    {
		
	}
}
