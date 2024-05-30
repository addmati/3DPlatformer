using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerConditions condition;

    public ItemData itemData;
    public Action addItem;//µ®∏Æ∞‘¿Ã∆Æ

    public Transform dropPosition;
    
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerConditions>();
    }
}
