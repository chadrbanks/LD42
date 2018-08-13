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
    public TextMesh pname;
    public TextMesh pdesc;
    public TextMesh ship1, ship2;
    public GameObject market, cantina, mines;

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

        SetupPlanet();
    }

    public void SetupPlanet()
    {
        if (Singleton.data.planet == 1)
        {
            pname.text = "The Emerald Planet";
            //pdesc.text = "The busiest planet with the\nmost people living on it.\nThis planets population\nexploded rapidly due to all\nof the highly valued\nmaterials on it.\nWith quick growth comes\nlots of crime though.";
        }
        else if (Singleton.data.planet == 2)
        {
            pname.text = "New Earth";
            //pdesc.text = "An earth like planet!";
        }
        else if (Singleton.data.planet == 3)
        {
            pname.text = "Santigo 3G";
            //pdesc.text = "A very hot planet with\ntripple the Earths gravity. Aside from the space port above the planet, there is not a lot of activity on the surface other than mining.";
        }
        else
        {
            pname.text = "MISSINGNO";
            //pdesc.text = "Description.";
        }

        pdesc.text = "Select an action to the right.\n\nPlanet stats coming soon.";

        cantina.SetActive(false);
        market.SetActive(false);
        mines.SetActive(false);
    }

    // 1 - Metal plating
    // 2 - Weapons
    // 3 - Fuel

    public bool Leave()
    {
        if( Singleton.data.goods[3] > 0 )
        {
            Singleton.data.goods[3]--;

            if (Singleton.data.planet == 1)
            {
                Singleton.data.prices[1] = Random.Range(1, 200);
                Singleton.data.prices[2] = Random.Range(1, 200);
                Singleton.data.prices[3] = Random.Range(150, 200);
            }
            else if (Singleton.data.planet == 2)
            {
                Singleton.data.prices[1] = Random.Range(1, 200);
                Singleton.data.prices[2] = Random.Range(1, 50);
                Singleton.data.prices[3] = Random.Range(150, 200);
            }
            else if (Singleton.data.planet == 3)
            {
                Singleton.data.prices[1] = Random.Range(50, 150);
                Singleton.data.prices[2] = Random.Range(100, 200);
                Singleton.data.prices[3] = Random.Range(1, 50);
            }
            else
            {
                Singleton.data.prices[1] = Random.Range(1, 200);
                Singleton.data.prices[2] = Random.Range(1, 200);
                Singleton.data.prices[3] = Random.Range(1, 200);
            }

            return true;
        }

        pdesc.text = "You do not have enough fuel to leave.";
        return false;
    }

    public void ClickedButton( GameButtonType bt )
    {
        cantina.SetActive(false);
        market.SetActive(false);
        mines.SetActive(false);
        //lg.text = "Action completed: " + bt;
        if (bt == GameButtonType.Home )
        {
            SetupPlanet();
        }
        else if (bt == GameButtonType.Cantina)
        {
            if (Singleton.data.planet == 1)
            {
                pname.text = "The Green Cantina";
                pdesc.text = "";
                cantina.SetActive(true);
            }
            else if (Singleton.data.planet == 2)
            {
                pname.text = "The Rusty Wrynn";
                pdesc.text = "";
                cantina.SetActive(true);
            }
            else if (Singleton.data.planet == 3)
            {
                pname.text = "Santigo Cantigo";
                pdesc.text = "There are no cantinas on this planet, it is not a great place to be.";
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Description.";
            }
        }
        else if (bt == GameButtonType.Market )
        {
            if (Singleton.data.planet == 1)
            {
                pname.text = "The Green Market";
                pdesc.text = "";
            }
            else if (Singleton.data.planet == 2)
            {
                pname.text = "The Overground";
                pdesc.text = "";
            }
            else if (Singleton.data.planet == 3)
            {
                pname.text = "Sand Road";
                pdesc.text = "";
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Market goes here.";
            }

            market.SetActive(true);
        }
        else if (bt == GameButtonType.Mine)
        {
            if (Singleton.data.planet == 1)
            {
                pname.text = "The Green Mines";
                pdesc.text = "";
                mines.SetActive(true);
            }
            else if (Singleton.data.planet == 2)
            {
                pname.text = "New Earth";
                pdesc.text = "You cannot mine here.";
            }
            else if (Singleton.data.planet == 3)
            {
                pname.text = "Santigo Mines";
                pdesc.text = "";
                mines.SetActive(true);
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Description.";
            }
        }
        else if (bt == GameButtonType.Mine2)
        {
            mines.SetActive(true);

            if (Singleton.data.goods[3] > 0)
            {
                Singleton.data.goods[3]--;

                if (Singleton.data.planet == 1)
                {
                    float c = Random.Range(50, 250);
                    Singleton.data.credits += c;
                    pdesc.text = "You mined some material worth " + c + " credits!";
                }
                else if (Singleton.data.planet == 2)
                {
                    //
                }
                else if (Singleton.data.planet == 3)
                {
                    float c = Random.Range(50, 250);
                    Singleton.data.credits += c;
                    pdesc.text = "You mined some material worth " + c + " credits!";
                }
                else
                {
                    pname.text = "MISSINGNO";
                    pdesc.text = "Description.";
                }
            }
            else
            {
                pdesc.text = "You do not have enough fuel to go mine.";
            }
        }
        else if (bt == GameButtonType.Explore )
        {
            if (Singleton.data.planet == 1)
            {
                pname.text = "The Green Planet";
                pdesc.text = "Use this location to explore.";
            }
            else if (Singleton.data.planet == 2)
            {
                pname.text = "New Earth";
                pdesc.text = "There is not much on this planet left to explore.";
            }
            else if (Singleton.data.planet == 3)
            {
                pname.text = "Santigo 3G";
                pdesc.text = "Use this location to explore.";
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Description.";
            }
        }
        else
        {
            Debug.Log(bt);
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
        //ctxt.text = "Credits: " + Singleton.data.credits + "\nCapacity: " + cap + "/10";
        ship1.text = Singleton.data.shipname + "\nHull: " + Singleton.data.hull + " / " + Singleton.data.hullmax + "\nWeapons: " + Singleton.data.weapons + "\nSpeed: " + Singleton.data.speed;
        ship2.text = "Capacity: " + cap + " / " + Singleton.data.capmax + "\nFuel: " + Singleton.data.goods[3] + "\nCredits: " + Singleton.data.credits + "\nQuests: 0";

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}