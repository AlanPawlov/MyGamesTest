using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SequenceSquareContainerView : SquareContainerViewBase
{
    private CustomProcess _showSquareSequence;
    public Action OnHideSequence = delegate { };

    public void StartLevel(int level)
    {
        _level = level;
        _myRect = GetComponent<RectTransform>();
        _showSquareSequence = new CustomProcess();
        CreateSequence();
        ShowSequence();
    }

    public void CreateSequence()
    {
        int squareCount = Mathf.Clamp(_rules.SquareSequenceLenght + _rules.SequenceStep * _level,
            0, 999);

        var squareSize = CalculateSquareSize(_myRect.rect.width,
            _myRect.rect.height, squareCount);

        for (int j = 0; j < squareCount; j++)
        {
            var square = Instantiate(_squarePrefab, _myRect);
            square.MyRect.sizeDelta = squareSize;
            ChooseRandomModel(square);
            _sequenceSquareController.AddSquare(square);
        }
    }

    private void ShowSequence()
    {
        float timer = Mathf.Clamp(_rules.ShowSequenceDuration - _rules.ShowSequenceDurationStep * _level
            , 1.5f, 999);
        Debug.Log(timer);
        _showSquareSequence.StartProcess(() =>
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _showSquareSequence.EndProcess();
                _sequenceSquareController.HideAllSquare();
                OnHideSequence.Invoke();
            }
        });
    }
}
