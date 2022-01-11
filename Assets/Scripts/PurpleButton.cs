using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PurpleButton : MonoBehaviour
{
    

    [SerializeField] AnimationClip buttonClickedAnim;
    [SerializeField] AnimationClip obstacleOpeningAnim;
    private Animator anim;

    [SerializeField] private GameObject purpleObstacle;
    private Animator purpleObstacleAnim;
    private bool gateAlreadyOpened = false;
    public static Action <float>purpleObstacleOpened;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Parent_ = transform.parent.gameObject;
        anim = Parent_.GetComponent<Animator>();
        purpleObstacleAnim = purpleObstacle.GetComponent<Animator>();

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
            purpleObstacleAnim.SetBool("ButtonClicked", true);


            purpleObstacleOpened?.Invoke(obstacleOpeningAnim.length);
            Invoke("EndClickAnimation", buttonClickedAnim.length - 0.5f);
            Invoke("EndObstacleAnimation", obstacleOpeningAnim.length+0.1f);

        }
        //((Invoke("endTheAnimation",anim.GetCurrentAnimatorStateInfo(0).clip.length);


    }

    private void EndClickAnimation()
    {

        anim.SetBool("ButtonClicked", false);
     
    }

    private void EndObstacleAnimation()
    {
        purpleObstacleAnim.SetBool("ButtonClicked", false);
        gateAlreadyOpened = false;


    }
}
