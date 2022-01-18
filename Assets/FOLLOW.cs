using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOLLOW : MonoBehaviour
{
    public Transform playertransform;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playertransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playertransform.position + offset;
    }
}
