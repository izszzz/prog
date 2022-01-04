using UnityEngine;
using UnityEngine.SceneManagement;

public class Lt : MonoBehaviour
{
    Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void PointerEnter(){ HoverEvent(true); }
    public void PointerExit(){ HoverEvent(false); }

    void HoverEvent(bool boolean){
        animator.SetBool("Hover", boolean);
    }

    public void PointerClick(){ SceneManager.LoadScene("Scenes/Start", LoadSceneMode.Single); }
}
