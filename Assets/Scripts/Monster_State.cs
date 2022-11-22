using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_State : MonoBehaviour
{
    public bool Hostile = true;
    public bool is_Alive = true;
    public List<Transform> SpawnList;
    public Animator Enemy_anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    public void Death()
    {
        //Debug.Log("dead frog");
        Enemy_anim.SetTrigger("Dying");
        Hostile = false;
    }
    public void Respawn()
    {
        Enemy_anim.SetTrigger("Spawning");
        //Debug.Log("alive frog");
        this.transform.position = new Vector3(SpawnList[0].transform.position.x, SpawnList[0].transform.position.y, 0);
        Hostile = true;
    }
}
