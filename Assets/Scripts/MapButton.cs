using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public int planetid;
    public TextMesh pname;
    public TextMesh pdesc;
    public MapHandler mh;

	void Start ()
    {
		
    }

    void OnMouseOver()
    {
        mh.setHeader(planetid);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.0f);

        if (planetid == 1)
        {
            pname.text = "The Emerald Planet";
            pdesc.text = "The busiest planet with the\nmost people living on it.\nThis planets population\nexploded rapidly due to all\nof the highly valued\nmaterials on it.\nWith quick growth comes\nlots of crime though.";
        }
        else if (planetid == 2)
        {
            pname.text = "New Earth";
            pdesc.text = "An earth like planet!";
        }
        else if (planetid == 3)
        {
            pname.text = "Santigo 3G";
            pdesc.text = "A very hot planet with\ntripple the Earths gravity.\nAside from the space port\nabove the planet, there is\nnot a lot of activity on the\nsurface other than mining.";
        }
        else
        {
            pname.text = "MISSINGNO";
        }
    }

    void OnMouseExit()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        pname.text = "";
        pdesc.text = "";
    }

    void OnMouseDown()
    {
        if (Singleton.data.plyr.planet == 1)
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(1, 200);
            Singleton.data.prices[2] = Random.Range(1, 200);
            Singleton.data.prices[3] = Random.Range(150, 200);
        }
        else if (Singleton.data.plyr.planet == 2)
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(1, 200);
            Singleton.data.prices[2] = Random.Range(1, 50);
            Singleton.data.prices[3] = Random.Range(150, 200);
        }
        else if (Singleton.data.plyr.planet == 3)
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(50, 150);
            Singleton.data.prices[2] = Random.Range(100, 200);
            Singleton.data.prices[3] = Random.Range(1, 50);
        }
        else
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(1, 200);
            Singleton.data.prices[2] = Random.Range(1, 200);
            Singleton.data.prices[3] = Random.Range(1, 200);
        }

        Singleton.data.plyr.planet = planetid;
        SceneManager.LoadScene("GameScene2", LoadSceneMode.Single);
    }

	void Update ()
    {
		
	}
}
