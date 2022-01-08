using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class YellowButton : MonoBehaviour
{
    [SerializeField] AnimationClip buttonClickedAnim;
    [SerializeField] AnimationClip obstacleOpeningAnim;


    [SerializeField]private GameObject yellowObstacle;


    private Animator anim;
    private Animator yellowObstacleAnim;

    private bool gateAlreadyOpened = false;
    public static Action<float> yellowObstacleOpened;

    // Start is called before the first frame update
    void Start()
    {
        GameObject  Parent_ = transform.parent.gameObject;
        anim = Parent_.GetComponent<Animator>();
        yellowObstacleAnim = yellowObstacle.GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!gateAlreadyOpened)
        {

            gateAlreadyOpened = true;
            anim.SetBool("ButtonClicked", true);
            yellowObstacleAnim.SetBool("ButtonClicked", true);

            yellowObstacleOpened.Invoke(obstacleOpeningAnim.length);
            //Invoke("endTheAnimation", buttonClickedAnim.length - 0.5f);

            Invoke("EndClickAnimation", buttonClickedAnim.length - 0.5f);
            Invoke("EndObstacleAnimation", obstacleOpeningAnim.length + 0.1f);


        }
        //((Invoke("endTheAnimation",anim.GetCurrentAnimatorStateInfo(0).clip.length);


    }

    private void EndClickAnimation()
    {

        anim.SetBool("ButtonClicked",false);
        

    }

    private void EndObstacleAnimation()
    {

        yellowObstacleAnim.SetBool("ButtonClicked", false);
        gateAlreadyOpened = false;
    }
}
