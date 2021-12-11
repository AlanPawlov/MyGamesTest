using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuController
{
    public Action<MenuTypes> OnChangeMenu = delegate { };
    public Action OnPlayGame = delegate { };

    public void PlayGame()
    {
        OnPlayGame.Invoke();
    }

    public void SwitchMenu(MenuTypes nextMenu)
    {
        OnChangeMenu.Invoke(nextMenu);
    }
}
