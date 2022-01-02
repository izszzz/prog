using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PackagesManager : MenuManager
{

    void AddCards(){
        var pos = cardsContainer.transform.position;
        var index = 0;
        foreach(var sprite in sprites){
            var go = Instantiate(cardPrefab, new Vector3(pos.x+index*4, pos.y, pos.z), Quaternion.identity, cardsContainer.transform);
            var card = go.GetComponent<Card>();
            card.sprite = sprite;
            card.id = index++;
            card.onClick = OpenMusicsPanel();
        }
    }
    Action<int> OpenMusicsPanel(){
        return (int id) => {
        };
    }
    public override void SetPanel(ScreenManager go, int id){
        go.packageId = id;
    }
}
