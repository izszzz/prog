using UnityEngine;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour
{
    public void OpenStartScene(){
        SceneManager.LoadScene("Scenes/Start", LoadSceneMode.Single);
    }
}
