﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    public Button optionButton;
    public GameObject gameField;

    private bool gameFieldVisible = false;

    // Use this for initialization
    void Start () {
        Button optBtn = optionButton.GetComponent<Button>();
        optBtn.onClick.AddListener(GoToMainMenu);

        ShowGameField();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowGameField()
    {
        gameFieldVisible = true;
        gameField.GetComponent<Animation>().Play("game_field_appearance");
    }

    IEnumerable<WaitForSeconds> HideGameField()
    {
        gameFieldVisible = false;
        gameField.GetComponent<Animation>().Play("game_field_disappearance");
        yield return new WaitForSeconds(2);
    }

    void GoToMainMenu()
    {
        IEnumerable<WaitForSeconds> runEnumerable = HideGameField();
        Debug.Log("You have clicked IN_GAME_OPTION button!");
        SceneManager.LoadScene("MainMenu");
    }
}
