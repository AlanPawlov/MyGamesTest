using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SequenceSquareContainerView : SquareContainerViewBase
{
    private CustomProcess _showSquareSequence;
    public Action OnHideSequence = delegate { };

    public void StartMatch()
    {
        _myRect = GetComponent<RectTransform>();
        _showSquareSequence = new CustomProcess();
        CreateSequence();
        ShowSequence();
    }

    public void CreateSequence()
    {
        var squareSize = CalculateSquareSize(_myRect.rect.width,
            _myRect.rect.height, _rules.SquareSequenceLenght);

        for (int j = 0; j < _rules.SquareSequenceLenght; j++)
        {
            var square = Instantiate(_squarePrefab, _myRect);
            square.MyRect.sizeDelta = squareSize;
            ChooseRandomModel(square);
            _sequenceSquareController.AddSquare(square);
        }
    }

    private void ShowSequence()
    {
        float timer = _rules.ShowSequenceDuration;
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
