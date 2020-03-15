using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
   
    private Vector3 platSPos;
    

    // Start is called before the first frame update
    void Start()
    {
        platSPos = transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(platSPos.x, platSPos.y + Mathf.Sin(Time.time) * 2f, platSPos.z);
       
    }
}
