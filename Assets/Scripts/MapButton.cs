using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public int planetid;

	void Start ()
    {
		
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
