using System;

public static class UIEvents
{
    public static event Action OnGameStartButtonPressed;

    public static void OnGameStartButtonPressedFunction()
    {
        OnGameStartButtonPressed?.Invoke();
    }
}
