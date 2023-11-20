using System;
using UniRx;
using UnityEngine.InputSystem;

public static class InputSystemExtensions
{
    public static IObservable<InputAction.CallbackContext> AsObservable(this InputAction action)
    {
        return Observable.FromEvent<InputAction.CallbackContext>(
            h => action.performed += h,
            h => action.performed -= h);
    }
}
