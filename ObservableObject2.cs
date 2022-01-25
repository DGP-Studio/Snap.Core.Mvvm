using Microsoft.Toolkit.Mvvm.ComponentModel;
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

        /// <summary>
        /// 设置属性，且无视属性是否发生变化，触发回调
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="newValue"></param>
        /// <param name="then"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetPropertyAndCallbackOverridePropertyState<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, Action then, [CallerMemberName] string? propertyName = null)
        {
            bool result = SetProperty(ref field, newValue, propertyName);
            then.Invoke();
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