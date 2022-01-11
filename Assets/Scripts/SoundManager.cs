using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySE(AudioClip audioClip){
        audioSource.PlayOneShot(audioClip);
    }
}
