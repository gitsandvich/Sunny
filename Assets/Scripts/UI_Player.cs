using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    public List<Image> imageList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i > GameCache.HP - 1)
            {
                imageList[i].gameObject.SetActive(false);
            }
            else
            {
                imageList[i].gameObject.SetActive(true);
            }
        }

    }
}
