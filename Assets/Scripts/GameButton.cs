using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameButtonType
{
    Leave
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
        //m_Renderer.material = m_ClickedMaterial;
    }

    void OnMouseUp()
    {
        //m_Renderer.material = m_OverMaterial;//m_NormalMaterial;

        //engn.Leave();

        SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
    }
}