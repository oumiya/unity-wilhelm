using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Vector2 pointA;
    private Vector2 pointB;

    public GameObject arrow;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            pointA = transform.position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pointB = transform.position;
            Vector2 diff = pointB;
            diff = diff - pointA;
            if (diff.magnitude > 0.01)
            {
 //               transform.rotation = Quaternion.LookRotation(Vector3.forward, diff) * Quaternion.Euler(0, 0, -90f);
                GameObject shot = Instantiate(arrow, transform.position, transform.rotation);
                shot.GetComponent<Rigidbody2D>().velocity = -diff * 5f;
                shot.transform.rotation = Quaternion.LookRotation(Vector3.forward, -diff);
            }

        }

    }
}
