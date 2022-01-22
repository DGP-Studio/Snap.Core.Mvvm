﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Snap.Core.Mvvm
{
    public class ObservableObject2 : ObservableObject
    {
        protected bool SetPropertyAndCallbackOnCompletion<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, Action then, [CallerMemberName] string? propertyName = null)
        {
            bool result = SetProperty(ref field, newValue, propertyName);
            if (result)
            {
                then.Invoke();
            }
            return result;
        }

        protected bool SetPropertyAndCallbackOnCompletion<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, Action<T> then, [CallerMemberName] string? propertyName = null)
        {
            bool result = SetProperty(ref field, newValue, propertyName);
            if (result)
            {
                then.Invoke(newValue);
            }
            return result;
        }
    }
}