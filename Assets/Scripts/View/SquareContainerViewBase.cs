using UnityEngine;

public class SquareContainerViewBase : MonoBehaviour, IRequireDependency<SquareController>
{
    #region Fields

    protected AppSettings _rules;
    protected RectTransform _myRect;
    protected SquaresList _squaresTypes;
    protected SquareView _squarePrefab;
    protected SquareController _squareController;
    protected int _level;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        _myRect = GetComponent<RectTransform>();
    }
    #endregion

    #region Methods

    public virtual void SetUp(AppSettings rules, SquaresList allSquares, SquareView prefab)
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
        var maxModelIndex = Mathf.Clamp(_rules.SquareTypeCount + _level * _rules.SquareTypeCountStep,
            0, _squaresTypes.allSquares.Count);

        var model = _squaresTypes.allSquares[Random.Range(0, maxModelIndex)];
        square.SetView(model);
    }

    #endregion

    #region IRequireDependency

    public virtual void AssignDependency(SquareController dependency)
    {
        _squareController = dependency;
    }

    #endregion
}
