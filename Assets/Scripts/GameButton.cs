﻿using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameButtonType
{
    Home, Cantina, Market, Mine, Explore, Leave, Mine2, Quest
}

public class GameButton : MonoBehaviour
{
    public GameEngine engn;
    public GameButtonType bt;

    [SerializeField] private Material m_NormalMaterial;
    [SerializeField] private Material m_OverMaterial;
    [SerializeField] private Material m_ClickedMaterial;
    [SerializeField] private Renderer m_Renderer;

    bool over = false;

    void Start()
    {
        //m_Renderer.material = m_NormalMaterial;
    }

    void OnMouseOver()
    {
        if (!over)
        {
            //m_Renderer.material = m_OverMaterial;
        }

        over = true;
    }

    void OnMouseExit()
    {
        //m_Renderer.material = m_NormalMaterial;
        over = false;
    }

    void OnMouseDown()
    {
        
    }

    void OnMouseUp()
    {
        if (bt == GameButtonType.Leave)
        {
            if( engn.Leave( ) )
            {
                SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
            }
        }
        else
        {
            engn.ClickedButton(bt);
        }
    }
}