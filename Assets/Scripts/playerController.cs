using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D playerRb;

    private bool isMoving;
    public Vector2 lastMove;

    private static bool playerExists;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
	}
	
	// Update is called once per frame
	void Update () {

        isMoving = false;

	    if(Input.GetAxisRaw("Horizontal") > .5f || Input.GetAxisRaw("Horizontal") < -.5f) 
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRb.velocity.y); 
            isMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > .5f || Input.GetAxisRaw("Vertical") < -.5f)
        {
            // transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerRb.velocity = new Vector2(playerRb.velocity.x,Input.GetAxisRaw("Vertical") * moveSpeed);
            isMoving = true;
            lastMove = new Vector2(0f,Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetAxisRaw("Horizontal") < .5f && Input.GetAxisRaw("Horizontal") > -.5f)
        {
            playerRb.velocity = new Vector2(0f, playerRb.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < .5f && Input.GetAxisRaw("Vertical") > -.5f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0f);
        }

        anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("lastMoveX", lastMove.x);
        anim.SetFloat("lastMoveY", lastMove.y);
    }
}
