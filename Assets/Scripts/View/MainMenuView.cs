using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuView : MenuViewBase
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _hiScoresButton;
    public Action OnPlayButtonClick = delegate { };

    private void OnEnable()
    {
        _playButton.onClick.AddListener(() =>
        {
            _menuController.SwitchMenu(MenuTypes.GameplayUI);
            _menuController.PlayGame();
        });
        _hiScoresButton.onClick.AddListener(() =>
        {
            _menuController.SwitchMenu(MenuTypes.HighScore);
        });
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveAllListeners();
        _hiScoresButton.onClick.RemoveAllListeners();
    }
}
