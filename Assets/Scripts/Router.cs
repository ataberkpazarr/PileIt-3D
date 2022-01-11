using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Router : MonoBehaviour
{
    public static Action RotationHappening;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("aaaa");
        //other.transform.Rotate(0, 0, 80 * Time.deltaTime);
        RotationHappening.Invoke();
        Quaternion targetQuaternion = Quaternion.Euler(0,0,80*Time.deltaTime);
        Quaternion currentQuat = other.transform.rotation;

        Quaternion combinedQuaternion = targetQuaternion * currentQuat;
        other.transform.rotation = Quaternion.Slerp(other.transform.rotation,combinedQuaternion,   0* Time.deltaTime);

    }
}
