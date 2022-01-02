using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPackagesLtFunctions : MonoBehaviour
{
    Animator animator;
    void Start(){
        this.animator = GetComponent<Animator>();
    }
    public void PointerEnter(){
        this.animator.SetBool("Hover",true);
    }
    public void PointerExit(){
        this.animator.SetBool("Hover", false);
    }

    public void PointerUp(){
        SceneManager.LoadScene ("Scenes/Start", LoadSceneMode.Single);
    }
}
