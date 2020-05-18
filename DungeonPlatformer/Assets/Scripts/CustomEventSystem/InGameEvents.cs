using System;

public static class InGameEvents
{
    public static event Action OnGameStart;
    public static event Action OnInventoryModified;
    public static event Action OnGamePaused;
    public static event Action OnGameContinue;
    public static event Action OnMainMenuButtonPressed;
    public static event Action OnDialogContinueButtonPressed;
    public static event Action OnDialogStarted;
    public static event Action OnDialogEnded;

    public static void OnGameStartFunction()
    {
        OnGameStart?.Invoke();
    }

    public static void OnInventoryModifiedFunction()
    {
        OnInventoryModified?.Invoke();
    }

    public static void OnGamePausedFunction()
    {
        OnGamePaused?.Invoke();
    }

    public static void OnGameContinueFunction()
    {
        OnGameContinue?.Invoke();
    }

    public static void OnMainMenuButtonPressedFunction()
    {
        OnMainMenuButtonPressed?.Invoke();
    }

    public static void OnDialogContinueButtonPressedFunction()
    {
        OnDialogContinueButtonPressed?.Invoke();
    }

    public static void OnDialogStartedFunction()
    {
        OnDialogStarted?.Invoke();
    }

    public static void OnDialogEndedFunction()
    {
        OnDialogEnded?.Invoke();
    }
}
