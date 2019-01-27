using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MenuCharacter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


    public bool isSelected;
    public string name;
    public specialization specialization;
    public int id;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;
    public string profileInfo;
    public Sprite inGameImage;

    [SerializeField]
    private GameObject profile;
    [SerializeField]
    private TextMeshProUGUI profileName;
    [SerializeField]
    private TextMeshProUGUI info;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        profileName.text = name;
        info.text = profileInfo;
        profile.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        profile.SetActive(false);
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
