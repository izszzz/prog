using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject screenManager;
    public GameObject cardsContainer;
    public GameObject cardPrefab;
    public GameObject newScreen;
    public Sprite[] sprites;
    ScreenManager screenManagerScript;
    Animator newScreenAnimator;
    void Start()
    {
        screenManagerScript = screenManager.GetComponent<ScreenManager>();
        newScreenAnimator = newScreen.GetComponent<Animator>();
        AddCards();
    }

    void AddCards(){
        var (pos, index) = (cardsContainer.transform.position, 0);
        foreach(var sprite in sprites){
            var card = Instantiate(cardPrefab, new Vector3(pos.x+index*4, pos.y, pos.z), Quaternion.identity, cardsContainer.transform).GetComponent<Card>();
            card.sprite = sprite;
            card.id = index++;
            card.onClick = OpenPanel();
        }
    }
    public Action<int> OpenPanel(){
        return (int id) => {
            var go = screenManagerScript;
            screenManagerScript.OpenPanel(newScreenAnimator); 
            SetPanel(go, id);
        };
    }

    public virtual void SetPanel(ScreenManager go, int id){}
}
