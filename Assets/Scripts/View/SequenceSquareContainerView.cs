using UnityEngine;

public class SequenceSquareContainerView : SquareContainerViewBase
{

    #region Methods
    public void CreateSequenceSquare(int level)
    {
        _level = level;
        int squareCount = Mathf.Clamp(_rules.SquareSequenceLenght + _rules.SequenceStep * _level,
            0, _rules.MaxSquareInSequence);

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

    #endregion

    #region IRequireDependency

    public override void AssignDependency(SquareController dependency)
    {
        base.AssignDependency(dependency);
        _squareController.OnStartCreateSequenceSquare += CreateSequenceSquare;
    }

    #endregion
}
