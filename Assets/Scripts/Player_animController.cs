using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animController : MonoBehaviour
{
    // Start is called before the first frame update

    public player p;
    // Update is called once per frame

    void isHurt_Trigger_off()
    {
        //isHurt = false;
        p.isHurt_Trigger_off();
    }
    void Respawn()
    {
        p.Respawn();
    }
    void Death()
    {
        p.Death();
    }
}
