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
    public int speed=5;
    public bool b = false;
    public Slider slider1;//能量点
    float chongci = 5.0f;
    float time1 = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("游戏开始");
        rd = GetComponent<Rigidbody>();
        scoreText = GameObject.Find("number").GetComponent<Text>();
        slider1.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("游戏正在运行中");
        //rd.AddForce(Vector3.right);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log(h);
        rd.velocity = new Vector3(h*speed, 0, v*speed);
        slider1.value = chongci / 5;
        if (Input.GetKey(KeyCode.LeftShift) && chongci > 0)
        {
            time1 = 2;
            chongci -= Time.deltaTime;
            rd.velocity *= 2;
            Debug.Log(rd.velocity);
        }
        else
        {
            if(time1>0&&!Input.GetKey(KeyCode.LeftShift)&&chongci<5)
            {
                time1 -= Time.deltaTime;
            }
            else if(chongci<5&&time1<=0)
            {
                chongci += Time.deltaTime;
                if(chongci>=5)
                {
                    time1 = 2.0f;
                    chongci = 5;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("peng");
        if(collision.gameObject.tag=="food")
        {
            Destroy(collision.gameObject);
            num++;
            Debug.Log("num=" + num);
            scoreText.text = "分数为:" + num;
            if (num == 5)
            {
                wintext.SetActive(true);
            }
        }
    }
    private void CollisionEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            Destroy(other.gameObject);
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        var yk = collision.transform.GetComponent<Treeblood>();
        if (collision.gameObject.tag=="tree")
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                yk.b = true;
            }
            
        } 
    }
}
        