using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterNameView : MenuViewBase
{
    [SerializeField] private TMP_Text _yourScoreText;
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private Button _enterButton;
    [SerializeField] private Button _skipButton;

    private void OnEnable()
    {
        _enterButton.onClick.AddListener(() =>
        {

            _menuController.SwitchMenu(MenuTypes.HighScore);
        });
        _skipButton.onClick.AddListener(() =>
        {
            _menuController.SwitchMenu(MenuTypes.MainMenu);
        });
    }

    private void OnDisable()
    {
        _enterButton.onClick.RemoveAllListeners();
        _enterButton.onClick.RemoveAllListeners();
    }
}
