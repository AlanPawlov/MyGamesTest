using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuView : MenuViewBase
{
    #region Fields

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _hiScoresButton;
    public Action OnPlayButtonClick = delegate { };

    #endregion

    #region Unity Methods
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
    #endregion
}
