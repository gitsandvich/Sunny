using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class player : MonoBehaviour
{
	public Transform Spawn_Point;
	public Rigidbody2D rb;
	public float speed = 5;
	public Vector2 player_movement =new Vector2(0,0);
	public bool canJump = false;
	public Animator anim;
	public bool isHurt = false;
	public float push_x, push_y;

	public bool is_Invincible = false;
	public float jump_y;
	public GameObject Camera;
	public float Invincible_Time, Invincible_Countdown;
	public SpriteRenderer Player_SR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
		if (coll.gameObject.name.Contains("Frog") && is_Invincible == false)
		{
			if (this.transform.position.y-0.2f > coll.transform.position.y)
            {
				rb.AddForce(new Vector2(0, push_y));

				if(coll.gameObject.GetComponent<Monster_State>().Hostile == true)
                {
					
					coll.gameObject.GetComponent<Monster_State>().Death();
				}
				return;
			}

			if (GameCache.HP > 0)
			{
				GameCache.HP--;				
				Invincible_Countdown = 0;
			}
			anim.SetInteger("Health",GameCache.HP);
			isHurt = true;
		    anim.SetTrigger("Hurting");
		    Debug.Log("oh no a frog");		
			if(GameCache.HP ==0)
            {
				return;
            }
			else
            {
				is_Invincible = true;
			}

		    if (this.transform.position.x < coll.transform.position.x)
		    {
			    rb.AddForce(new Vector2(-push_x,push_y));
		    }
		    else
		    {
			    rb.AddForce(new Vector2(push_x,push_y));
		    }
	    }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
	    if (coll.gameObject.name == ("Jump_area") &&  rb.velocity.y ==0)
	    {
		    canJump = true;
	    }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
	    Debug.Log("OnAir");
	    canJump = false;
    }
    
    // Update is called once per frame
    void Update()
    { 
	/*
	float Horizontal = Input.GetAxis("Horizontal");
	float Vertical = Input.GetAxis("Vertical");
	*/
	if(is_Invincible == true)
    {
			Invincible_Countdown += Time.deltaTime;
			Player_SR.color = new Vector4(1, Invincible_Countdown/Invincible_Time, Invincible_Countdown / Invincible_Time, 1);
			if(Invincible_Countdown > Invincible_Time)
            {
				is_Invincible = false;
            }
    }
			

	if (isHurt == false)
	{
		if (Input.GetKey(KeyCode.A))
		{
			rb.velocity = new Vector2(-5, rb.velocity.y);
			transform.localScale = new Vector2(-1, 1);
			anim.SetBool("isRunning",true);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			rb.velocity = new Vector2(5, rb.velocity.y);
			transform.localScale = new Vector2(1, 1);
			anim.SetBool("isRunning",true);
		}
		else
		{
			anim.SetBool("isRunning",false);
		}

		if (canJump == true && Input.GetKey("space"))
		{
			canJump = false;
			rb.AddForce(new Vector2(0,jump_y));
		}
	}
	
	/*
	if (rb.velocity.y ==0)
	{
		canJump = true;
	}
	*/
	
	
	
	//player_movement = new Vector2(Horizontal,Vertical);
		/*
		Vector3 tempVect = new Vector3(Horizontal, Vertical, 1);
		tempVect = tempVect.normalized * speed * Time.deltaTime;
		rb.MovePosition(transform.position + tempVect);
		*/
		
		//rb.AddForce(player_movement * speed);
		/*
		if (Mathf.Abs(Input.GetAxis("Horizontal")) >0)
		{
			rb.MovePosition(transform.position + player_movement* speed *Time.deltaTime);
		}
		*/
		//rb.velocity = player_movement;

    }
	public void Death()
    {
		Camera.GetComponent<CinemachineVirtualCamera>().enabled = false;
		isHurt = true;
	}

	public void Respawn()
    {
		GameCache.HP = 3;
		this.transform.position = new Vector3(Spawn_Point.position.x, Spawn_Point.position.y,0);
		Camera.GetComponent<CinemachineVirtualCamera>().enabled = true;
		anim.SetTrigger("Respawn");
		isHurt = false;
	}
	public void isHurt_Trigger_off()
	{
		isHurt = false;
	}


}
