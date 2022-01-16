using System;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public GameObject screenManager;
    public GameObject soundManager;
    public GameObject cardsContainer;
    public GameObject cardPrefab;
    public GameObject framePrefab;
    public GameObject newScreen;
    public Sprite[] sprites;
    ScreenManager screenManagerScript;
    SoundManager soundManagerScript;
    Animator newScreenAnimator;
    void Start()
    {
        screenManagerScript = screenManager.GetComponent<ScreenManager>();
        soundManagerScript = soundManager.GetComponent<SoundManager>();
        // if分消す↓
        if(newScreen) newScreenAnimator = newScreen.GetComponent<Animator>();
        if(cardPrefab) AddCards();
        if(framePrefab) SetFrame();
    }
    void SetFrame(){
        var frame = framePrefab.GetComponent<Frame>();
        if(frame.Lt){
            var lt = frame.Lt.GetComponent<Lt>();
            lt.OnPointerEnter = PlaySE();
            lt.OnPointerClick = PlaySE();
        }
        var rt = frame.Rt.GetComponent<Rt>();
        rt.OnPointerEnter = PlaySE();
        rt.OnPointerClick = PlaySE();
    }
    void AddCards(){
        var (pos, index) = (cardsContainer.transform.position, 0);
        foreach(var sprite in sprites){
            var card = Instantiate(cardPrefab, new Vector3(pos.x+index*4, pos.y, pos.z), Quaternion.identity, cardsContainer.transform).GetComponent<Card>();
            card.sprite = sprite;
            card.id = index++;
            card.OnPointerClick = CardPointerClick();
            card.OnPointerEnter = PlaySE();
        }
    }
    public Action<AudioClip, int> CardPointerClick() =>
        (AudioClip audioSource, int id) => {
            screenManagerScript.OpenPanel(newScreenAnimator); 
            PlaySE()(audioSource);
            SetPanel(screenManagerScript, id);
        };
    
    public Action<AudioClip> PlaySE()=> (AudioClip audioClip) => soundManagerScript.PlaySE(audioClip);
    public virtual void SetPanel(ScreenManager go, int id){}
}
