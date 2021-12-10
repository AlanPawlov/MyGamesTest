using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsablesSquareContainerView : SquareContainerViewBase
{
    private UsableSquareController _usableSquareController;
    public void SetUp(GameRules rules, SquaresList allSquares, SequenceSquareController sequenceController, SquareView prefab, UsableSquareController usableController)
    {
        base.SetUp(rules, allSquares, sequenceController, prefab);
        _usableSquareController = usableController;
    }
    public void CreateUsableSquare()
    {
        _myRect = GetComponent<RectTransform>();

        var squareSize = CalculateSquareSize(_myRect.rect.height,
            _myRect.rect.width, _rules.UsableSquareCount, 5);

        for (int j = 0; j < _rules.UsableSquareCount; j++)
        {
            var square = Instantiate(_squarePrefab, _myRect);
            ChooseRandomModel(square);
            square.MyRect.sizeDelta = squareSize;
            _usableSquareController.AddSquare(square);
            square.OnDragAction += OnDrag;
            square.OnEndDragAction += OnEndDrag;
        }
    }

    private void OnDrag(SquareView square, PointerEventData eventData)
    {
        square.MyRect.position = eventData.pointerCurrentRaycast.screenPosition;
    }

    private void OnEndDrag(SquareView square, PointerEventData pointerEventData)
    {
        square.MyRect.parent = null;

        if (square.MyRect.position.y > _myRect.position.y)
        {
            _sequenceSquareController.UseSquare(square.MyModel);
            ChooseRandomModel(square);
            square.MyRect.parent = _myRect;
        }
        else
        {
            ChooseRandomModel(square);
            square.MyRect.parent = _myRect;
        }
    }
}