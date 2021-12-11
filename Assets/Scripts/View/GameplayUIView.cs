using UnityEngine;
using TMPro;

public class GameplayUIView : MenuViewBase, IRequireDependency<ScoreController>, IRequireDependency<SquareController>
{
    #region Fields

    [SerializeField] private TMP_Text _scoreCountText;
    [SerializeField] private TMP_Text _timerText;
    private ScoreController _scoreController;
    private SquareController _squareController;

    #endregion

    #region Methods

    private void UpdateScore(int score)
    {
        _scoreCountText.text = $"Score\n{score}";
    }

    private void UpdateTimer(int time)
    {
        _timerText.text = $"Score\n{time}";
    }

    #endregion

    #region IRequireDependency

    public void AssignDependency(ScoreController dependency)
    {
        _scoreController = dependency;
        _scoreController.OnScoreChange += UpdateScore;

    }

    public void AssignDependency(SquareController dependency)
    {
        _squareController = dependency;
        _squareController.OnTimerChange += UpdateTimer;
    }

    #endregion
}
