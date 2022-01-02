using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLogoFunctions : MonoBehaviour
{    
    Animator animator;
    void Start(){
        this.animator = GetComponent<Animator>();
    }
    public void CloseStartScene(){
        this.animator.SetTrigger("Close");
    }
}
