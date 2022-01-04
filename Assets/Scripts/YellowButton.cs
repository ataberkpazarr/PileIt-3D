using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Parent_ = transform.parent.gameObject;
        anim = Parent_.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        anim.SetBool("ButtonClicked",true);
    }
}
