using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReleasePlatform
{
	mac, windows
}
public enum ReleaseStatus
{
	development, production
}

[DisallowMultipleComponent]
public class Singleton : MonoBehaviour
{
	public static Singleton data;

	// CHANGE THESE IN UNITY!
	public string version = "0.0"; // CHANGE IN UNITY
	public ReleaseStatus status;
	public ReleasePlatform platform;
	public FloatText gft;

    public float credits = 0;
    public List<int> goods = new List<int>();
    public List<int> prices = new List<int>();
    public int ship = 0;
    public int planet = 0;

    public string shipname;
    public int speed, hull, hullmax, capmax, weapons;//, cap;

	void Awake()
	{
		if (data == null)
		{
			DontDestroyOnLoad(gameObject);
            data = this;
            Singleton.data.restartGame();
		}
		else if (data != this)
		{
			Destroy(gameObject);
		}
	}

    public void restartGame()
    {
        Singleton.data.ship = 0;
        Singleton.data.planet = 1;
        Singleton.data.credits = 200;

        Singleton.data.goods = new List<int>();
        Singleton.data.prices = new List<int>();

        Singleton.data.goods.Add(0);
        Singleton.data.goods.Add(0);
        Singleton.data.goods.Add(0);
        Singleton.data.goods.Add(3);
        Singleton.data.prices.Add(0);
        Singleton.data.prices.Add(Random.Range(1, 200));
        Singleton.data.prices.Add(Random.Range(1, 200));
        Singleton.data.prices.Add(Random.Range(1, 100));
    }
}