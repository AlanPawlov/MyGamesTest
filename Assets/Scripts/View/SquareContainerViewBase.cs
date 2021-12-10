using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareContainerViewBase : MonoBehaviour
{
    protected GameRules _rules;
    protected RectTransform _myRect;
    protected SquaresList _squaresTypes;
    protected SquareView _squarePrefab;
    protected SequenceSquareController _sequenceSquareController;
    protected int _level;

    public virtual void SetUp(GameRules rules, SquaresList allSquares, SequenceSquareController sequenceController, SquareView prefab)
    {
        _rules = rules;
        _sequenceSquareController = sequenceController;
        _squaresTypes = allSquares;
        _squarePrefab = prefab;
    }
    protected virtual Vector2 CalculateSquareSize(float sizeOfSideSquare, float rootElementSize, int squareCount, float spacingInLayoutGroup = 0)
    {
        Vector2 squareSize = new Vector2(sizeOfSideSquare, sizeOfSideSquare);
        if (squareSize.x * squareCount + (squareCount - 2) * spacingInLayoutGroup > rootElementSize)
        {
            squareSize.x = rootElementSize / squareCount - spacingInLayoutGroup;
            squareSize.y = squareSize.x;
        }
        return squareSize;
    }

    protected virtual void ChooseRandomModel(SquareView square)
    {
        var maxModelIndex = Mathf.Clamp(_rules.SquareTypeCount + _level * _rules.SquareTypeCountStep,0, _squaresTypes.allSquares.Count);
        var model = _squaresTypes.allSquares[Random.Range(0, maxModelIndex)];
        square.SetView(model);
    }
}
