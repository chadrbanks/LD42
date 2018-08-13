using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public int planetid;
    public TextMesh ps;

	void Start ()
    {
		
    }

    void OnMouseOver()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.0f);

        if (planetid == 1)
        {
            ps.text = "P1";
        }
        else if (planetid == 2)
        {
            ps.text = "P2";
        }
        else if (planetid == 3)
        {
            ps.text = "P3";
        }
        else if (planetid == 4)
        {
            ps.text = "MISSINGNO";
        }
    }

    void OnMouseExit()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        ps.text = "";
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
