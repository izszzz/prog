using System;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int id;
    public Sprite sprite;
    public GameObject content;
    public Action<AudioClip, int> OnPointerClick;
    public Action<AudioClip> OnPointerEnter;
    public AudioClip clickSound;
    public AudioClip pointerEnterSound;
    AudioSource audioSource;
    void Start()
    {
        content.GetComponent<Image>().sprite = sprite;
    }

    public void PointerClick()=>OnPointerClick(clickSound, id);
    public void PointerEnter()=>OnPointerEnter(pointerEnterSound);
}
