using UnityEngine;
using System.Collections;

public class textureScrolling : MonoBehaviour {

	private Renderer rend;
	public Vector2 scrolling;

	void Start()
	{
		rend = GetComponentInChildren<Renderer>();
	}
	
	void Update () {
		rend.material.SetTextureOffset("_MainTex", new Vector2(scrolling.x * Time.time, scrolling.y * Time.time));
	}
}
