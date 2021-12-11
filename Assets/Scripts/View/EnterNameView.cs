using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterNameView : MenuViewBase, IRequireDependency<ScoreController>
{
    [SerializeField] private TMP_Text _yourScoreText;
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private Button _enterButton;
    [SerializeField] private Button _skipButton;
    private ScoreController _scoreController;

    private void OnEnable()
    {
        _enterButton.onClick.AddListener(() =>
        {
            EnterName();
        });
        _skipButton.onClick.AddListener(() =>
        {
            Skip();
        });
    }

    private void OnDisable()
    {
        _enterButton.onClick.RemoveAllListeners();
        _enterButton.onClick.RemoveAllListeners();
    }

    protected override void Show()
    {
        base.Show();
        _yourScoreText.text = $"Your score\n{_scoreController.CurrentScore}";
    }

    private void EnterName()
    {
        if (!string.IsNullOrWhiteSpace(_nameField.text))
        {
            _scoreController.CheckNewResult(_nameField.text);
            _scoreController.ResetScore();
            _menuController.SwitchMenu(MenuTypes.HighScore);
        }
        else
        {
            _yourScoreText.text = $"Enter name !!!";
        }
    }

    private void Skip()
    {
        _scoreController.ResetScore();
        _menuController.SwitchMenu(MenuTypes.MainMenu);
    }

    public void AssignDependency(ScoreController dependency)
    {
        _scoreController = dependency;
    }
}
