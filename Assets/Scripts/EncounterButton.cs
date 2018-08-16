using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EncounterButtonType
{
    Attack, Pay, Leave, Quit, Play
}

public class EncounterButton : MonoBehaviour
{
    public EncounterHandler engn;
    public EncounterButtonType bt;

    //bool over = false;

    void Start()
    {
        //m_Renderer.material = m_NormalMaterial;
    }

    void OnMouseOver()
    {
        //
    }

    void OnMouseExit()
    {
        //m_Renderer.material = m_NormalMaterial;
        //over = false;
    }

    void OnMouseDown()
    {

    }

    void OnMouseUp()
    {
        if (bt == EncounterButtonType.Attack)
        {
            engn.Action( 1 );
        }
        else if (bt == EncounterButtonType.Leave)
        {
            engn.Action(2);
        }
        else if (bt == EncounterButtonType.Pay)
        {
            engn.Action(3);
        }
        else if (bt == EncounterButtonType.Quit)
        {
            engn.Action(4);
        }
        else if (bt == EncounterButtonType.Play)
        {
            engn.Action(5);
        }
    }
}