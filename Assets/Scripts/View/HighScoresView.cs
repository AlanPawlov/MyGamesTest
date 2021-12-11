using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoresView : MenuViewBase, IRequireDependency<ScoreController>
{
    [SerializeField] private TMP_Text[] _scores = new TMP_Text[10];
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private ScoreController _scoreController;

    private void OnEnable()
    {
        _toMenuButton.onClick.AddListener(() => _menuController.SwitchMenu(MenuTypes.MainMenu));
    }

    private void OnDisable()
    {
        _toMenuButton.onClick.RemoveAllListeners();
    }

    protected override void Show()
    {
        base.Show();
        FillScores();
    }

    private void FillScores()
    {
        for (int i = 0; i < _scores.Length; i++)
        {
            var scoreData = _scoreController.GetScore(i);
            _scores[i].text = $"{i + 1}. {scoreData.name} - {scoreData.scores}";
        }
    }

    public void AssignDependency(ScoreController dependency)
    {
        _scoreController = dependency;
    }
}
