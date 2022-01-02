﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public int id;
    public Sprite sprite;
    public GameObject content;
    public Action<int> onClick;
    void Start()
    {
        content.GetComponent<Image>().sprite = sprite;
        AddEventTrigger();
    }

    void AddEventTrigger(){
        EventTrigger trigger = this.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { 
            onClick(id);
        });
        trigger.triggers.Add(entry); 
    }
    
}