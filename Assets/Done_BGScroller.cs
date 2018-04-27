using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float scrollSpeed;
	//public float tileSizeZ;

	private Vector3 startPosition;
	public float TileSize;
	private float tilesize;
	void Start ()
	{
		startPosition = transform.position;

	}

	void Update ()
	{
		tilesize = (transform.localScale.x)*TileSize;
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tilesize);
		transform.position = startPosition + Vector3.right * newPosition;
	}
}