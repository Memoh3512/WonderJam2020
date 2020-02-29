﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool fist = false;
    public bool spread = false; //TODO 
    public float rpm = 120;
    public int dmgPerBullet = 1;

    public GameObject bullet;
    private ArrayList bullets;
    public float barrelLenght;
    public float gunLenght;
    private bool rightP=true;

    private GameObject RightPunch;
    private GameObject LeftPunch;
    private float originalPos;

    public void Shoot(float angle)
    {
        if (!fist)
        {
            GameObject tempBullet = Instantiate(bullet,
            new Vector3(transform.position.x + barrelLenght * Mathf.Cos((angle) * Mathf.Deg2Rad),
                transform.position.y + barrelLenght * Mathf.Sin((angle) * Mathf.Deg2Rad), transform.position.z),
            transform.rotation);
        tempBullet.GetComponent<BulletScript>().damage = dmgPerBullet;
        }
        else
        {
            GameObject currHand;
            if (rightP)
                currHand = RightPunch;
            else
                currHand = LeftPunch;
            currHand.GetComponent<GlovesScript>().Shoot();
            if (rightP)
                rightP = false;
            else
                rightP = true;
        }
    }

    public void Start()
    {
        if (fist)
        {
            RightPunch = transform.GetChild(1).gameObject;
            LeftPunch = transform.GetChild(0).gameObject;
            originalPos = transform.GetChild(0).localPosition.y;
        }
        
    }
}