using System.Collections.Generic;
using UnityEngine;
using System;

public class SquareController
{
    #region Fields
    private GameRules _rules;
    private int _currentSquare = 0;
    private List<SquareView> _usableSquareViews = new List<SquareView>();
    private List<SquareView> _sequenceSquareViews = new List<SquareView>();
    private CustomProcess _gameTimerProcess = new CustomProcess();
    private CustomProcess _delayHideProcess = new CustomProcess();

    public Action<int> OnStartCreateSequenceSquare = delegate { };
    public Action<int> OnStartCreateUsableSquare = delegate { };
    public Action<int> OnTimerChange = delegate { };
    public Action OnCompletteBuildSequence = delegate { };
    public Action OnErrorSquare = delegate { };
    public Action OnEndTime = delegate { };
    #endregion

    #region Properties
    public float GameTimer { get; private set; }
    #endregion

    #region Class Life Cycle
    public SquareController(GameRules rules)
    {
        _rules = rules;
    }
    #endregion

    #region Methods
    public void AddSequenceSquare(SquareView square)
    {
        if (!_sequenceSquareViews.Contains(square))
        {
            _sequenceSquareViews.Add(square);
        }
    }

    public void AddUsableSquare(SquareView square)
    {
        if (!_usableSquareViews.Contains(square))
        {
            _usableSquareViews.Add(square);
        }
    }

    public void UseSquare(SquareModel model)
    {
        int targetSquare = _sequenceSquareViews.Count - 1 - _currentSquare;
        if (model.MyColor == _sequenceSquareViews[targetSquare].MyModel.MyColor)
        {
            ShowSequenceSquare(_currentSquare);
            _currentSquare++;
            if (_currentSquare >= _sequenceSquareViews.Count)
            {
                OnCompletteBuildSequence.Invoke();
            }
        }
        else
        {
            OnErrorSquare.Invoke();
        }
    }

    private void StartGameTimer(int level)
    {
        GameTimer = Mathf.Clamp(_rules.MatchDuration - _rules.MatchDurationStep * level,
            1.5f, 999);

        _gameTimerProcess.StartProcess(() =>
        {
            GameTimer -= Time.deltaTime;
            OnTimerChange.Invoke((int)GameTimer);
            if (GameTimer <= 0)
            {
                OnEndTime.Invoke();
                _gameTimerProcess.EndProcess();
            }
        });
    }

    private void DelayHideSequence(int level)
    {
        float timer = Mathf.Clamp(_rules.ShowSequenceDuration - _rules.ShowSequenceDurationStep * level
            , 1.5f, 999);

        _delayHideProcess.StartProcess(() =>
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                HideSequenceSquare();
                CreateUsableSquare(level);
                _delayHideProcess.EndProcess();
            }
        });
    }

    public void ShowSequenceSquare(int index)
    {
        if (index >= 0 && index < _sequenceSquareViews.Count)
        {
            int targetSquare = _sequenceSquareViews.Count - 1 - index;
            _sequenceSquareViews[targetSquare].Show();
        }
    }

    public void HideSequenceSquare()
    {
        int squareCount = _sequenceSquareViews.Count;
        for (int i = 0; i < squareCount; i++)
        {
            _sequenceSquareViews[i].Hide();
        }
    }

    public void Clear()
    {
        for (int i = 0; i < _usableSquareViews.Count; i++)
        {
            UnityEngine.Object.Destroy(_usableSquareViews[i].gameObject);
        }

        for (int i = 0; i < _sequenceSquareViews.Count; i++)
        {
            UnityEngine.Object.Destroy(_sequenceSquareViews[i].gameObject);
        }

        _sequenceSquareViews.Clear();
        _usableSquareViews.Clear();
        _currentSquare = 0;
    }

    public void CreateSequenceSquare(int level)
    {
        OnStartCreateSequenceSquare.Invoke(level);
        DelayHideSequence(level);
    }

    public void CreateUsableSquare(int level)
    {
        OnStartCreateUsableSquare.Invoke(level);
        StartGameTimer(level);
    }
    #endregion
}
