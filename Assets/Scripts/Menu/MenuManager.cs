using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject screenManager;
    public GameObject cardsContainer;
    public GameObject cardPrefab;
    public GameObject newScreen;
    public Sprite[] sprites;
    void Start()
    {
        AddCards();
    }

    void AddCards(){
        var pos = cardsContainer.transform.position;
        var index = 0;
        foreach(var sprite in sprites){
            var go = Instantiate(cardPrefab, new Vector3(pos.x+index*4, pos.y, pos.z), Quaternion.identity, cardsContainer.transform);
            var card = go.GetComponent<Card>();
            card.sprite = sprite;
            card.id = index++;
            card.onClick = OpenPanel();
        }
    }
    public Action<int> OpenPanel(){
        return (int id) => {
            var go = screenManager.GetComponent<ScreenManager>();
            go.OpenPanel(newScreen.GetComponent<Animator>()); 
            SetPanel(go, id);
        };
    }

    public virtual void SetPanel(ScreenManager go, int id){
    }
}
