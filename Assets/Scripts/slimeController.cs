﻿using UnityEngine;
using System.Collections;

public class slimeController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidBody;

    private bool isMoving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float waitToReload;
    private bool isReloading;
    private GameObject thePlayer;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        /*timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;*/

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * .7f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * .7f, timeToMove * 1.25f);

    }
	
	// Update is called once per frame
	void Update () {

        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                isMoving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * .7f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                isMoving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * .7f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        if (isReloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            isReloading = true;
            thePlayer = other.gameObject;
        }
    
    }
}
