using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuViewBase : MonoBehaviour, IRequireDependency<MenuController>
{
    [SerializeField] protected CanvasGroup _myCanvasGroup;
    [SerializeField] protected MenuTypes _menuType;
    protected MenuController _menuController;

    protected virtual void Show()
    {
        _myCanvasGroup.alpha = 1;
        _myCanvasGroup.blocksRaycasts = true;
    }

    protected virtual void Hide()
    {
        _myCanvasGroup.alpha = 0;
        _myCanvasGroup.blocksRaycasts = false;
    }

    private void ChangeMenu(MenuTypes type)
    {
        if (type == _menuType)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void AssignDependency(MenuController dependency)
    {
        _menuController = dependency;
        _menuController.OnChangeMenu += ChangeMenu;
    }
}
