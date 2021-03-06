﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Vector3 pointA;
    private Vector3 pointB;

    private enum TellStatus { Idle, Draw, Fire, Reload, Freeze};
    private TellStatus tellState;

    private AudioSource soundStress;

    public GameObject arrow;
    // Use this for initialization
    void Start () {
        tellState = TellStatus.Idle;

        GameObject releaseString = GameObject.Find("ReleaseString");
        releaseString.GetComponent<Renderer>().enabled = false;

        soundStress = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {

        if (tellState == TellStatus.Idle)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pointA = transform.position;
                tellState = TellStatus.Draw;
            }
        }

        if (tellState == TellStatus.Draw)
        {


            if (!soundStress.isPlaying)
            {
                soundStress.Play();
            }

            if(Input.GetMouseButton(0)){

                pointB = transform.position;
                Vector3 diff = pointB;
                diff = diff - pointA;
                if (diff.magnitude > 0.01)
                {
                    GameObject LeftHand = GameObject.Find("LeftHand");
                    GameObject DrawString = GameObject.Find("DrawString");
                    LeftHand.transform.rotation = Quaternion.FromToRotation(Vector3.left, diff);
                    DrawString.transform.rotation = LeftHand.transform.rotation;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                pointB = transform.position;
                Vector3 diff = pointB;
                diff = diff - pointA;
                if (diff.magnitude > 0.01)
                {
                    //               transform.rotation = Quaternion.LookRotation(Vector3.forward, diff) * Quaternion.Euler(0, 0, -90f);
                    //GameObject shot = Instantiate(arrow, transform.position, transform.rotation);
                    Vector3 defaultPosition = new Vector3(-5.42f, -0.6900001f, 0f);
                    GameObject shot = Instantiate(arrow, defaultPosition, transform.rotation);
                    shot.GetComponent<Rigidbody2D>().velocity = -diff * 5f;
                    shot.transform.rotation = Quaternion.LookRotation(Vector3.forward, -diff);
                }

                soundStress.Stop();

                GameObject drawString = GameObject.Find("DrawString");
                GameObject releaseString = GameObject.Find("ReleaseString");
                releaseString.transform.rotation = drawString.transform.rotation;
                drawString.GetComponent<Renderer>().enabled = false;
                releaseString.GetComponent<Renderer>().enabled = true;

                tellState = TellStatus.Fire;
            }
        }

        if (tellState == TellStatus.Fire)
        {
            // 特に何もしない
        }

        if (tellState == TellStatus.Reload)
        {
            GameObject drawString = GameObject.Find("DrawString");
            drawString.GetComponent<Renderer>().enabled = true;
            GameObject releaseString = GameObject.Find("ReleaseString");
            releaseString.GetComponent<Renderer>().enabled = false;
            tellState = TellStatus.Idle;
        }

        if (tellState == TellStatus.Freeze)
        {
            // 操作を受け付けない
        }

    }

    public void SetStateReload()
    {
        tellState = TellStatus.Reload;
    }

    public void SetStateFreeze()
    {
        tellState = TellStatus.Freeze;
    }
}
