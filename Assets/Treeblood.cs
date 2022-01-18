using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treeblood : MonoBehaviour
{
    private static int blood = 100;
    public GameObject apple;
    private bool lengque = true;
    public float timer = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(lengque==false)//判断是否产生过了苹果
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                lengque = true;
                timer = 20.0f;
            }

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name=="player")
        {
            if(collision.gameObject.GetComponent<player>().b==true)
            {
                blood--;
                if(blood<95)
                {
                    GameObject.Instantiate(apple, transform.position-new Vector3(-1,4,-5), transform.rotation);
                    blood = 100;
                    lengque = false;
                }
            }
        }
    }
}
