using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClick;

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    public override void Close()
    {
        CanvasGroup.gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.gameObject.SetActive(true);
    }
}
