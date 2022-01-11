using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject screenManager;
    public GameObject soundManager;
    public GameObject cardsContainer;
    public GameObject cardPrefab;
    public GameObject newScreen;
    public Sprite[] sprites;
    ScreenManager screenManagerScript;
    SoundManager soundManagerScript;
    Animator newScreenAnimator;
    void Start()
    {
        screenManagerScript = screenManager.GetComponent<ScreenManager>();
        soundManagerScript = soundManager.GetComponent<SoundManager>();
        newScreenAnimator = newScreen.GetComponent<Animator>();
        AddCards();
    }

    void AddCards(){
        var (pos, index) = (cardsContainer.transform.position, 0);
        foreach(var sprite in sprites){
            var card = Instantiate(cardPrefab, new Vector3(pos.x+index*4, pos.y, pos.z), Quaternion.identity, cardsContainer.transform).GetComponent<Card>();
            card.sprite = sprite;
            card.id = index++;
            card.OnPointerClick = CardPointerClick();
            card.OnPointerEnter = CardPointerEnter();
        }
    }
    public Action<int, AudioClip> CardPointerClick(){
        return (int id, AudioClip audioSource) => {
            screenManagerScript.OpenPanel(newScreenAnimator); 
            SetPanel(screenManagerScript, id);
            soundManagerScript.PlaySE(audioSource);
        };
    }
    public Action<int, AudioClip> CardPointerEnter(){
        return (int id, AudioClip audioSource) => soundManagerScript.PlaySE(audioSource);
    }

    public virtual void SetPanel(ScreenManager go, int id){}
}
