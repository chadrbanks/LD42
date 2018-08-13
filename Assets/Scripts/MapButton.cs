using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public int planetid;
    public TextMesh pname;
    public TextMesh pdesc;

	void Start ()
    {
		
    }

    void OnMouseOver()
    {
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
            pdesc.text = "A very hot planet with\ntripple the Earths gravity.";
        }
        else if (planetid == 4)
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
        Singleton.data.planet = planetid;
        SceneManager.LoadScene("GameScene2", LoadSceneMode.Single);
    }

	void Update ()
    {
		
	}
}
