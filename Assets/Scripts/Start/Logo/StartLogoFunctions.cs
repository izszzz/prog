using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLogoFunctions : MonoBehaviour
{    
    Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void CloseStartScene(){
        animator.SetTrigger("Close");
    }
}
