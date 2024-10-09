﻿using UnityEngine;
using System.Collections;

public class BlockDestroyEffect : MonoBehaviour {
	public Vector2 forceMin, forceMax;
	public float timeToLive = 2f;
	Rigidbody2D rig;
	BoxCollider2D col;
	SpriteRenderer rend;
	Color color;
	float alpha = 1;
	float delayToCollision = 0.3f;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
		rend = GetComponent<SpriteRenderer> ();
		col = GetComponent<BoxCollider2D> ();
		col.enabled = false;
		color = rend.color;

		rig.velocity = new Vector2 (Random.Range (forceMin.x, forceMax.x), Random.Range (forceMin.y, forceMax.y));
		rig.AddTorque (Random.Range (100, 1000));
	}
	
	// Update is called once per frame
	void Update () {
		timeToLive -= Time.deltaTime;
		delayToCollision -= Time.deltaTime;

		if (delayToCollision <= 0)
			col.enabled = true;
		
		if (timeToLive > 0)
			return;
		alpha = Mathf.Lerp (alpha, 0, 0.05f);
		color.a = alpha;
		rend.color = color;

		if (alpha < 0.05f)
			Destroy (gameObject);
	}
}
