using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp.ViewModels;

namespace WpfApp.Extensions
{
    public class Selector
    {
        public static ItemsContext GetContext(DependencyObject obj)
        {
            return (ItemsContext)obj.GetValue(ContextProperty);
        }

        public static void SetContext(DependencyObject obj, ItemsContext value)
        {
            obj.SetValue(ContextProperty, value);
        }

        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.RegisterAttached("Context", typeof(ItemsContext), typeof(Selector), new PropertyMetadata(null, OnItemsContextChanged));

        private static void OnItemsContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = (System.Windows.Controls.Primitives.Selector)d;
            var ctx = (ItemsContext)e.NewValue;

            if (e.OldValue != null) // Clean up bindings from previous context, if any
            {
                BindingOperations.ClearBinding(selector, System.Windows.Controls.Primitives.Selector.SelectedItemProperty);
                BindingOperations.ClearBinding(selector, ItemsControl.ItemsSourceProperty);
                BindingOperations.ClearBinding(selector, ItemsControl.DisplayMemberPathProperty);
            }

            selector.SetBinding(System.Windows.Controls.Primitives.Selector.SelectedItemProperty, new Binding("SelectedItem") { Source = ctx, Mode = BindingMode.TwoWay });
            selector.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Items") { Source = ctx });
            selector.SetBinding(ItemsControl.DisplayMemberPathProperty, new Binding("DisplayMemberPath") { Source = ctx });
        }
    }
}