using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    private Vector3 targetPos;
    /*
    public Car (Vector3 pos)
    {
        targetPos = pos;

    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoTargetPosition(Vector3 vec)
    {
        transform.DOMove(vec,0.5f).SetEase(Ease.InOutSine);
        targetPos = vec;
    }


}
