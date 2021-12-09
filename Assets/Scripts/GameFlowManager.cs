using UnityEngine;
using UnityEngine.EventSystems;

public class GameFlowManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameRules _rules;
    [SerializeField] private SquaresList _squaresTypes;
    [SerializeField] private RectTransform _usableSquareBarView;
    [SerializeField] private RectTransform _sequenceSquareView;
    [SerializeField] private RectTransform _gameFieldPanel;
    [SerializeField] private SquareView _squarePrefab;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        CreateControlls();
        CreateSequence();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
    #endregion

    #region Methods
    public void CreateSequence()
    {
        var controllSize = CalculateControllsSize(_sequenceSquareView.rect.width,
            _sequenceSquareView.rect.height, _rules.SquareSequenceLenght);

        for (int j = 0; j < _rules.SquareSequenceLenght; j++)
        {
            var controll = Instantiate(_squarePrefab, _sequenceSquareView);
            var model = _squaresTypes.allSquares[Random.Range(0, _squaresTypes.allSquares.Count)];
            controll._myRect.sizeDelta = controllSize;
            controll.SetView(model);
        }
    }

    public void CreateControlls()
    {
        var controllSize = CalculateControllsSize(_usableSquareBarView.rect.height,
            _usableSquareBarView.rect.width, _rules.UsableSquareCount, 5);

        for (int j = 0; j < _rules.UsableSquareCount; j++)
        {
            var controll = Instantiate(_squarePrefab, _usableSquareBarView);
            var model = _squaresTypes.allSquares[Random.Range(0, _squaresTypes.allSquares.Count)];
            controll._myRect.sizeDelta = controllSize;
            controll.SetView(model);
            controll.OnDragAction += OnDrag;
            controll.OnEndDragAction += OnEndDrag;
        }
    }

    private Vector2 CalculateControllsSize(float sizeOfSideSquare, float rootElementSize, int squareCount, float spacingInLayoutGroup = 0)
    {
        Vector2 controllSize = new Vector2(sizeOfSideSquare, sizeOfSideSquare);
        if (controllSize.x * squareCount + (squareCount - 2) * spacingInLayoutGroup > rootElementSize)
        {
            controllSize.x = rootElementSize / squareCount - spacingInLayoutGroup;
            controllSize.y = controllSize.x;
        }
        return controllSize;
    }

    public void LoseGame()
    {

    }

    public void WinGame()
    {

    }

    private void OnDrag(RectTransform targetRect, PointerEventData eventData)
    {
        targetRect.position = eventData.pointerCurrentRaycast.screenPosition;
    }

    private void OnEndDrag(RectTransform targetRect, PointerEventData pointerEventData)
    {
        Debug.Log(targetRect.localPosition.y);
        Debug.Log(targetRect.rect.y);
        targetRect.parent = _gameFieldPanel;

        if (targetRect.position.y > _usableSquareBarView.position.y)
        {
            Debug.Log("To Sequence");
        }
        else
        {
            Debug.Log("Drop");
        }
    }
    #endregion
}
