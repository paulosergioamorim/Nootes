using System.Windows;
using System.Windows.Controls;

namespace Nootes.Components
{
    public class PlaceholderTextBox : TextBox
    {
        static PlaceholderTextBox() => DefaultStyleKeyProperty.OverrideMetadata(typeof(PlaceholderTextBox),
            new FrameworkPropertyMetadata(typeof(PlaceholderTextBox)));

        public static readonly DependencyProperty IsRequiredProperty = DependencyProperty.Register(nameof(IsRequired),
            typeof(bool), typeof(PlaceholderTextBox), new PropertyMetadata(default(bool)));

        public bool IsRequired
        {
            get => (bool) GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder),
            typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(string.Empty));

        public string Placeholder
        {
            get => (string) GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        private static readonly DependencyPropertyKey IsEmptyPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsEmpty), typeof(bool), typeof(PlaceholderTextBox),
                new PropertyMetadata(true));

        public static readonly DependencyProperty IsEmptyProperty = IsEmptyPropertyKey.DependencyProperty;

        public bool IsEmpty
        {
            get => (bool) GetValue(IsEmptyProperty);
            set => SetValue(IsEmptyPropertyKey, value);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            IsEmpty = Text == string.Empty;
            base.OnTextChanged(e);
        }
    }
}
