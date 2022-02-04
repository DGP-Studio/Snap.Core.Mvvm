using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Snap.Core.Mvvm
{
    /// <summary>
    /// 自动设置 <see cref="ObservableRecipient.IsActive"/>
    /// </summary>
    public class ObservableRecipient2 : ObservableRecipient
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

        public ObservableRecipient2(IMessenger messenger) : base(messenger)
        {
            IsActive = true;
        }

        ~ObservableRecipient2()
        {
            IsActive = false;
        }
    }
}