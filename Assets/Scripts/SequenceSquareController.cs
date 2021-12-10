using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SequenceSquareController : UsableSquareController
{
    #region Fields
    private int _currentSquare = 0;
    public Action OnCompletteBuildSequence = delegate { };
    public Action OnErrorSquare = delegate { };
    #endregion

    #region Methods

    public void UseSquare(SquareModel model)
    {
        int targetSquare = _squareViews.Count - 1 - _currentSquare;
        if (model.MyColor == _squareViews[targetSquare].MyModel.MyColor)
        {
            ShowSquare(_currentSquare);
            _currentSquare++;
            if (_currentSquare >= _squareViews.Count)
            {
                OnCompletteBuildSequence.Invoke();
            }
        }
        else
        {
            OnErrorSquare.Invoke();
        }
    }

    public void ShowSquare(int index)
    {
        if (index >= 0 && index < _squareViews.Count)
        {
            int targetSquare = _squareViews.Count - 1 - index;
            _squareViews[targetSquare].Show();
        }
    }

    public void HideSquare(int index)
    {
        if (index >= 0 && index < _squareViews.Count)
        {
            int targetSquare = _squareViews.Count - 1 - index;
            _squareViews[targetSquare].Hide();
        }
    }

    public void ShowAllSquare()
    {
        int squareCount = _squareViews.Count;
        for (int i = 0; i < squareCount; i++)
        {
            _squareViews[i].Show();
        }
    }

    public void HideAllSquare()
    {
        int squareCount = _squareViews.Count;
        for (int i = 0; i < squareCount; i++)
        {
            _squareViews[i].Hide();
        }
    }

    public override void Clear()
    {
        base.Clear();
        _currentSquare = 0;
    }
    #endregion
}
