using UnityEngine;
using UnityEngine.SceneManagement;

public class Lt : MonoBehaviour
{
    Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    public void PointerHover(bool boolean) => animator.SetBool("Hover", boolean);

    public void PointerClick() => SceneManager.LoadScene("Scenes/Start", LoadSceneMode.Single);
}
