using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Rigidbody rd;
    public int num = 0;
    public Text scoreText;
    public GameObject wintext;
    public int speed=10;
    public bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("游戏开始");
        rd = GetComponent<Rigidbody>();
        scoreText = GameObject.Find("number").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("游戏正在运行中");
        //rd.AddForce(Vector3.right);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log(h);
        rd.AddForce(new Vector3(h, 0, v));

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("peng");
        if(collision.gameObject.tag=="food")
        {
            Destroy(collision.gameObject);
        }
    }
    private void CollisionEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            Destroy(other.gameObject);
            num++;
            scoreText.text = "分数为:" + num;
            if(num==5)
            {
                wintext.SetActive(true);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="tree")
        {
            if (Input.GetMouseButtonDown(0))
            {
                b= true;
            }
            else
            {
                b = false;
            }
        } 
    }
}
