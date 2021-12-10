using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UsableSquareController
{
    #region Fields
    protected List<SquareView> _squareViews = new List<SquareView>();
    #endregion

    #region Methods
    public virtual void AddSquare(SquareView square)
    {
        if (!_squareViews.Contains(square))
        {
            _squareViews.Add(square);
        }
    }

    public virtual void Clear()
    {
        for (int i = 0; i < _squareViews.Count; i++)
        {
            UnityEngine.Object.Destroy(_squareViews[i].gameObject);
        }

        _squareViews.Clear();
    }
    #endregion
}
