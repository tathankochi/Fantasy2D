using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDead : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetD()
    {
        animator.SetBool("Destroy", true);
    }
}