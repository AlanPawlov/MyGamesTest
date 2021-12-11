using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceSquareContainerView : SquareContainerViewBase
{
    private CustomProcess _showSquareSequence;

    public void StartCreateSequence(int level)
    {
        _level = level;
        _myRect = GetComponent<RectTransform>();
        _showSquareSequence = new CustomProcess();
        int squareCount = Mathf.Clamp(_rules.SquareSequenceLenght + _rules.SequenceStep * _level,
            0, 999);

        var squareSize = CalculateSquareSize(_myRect.rect.width,
            _myRect.rect.height, squareCount);

        for (int j = 0; j < squareCount; j++)
        {
            var square = Instantiate(_squarePrefab, _myRect);
            square.MyRect.sizeDelta = squareSize;
            ChooseRandomModel(square);
            _squareController.AddSequenceSquare(square);
        }
    }

    public override void AssignDependency(SquareController dependency)
    {
        base.AssignDependency(dependency);
        _squareController.OnStartCreateSequenceSquare += StartCreateSequence;
    }
}
