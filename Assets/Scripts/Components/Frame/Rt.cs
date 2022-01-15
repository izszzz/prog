using System;
using UnityEngine;

public class Rt : MonoBehaviour
{
    public Action<AudioClip> OnPointerClick;
    public Action<AudioClip> OnPointerEnter;

    public void PointerClick(AudioClip clickSound){
        OnPointerClick(clickSound);
    }
    public void PointerEnter(AudioClip pointerEnterSound){
        OnPointerEnter(pointerEnterSound);
    }
}
