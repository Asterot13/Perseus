using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MainMenu : MonoBehaviour {

    public int maxPlayerCount;

    public GameObject mainSection;
    public GameObject characterSection;
    public GameObject startLevelButton;
    private List<MenuCharacter> selectedCharacters = new List<MenuCharacter>();
    [SerializeField]
    private List<MenuCharacter> characters = new List<MenuCharacter>();

	// Use this for initialization
	private void Awake () {
        mainSection.SetActive(true);
        characterSection.SetActive(false);
        startLevelButton.SetActive(false);
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
		if(selectedCharacters.Count == maxPlayerCount)
        {
            startLevelButton.SetActive(true);
        }
        else
        {
            startLevelButton.SetActive(false);
        }
	}

    public void quitGame()
    {
        Application.Quit();
    }

    public void goToCrewSelection()
    {
        mainSection.SetActive(false);
        characterSection.SetActive(true);
    }

    public void goBackToMain()
    {
        mainSection.SetActive(true);
        characterSection.SetActive(false);
        
    }

    public void startLevel()
    {
        SceneManager.LoadScene(""); //TODO: ADD LEVEL
    }


    public void selectUnselectCharacter(int characterID)
    {
        MenuCharacter character = characters.FirstOrDefault(c => c.id == characterID);
        if (!character.isSelected)
        {
            character.isSelected = true;
            character.showActiveImage();
            selectedCharacters.Add(character);
        }
        else if (character.isSelected)
        {
            character.isSelected = false;
            character.hideActiveImage();
            selectedCharacters.Remove(character);
        }
    }

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseExit()
    {
        
    }

}
