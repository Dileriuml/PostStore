using System;
using System.Windows;
using System.Windows.Controls;

namespace PostStore.Controls
{
    public class DateTimeColumn : DataGridBoundColumn
    {
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            return GenerateElement(cell, dataItem);
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var element = new DatePicker
            {
                Style = Application.Current.Resources["DatePickerStyle"] as Style
            };
            element.SetBinding(DatePicker.SelectedDateProperty, Binding);
            return element;
        }
    }
}
