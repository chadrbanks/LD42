using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public GameItem[] slots;
    public StoreItem[] stores;
    //public AudioSource failure, mainsong;
    [SerializeField] public Material[] bgs;
    public TextMesh ctxt;

	void Start ()
    {
        for (int x = 0; x < slots.Length; x++)
        {
            slots[x].Setup(this);
        }
        for (int x = 0; x < stores.Length; x++)
        {
            stores[x].Setup(this);
        }
    }

    public void Leave()
    {
        if( Singleton.data.goods[3] > 0 )
        {
            Singleton.data.goods[3]--;
            Singleton.data.prices[1] = Random.Range(1, 200);
            Singleton.data.prices[2] = Random.Range(1, 200);
            Singleton.data.prices[3] = Random.Range(1, 200);
        }
    }

    public void ItemClickInventory(GameItem item)
    {
        //DestroyObject(id);
        //item.changeState(2);
        if( Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
        {
            if (Singleton.data.goods[item.id] >= 10)
            {
                Singleton.data.credits += Mathf.Round(Singleton.data.prices[item.id] * 10 * .8F);
                Singleton.data.goods[item.id] -= 10;
            }
        }
        else if (Singleton.data.goods[item.id] >= 1)
        {
            Singleton.data.credits += Mathf.Round(Singleton.data.prices[item.id] * .8F);
            Singleton.data.goods[item.id]--;
        }
    }

    public void ItemClickStore(StoreItem item)
    {
        int cap = Singleton.data.goods[1] + Singleton.data.goods[2] + Singleton.data.goods[3];
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Singleton.data.credits >= Singleton.data.prices[item.id] * 10 && cap == 0 )
            {
                Singleton.data.credits -= Singleton.data.prices[item.id] * 10;
                Singleton.data.goods[item.id] += 10;
           }
        }
        else if( Singleton.data.credits >= Singleton.data.prices[item.id] && cap < 10 )
        {
            Singleton.data.credits -= Singleton.data.prices[item.id];
            Singleton.data.goods[item.id]++;
        }
    }

    void Update ()
    {
        int cap = Singleton.data.goods[1] + Singleton.data.goods[2] + Singleton.data.goods[3];
        ctxt.text = "Credits: " + Singleton.data.credits + "\nCapacity: " + cap + "/10";
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}