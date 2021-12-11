using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsablesSquareContainerView : SquareContainerViewBase
{
    #region Methods

    public void StartCreateUsableSquare(int level)
    {
        _level = level;
        _myRect = GetComponent<RectTransform>();

        var squareSize = CalculateSquareSize(_myRect.rect.height,
            _myRect.rect.width, _rules.UsableSquareCount, 5);

        for (int j = 0; j < _rules.UsableSquareCount; j++)
        {
            var square = Instantiate(_squarePrefab, _myRect);
            ChooseRandomModel(square);
            square.MyRect.sizeDelta = squareSize;
            _squareController.AddUsableSquare(square);
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
            _squareController.UseSquare(square.MyModel);
            ChooseRandomModel(square);
            square.MyRect.parent = _myRect;
        }
        else
        {
            ChooseRandomModel(square);
            square.MyRect.parent = _myRect;
        }
    }

    #endregion

    #region IRequireDependency

    public override void AssignDependency(SquareController dependency)
    {
        base.AssignDependency(dependency);
        _squareController.OnStartCreateUsableSquare += StartCreateUsableSquare;
    }

    #endregion
}
