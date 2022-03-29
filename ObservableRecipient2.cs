using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.VisualStudio.Threading;
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
            bool result = this.SetProperty(ref field, newValue, propertyName);
            if (result)
            {
                then.Invoke();
            }
            return result;
        }
        protected bool SetPropertyAndCallbackOnCompletion<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, Action<T> then, [CallerMemberName] string? propertyName = null)
        {
            bool result = this.SetProperty(ref field, newValue, propertyName);
            if (result)
            {
                then.Invoke(newValue);
            }
            return result;
        }

        protected bool SetPropertyAndCallbackOnCompletion<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, Func<T, Task> thenForget, [CallerMemberName] string? propertyName = null)
        {
            return this.SetPropertyAndCallbackOnCompletion(ref field, newValue, thenForget.Invoke(newValue).Forget, propertyName);
        }

        protected bool SetPropertyAndCallbackOverridePropertyState<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, Action then, [CallerMemberName] string? propertyName = null)
        {
            bool result = this.SetProperty(ref field, newValue, propertyName);
            then.Invoke();
            return result;
        }

        protected bool SetPropertyAndCallbackOverridePropertyState<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, Func<Task> thenForget, [CallerMemberName] string? propertyName = null)
        {
            return this.SetPropertyAndCallbackOverridePropertyState(ref field, newValue, thenForget.Invoke().Forget, propertyName);
        }

        public ObservableRecipient2(IMessenger messenger) : base(messenger)
        {
            this.IsActive = true;
        }

        ~ObservableRecipient2()
        {
            this.IsActive = false;
        }
    }
}