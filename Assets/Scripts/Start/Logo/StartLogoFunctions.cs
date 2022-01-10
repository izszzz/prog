using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLogoFunctions : MonoBehaviour
{    
    Animator animator;
    AudioSource audioSource;
    public AudioClip selectUi;
    void Start(){
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void CloseStartScene(){
        animator.SetTrigger("Close");
        audioSource.PlayOneShot(selectUi);
    }
}
