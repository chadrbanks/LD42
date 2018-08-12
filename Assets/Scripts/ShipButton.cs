using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipButton : MonoBehaviour
{
    public int id;

	void Start ()
    {
		
    }

    void OnMouseOver()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 9.0f);
    }

    void OnMouseExit()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 10.0f);
    }

    void OnMouseDown()
    {
        Singleton.data.ship = id;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

	void Update ()
    {
		
	}
}
