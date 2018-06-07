using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
/*    void OnTriggerEnter2D(Collider2D c)
    {
        Destroy(c.gameObject);
    }
*/    void OnTriggerExit2D(Collider2D c)
    {
        Destroy(c.gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
