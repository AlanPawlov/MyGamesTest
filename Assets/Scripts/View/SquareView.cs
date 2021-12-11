using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SquareView : MonoBehaviour, IDragHandler, IEndDragHandler
{
    #region Fields
    private Image _squareImage;

    public Action<SquareView, PointerEventData> OnDragAction = delegate { };
    public Action<SquareView, PointerEventData> OnEndDragAction = delegate { };
    #endregion

    #region Properties
    [field: SerializeField] public RectTransform MyRect { get; private set; }
    [field: SerializeField] public SquareModel MyModel { get; private set; }
    #endregion

    #region UnityMethods
    private void Awake()
    {
        MyRect = GetComponent<RectTransform>();
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
        MyModel = model;
        _squareImage.color = MyModel.MyColor;
    }

    public void Hide()
    {
        _squareImage.color = Color.clear;
        //_squareImage.color = new Color(MyModel.MyColor.r,
        //MyModel.MyColor.g, MyModel.MyColor.b, 0.5f);
    }

    public void Show()
    {
        _squareImage.color = MyModel.MyColor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragAction?.Invoke(this, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragAction?.Invoke(this, eventData);
    }
    #endregion
}

