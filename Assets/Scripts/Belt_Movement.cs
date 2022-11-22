using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt_Movement : MonoBehaviour
{
    public float x_push;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        //ebug.Log("standing" + coll.gameObject.name);
        if (coll.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            //Debug.Log("Moving" + coll.gameObject.name);
            //Debug.Log("Moving" + coll.gameObject.GetComponent<Rigidbody2D>().mass * x_push);
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(coll.gameObject.GetComponent<Rigidbody2D>().mass * x_push, 0));
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        coll.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero ;
    }
    // Update is called once per frame
    
}
