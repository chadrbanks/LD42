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

    public float credits = 200;
    //public int[] goods = new int[4];
    public List<int> goods = new List<int>();
    public List<int> prices = new List<int>();

	void Start ()
    {
        goods.Add(0);
        goods.Add(1);
        goods.Add(0);
        goods.Add(0);
        prices.Add(1);
        prices.Add(10);
        prices.Add(25);
        prices.Add(100);

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
        if( goods[3] > 0 )
        {
            goods[3]--;
            prices[1] = Random.Range(1, 200);
            prices[2] = Random.Range(1, 200);
            prices[3] = Random.Range(1, 200);
        }
    }

    public void ItemClickInventory(GameItem item)
    {
        //DestroyObject(id);
        //item.changeState(2);
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (goods[item.id] >= 10)
            {
                credits += prices[item.id] * 10 * .8F;
                goods[item.id] -= 10;
            }
        }
        else if (goods[item.id] >= 1)
        {
            credits += prices[item.id] * .8F;
            goods[item.id]--;
        }
    }

    public void ItemClickStore(StoreItem item)
    {
        int cap = goods[1] + goods[2] + goods[3];
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (credits >= prices[item.id] * 10)
            {
                credits -= prices[item.id] * 10 * .8F;
                goods[item.id] += 10;
           }
        }
        else if( credits >= prices[item.id] && cap < 10 )
        {
            credits -= prices[item.id];
            goods[item.id]++;
        }
    }

    void Update ()
    {
        //Debug.Log(Input.GetKeyDown(KeyCode.LeftShift));

        int cap = goods[1] + goods[2] + goods[3];
        ctxt.text = "Credits: " + credits + "\nCapacity: " + cap + "/10";
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}