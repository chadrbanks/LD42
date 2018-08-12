using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    GameEngine engn;
    [SerializeField] private Renderer m_Renderer;
    public TextMesh ctxt;

    public int id = 1;

    void Start()
    {
        //
    }

    void OnMouseDown()
    {
        engn.ItemClickStore(this);
    }

    public void Setup(GameEngine ge)
    {
        engn = ge;
        m_Renderer.material = engn.bgs[id];
    }

    void Update()
    {
        ctxt.text = "B: " + Singleton.data.prices[id] + "  S: " + Mathf.Round( Singleton.data.prices[id] * .8f );
    }
}
