using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SquareView : MonoBehaviour, IDragHandler, IEndDragHandler
{
    #region Fields
    private Image _squareImage;
    private SquareModel _myModel;

    public Action<RectTransform, PointerEventData> OnDragAction = delegate { };
    public Action<RectTransform, PointerEventData> OnEndDragAction = delegate { };
    #endregion

    #region Properties
    [field: SerializeField] public RectTransform _myRect { get; private set; }
    #endregion

    #region UnityMethods
    private void Awake()
    {
        _myRect = GetComponent<RectTransform>();
        _squareImage = GetComponent<Image>();
    }

    private void OnDestroy()
    {
        OnDragAction = null;
        OnEndDragAction = null;
    }
    #endregion

    #region Methods
    public void SetView(SquareModel model)
    {
        _myModel = model;
        _squareImage.color = _myModel.MyColor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragAction?.Invoke(_myRect, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragAction?.Invoke(_myRect, eventData);
    }
    #endregion
}

