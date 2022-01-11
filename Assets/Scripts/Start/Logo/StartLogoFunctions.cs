using UnityEngine;

public class StartLogoFunctions : MonoBehaviour
{    
    Animator animator;
    AudioSource audioSource;
    public AudioClip selectUi;
    void Start(){
        (animator, audioSource) = (GetComponent<Animator>(), GetComponent<AudioSource>());
    }
    public void CloseStartScene(){
        animator.SetTrigger("Close");
        audioSource.PlayOneShot(selectUi);
    }
}
