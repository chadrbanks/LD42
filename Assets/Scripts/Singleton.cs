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


    public float credits = 200;
    public List<int> goods = new List<int>();
    public List<int> prices = new List<int>();
    public int ship = 0;
    public int planet = 0;

	void Awake()
	{
		if (data == null)
		{
			DontDestroyOnLoad(gameObject);
			data = this;
		}
		else if (data != this)
		{
			Destroy(gameObject);
		}
	}
}