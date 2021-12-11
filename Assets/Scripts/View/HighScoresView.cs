using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoresView : MenuViewBase, IRequireDependency<ScoreController>
{
    #region Fields

    [SerializeField] private TMP_Text[] _scores = new TMP_Text[10];
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private ScoreController _scoreController;

    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        _toMenuButton.onClick.AddListener(() => _menuController.SwitchMenu(MenuTypes.MainMenu));
    }

    private void OnDisable()
    {
        _toMenuButton.onClick.RemoveAllListeners();
    }

    #endregion

    #region Methods
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

    #endregion

    #region IRequireDependency

    public void AssignDependency(ScoreController dependency)
    {
        _scoreController = dependency;
    }

    #endregion
}
