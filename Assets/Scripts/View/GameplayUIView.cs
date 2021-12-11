using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUIView : MenuViewBase, IRequireDependency<ScoreController>, IRequireDependency<SquareController>
{
    [SerializeField] private TMP_Text _scoreCountText;
    [SerializeField] private TMP_Text _timerText;
    private ScoreController _scoreController;
    private SquareController _squareController;
    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void UpdateScore(int score)
    {
        _scoreCountText.text = $"Score\n{score.ToString()}";
    }

    private void UpdateTimer(int time)
    {
        _timerText.text = time.ToString();
    }

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
}
