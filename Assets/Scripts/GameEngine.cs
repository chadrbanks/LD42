using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public GameItem[] slots;
	//public AudioSource failure, mainsong;

	void Start ()
	{
        for (int x = 0; x < slots.Length; x++)
        {
            slots[x].Setup(this);
        }
    }

    public void ItemClick( GameItem id )
    {
        //DestroyObject(id);
        id.changeState(2);
    }

    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}