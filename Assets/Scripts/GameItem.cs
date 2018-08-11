using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    GameEngine engn;

    public int id = 1;

	void Start ()
    {
		
    }

    void OnMouseDown()
    {
        engn.ItemClick(this);
    }

    public void Setup( GameEngine ge )
    {
        engn = ge;
    }

    public void changeState(int i)
    {
        id = i;
    }

	void Update ()
    {
		if( id == 2 )
        {
            //
        }
	}
}
