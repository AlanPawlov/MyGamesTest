using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareContainerViewBase : MonoBehaviour, IRequireDependency<SquareController>
{
    protected GameRules _rules;
    protected RectTransform _myRect;
    protected SquaresList _squaresTypes;
    protected SquareView _squarePrefab;
    protected SquareController _squareController;
    protected int _level;

    public virtual void SetUp(GameRules rules, SquaresList allSquares, SquareView prefab)
    {
        _rules = rules;
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

    public virtual void AssignDependency(SquareController dependency)
    {
        _squareController = dependency;
    }
}
