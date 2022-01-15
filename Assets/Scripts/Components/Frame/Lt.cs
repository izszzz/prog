using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lt : MonoBehaviour
{
    Animator animator;
    public Action<AudioClip> OnPointerClick;
    public Action<AudioClip> OnPointerEnter;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void PointerEnter(AudioClip pointerEnterSound){
        HoverAnimator(true);
        OnPointerEnter(pointerEnterSound);
    } 
    public void PointerExit(){
        HoverAnimator(false);
    } 

    public void PointerClick(AudioClip clickSound){
        OnPointerClick(clickSound);
    }
    public void OpenStartScene()=>SceneManager.LoadScene("Scenes/Start", LoadSceneMode.Single);
    void HoverAnimator(bool boolean)=>animator.SetBool("Hover", boolean);
}
