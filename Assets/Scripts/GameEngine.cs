using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public StoreButton[] marketbuttons;
    //public AudioSource failure, mainsong;
    [SerializeField] public Material[] bgs;
    public TextMesh pname;
    public TextMesh pdesc;
    public TextMesh ship1, ship2;
    public GameObject market, cantina, mines;
    public GameObject[] cantinappl;

    bool cheap = false;

	void Start ()
    {
        for (int x = 0; x < marketbuttons.Length; x++)
        {
            marketbuttons[x].Setup(this);
        }

        for (int x = 0; x < cantinappl.Length; x++)
        {
            cantinappl[x].SetActive(false);
        }

        SetupPlanet();
    }

    public void SetupPlanet()
    {
        cantinappl[ Singleton.data.plyr.planet-1 ].SetActive( true );

        if (Singleton.data.plyr.planet == 1)
        {
            pname.text = "The Emerald Planet";
            //pdesc.text = "The busiest planet with the\nmost people living on it.\nThis planets population\nexploded rapidly due to all\nof the highly valued\nmaterials on it.\nWith quick growth comes\nlots of crime though.";
        }
        else if (Singleton.data.plyr.planet == 2)
        {
            pname.text = "New Earth";
            //pdesc.text = "An earth like planet!";
        }
        else if (Singleton.data.plyr.planet == 3)
        {
            pname.text = "Santigo 3G";
            //pdesc.text = "A very hot planet with\ntripple the Earths gravity. Aside from the space port above the planet, there is not a lot of activity on the surface other than mining.";
        }
        else
        {
            pname.text = "MISSINGNO";
            //pdesc.text = "Description.";
        }

        pdesc.text = "Select an action to the left.\n\nPlanet stats coming soon.";

        cantina.SetActive(false);
        market.SetActive(false);
        mines.SetActive(false);
    }

    public bool Leave()
    {
        if( Singleton.data.plyr.goods[3] > 0 )
        {
            Singleton.data.plyr.goods[3]--;

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
            if (Singleton.data.plyr.planet == 1)
            {
                pname.text = "The Green Cantina";
                pdesc.text = "";
                cantina.SetActive(true);
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                pname.text = "The Rusty Wrynn";
                pdesc.text = "";
                cantina.SetActive(true);
            }
            else if (Singleton.data.plyr.planet == 3)
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
        else if (bt == GameButtonType.Repair)
        {
            if( Singleton.data.plyr.hullmax > Singleton.data.plyr.hull)
            {
                if (!cheap)
                {
                    int damage = Singleton.data.plyr.hullmax - Singleton.data.plyr.hull;
                    int cost = damage * 50;

                    if (Singleton.data.plyr.credits >= cost)
                    {
                        Singleton.data.plyr.credits -= cost;
                        Singleton.data.plyr.hull = Singleton.data.plyr.hullmax;
                    }
                    else
                    {
                        cheap = true;
                        pdesc.text = "You cannot afford the " + cost + " credits needed for repairs.";
                        pdesc.text = pdesc.text + "\n\nClick again to buy them in 50 credit increments (+1 hull).";
                    }
                }
                else
                {
                    if (Singleton.data.plyr.credits >= 50)
                    {
                        Singleton.data.plyr.credits -= 50;
                        Singleton.data.plyr.hull++;
                    }
                    else
                    {
                        //cheap = true;
                        pdesc.text = "You cannot afford the 50 credits needed for 1 hull repair.";
                    }
                }
             }
            else
            {
                pdesc.text = "Your ship does not need repairs.";
            }
        }
        else if (bt == GameButtonType.Quest)
        {
            cantina.SetActive(true);

            if (Singleton.data.plyr.planet == 1)
            {
                // YES
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                // YES
            }
            else if (Singleton.data.plyr.planet == 3)
            {
                // NO
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Description.";
            }
        }
        else if (bt == GameButtonType.Market )
        {
            if (Singleton.data.plyr.planet == 1)
            {
                pname.text = "The Green Market";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                pname.text = "The Overground";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 3)
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
            if (Singleton.data.plyr.planet == 1)
            {
                pname.text = "The Green Mines";
                pdesc.text = "";
                mines.SetActive(true);
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                pname.text = "New Earth";
                pdesc.text = "You cannot mine here.";
            }
            else if (Singleton.data.plyr.planet == 3)
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

            if (Singleton.data.plyr.goods[3] > 0)
            {
                Singleton.data.plyr.goods[3]--;

                if (Singleton.data.plyr.planet == 1)
                {
                    float r = Random.Range(1, 100);

                    if( r < 25 )
                    {
                        pdesc.text = "You were unable to find anything!";
                    }
                    else if (r < 80)
                    {
                        float c = Random.Range(1, 250);
                        Singleton.data.plyr.credits += c;
                        pdesc.text = "You mined some material worth " + c + " credits!";
                    }
                    else
                    {
                        Singleton.data.plyr.goods[2]++;
                        pdesc.text = "You mined some green crystal!";
                    }
                }
                else if (Singleton.data.plyr.planet == 2)
                {
                    //
                }
                else if (Singleton.data.plyr.planet == 3)
                {
                    float r = Random.Range(1, 100);

                    if (r < 25)
                    {
                        pdesc.text = "You were unable to find anything!";
                    }
                    else if (r < 80)
                    {
                        float c = Random.Range(1, 250);
                        Singleton.data.plyr.credits += c;
                        pdesc.text = "You mined some material worth " + c + " credits!";
                    }
                    else
                    {
                        Singleton.data.plyr.goods[3]++;
                        pdesc.text = "You struck oil, the fuel has been added to your cargo!";
                    }
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
            if (Singleton.data.plyr.planet == 1)
            {
                pname.text = "The Green Planet";
                pdesc.text = "Sorry, you cannot yet explore this planet.";
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                pname.text = "New Earth";
                pdesc.text = "There is not much on this planet left to explore.";
            }
            else if (Singleton.data.plyr.planet == 3)
            {
                pname.text = "Santigo 3G";
                pdesc.text = "Sorry, you cannot yet explore this planet.";
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

    public int getCapacityUse()
    {
        return Singleton.data.plyr.goods[1] + Singleton.data.plyr.goods[2] + Singleton.data.plyr.goods[3] + Singleton.data.plyr.goods[4] + Singleton.data.plyr.goods[5];
    }

    public void MarketClick( StoreButton item, bool buy )
    {
        if( buy )
        {
            int cap = getCapacityUse();
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Singleton.data.plyr.credits >= Singleton.data.prices[item.id] * 10 && (Singleton.data.plyr.capmax - cap) >= 10)
                {
                    Singleton.data.plyr.credits -= Singleton.data.prices[item.id] * 10;
                    Singleton.data.plyr.goods[item.id] += 10;
                }
            }
            else if (Singleton.data.plyr.credits >= Singleton.data.prices[item.id] && cap < Singleton.data.plyr.capmax)
            {
                Singleton.data.plyr.credits -= Singleton.data.prices[item.id];
                Singleton.data.plyr.goods[item.id]++;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Singleton.data.plyr.goods[item.id] >= 10)
                {
                    Singleton.data.plyr.credits += Mathf.Round(Singleton.data.prices[item.id] * 10 * .8F);
                    Singleton.data.plyr.goods[item.id] -= 10;
                }
            }
            else if (Singleton.data.plyr.goods[item.id] >= 1)
            {
                Singleton.data.plyr.credits += Mathf.Round(Singleton.data.prices[item.id] * .8F);
                Singleton.data.plyr.goods[item.id]--;
            }
        }
    }

    void Update ()
    {
        int cap = getCapacityUse();

        ship1.text = Singleton.data.plyr.shipname + "\nHull: " + Singleton.data.plyr.hull + " / " + Singleton.data.plyr.hullmax + "\nWeapons: " + Singleton.data.plyr.weapons + "\nSpeed: " + Singleton.data.plyr.speed;
        ship2.text = "Capacity: " + cap + " / " + Singleton.data.plyr.capmax + "\nFuel: " + Singleton.data.plyr.goods[3] + "\nCredits: " + Singleton.data.plyr.credits + "\nQuests: 0";

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}