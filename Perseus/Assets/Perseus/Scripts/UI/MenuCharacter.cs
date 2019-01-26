using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCharacter : MonoBehaviour {


    public bool isSelected;
    public string name;
    public specialization specialization;
    public int id;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    public void Start()
    {
        isSelected = false;

    }

    public void hideActiveImage()
    {
        GetComponent<Button>().image.sprite = unselectedSprite;
    }

    public void showActiveImage()
    {
        GetComponent<Button>().image.sprite = selectedSprite;
    }
}



public enum specialization
{
    MEDIC,
    ENGINEER,
    CAPITAIN,
    PHYSIC,
    GORDON
}
