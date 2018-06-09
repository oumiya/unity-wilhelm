﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// オブジェクトが描画されなくなったらデストロイ
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
	}
}
