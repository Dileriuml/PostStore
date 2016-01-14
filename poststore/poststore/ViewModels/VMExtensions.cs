using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Threading;

namespace PostStore.ViewModels
{
    public static class VMExtensions
    {
        public static void OnPropertyChanged<T, TProperty>(this T observableBase, Expression<Func<T, TProperty>> expression)
            where T : VMBase
        {
            observableBase.RaisePropertyChanged(GetPropertyName(expression));
        }

        public static void OnPropertyChangedWithDispatcher<T, TProperty>(this T observableBase, Expression<Func<T, TProperty>> expression)
            where T : VMBase
        {
            Dispatcher.CurrentDispatcher.Invoke(new Action(() => observableBase.RaisePropertyChanged(GetPropertyName(expression))));
        }

        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression)
          where T : INotifyPropertyChanged
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
                throw new ArgumentNullException("expression");

            return memberExpression.Member.Name;
        }

        public static void AddUsingDispatcher<T>(this ObservableCollection<T> collection, T newItem)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, (Action)delegate { collection.Add(newItem); });
        }

        public static void ClearUsingDispatcher<T>(this ObservableCollection<T> collection)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(collection.Clear));
        }
    }
}
