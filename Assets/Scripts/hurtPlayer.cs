using UnityEngine;
using System.Collections;

public class hurtPlayer : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerHealthManager>().HurtPlayer(damageToGive);
        }
    }
}
