using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    GameEngine engn;
    [SerializeField] private Renderer m_Renderer;
    public TextMesh ctxt;

    public int id = 1;

	void Start ()
    {
        //
    }

    void OnMouseDown()
    {
        engn.ItemClickInventory(this);
    }

    public void Setup( GameEngine ge )
    {
        engn = ge;
        m_Renderer.material = engn.bgs[id];
    }

	void Update ()
    {
        ctxt.text = "Qty: " + Singleton.data.goods[id];
	}
}
