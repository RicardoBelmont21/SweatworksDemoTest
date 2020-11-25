using SWDemo.Styles.Keys;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SWDemo.Controls
{
    public class CustomEntry : Entry
    {
        public Color OKColor { get { return (Color)GetValue(OKColorProperty); } set { SetValue(OKColorProperty, value); } }
        public static readonly BindableProperty OKColorProperty = BindableProperty.Create(
            nameof(OKColor),
            typeof(Color),
            typeof(CustomEntry),
            Color.Default,
            BindingMode.TwoWay);

        public Color ErrorColor { get { return (Color)GetValue(ErrorColorProperty); } set { SetValue(ErrorColorProperty, value); } }
        public static readonly BindableProperty ErrorColorProperty = BindableProperty.Create(
            nameof(ErrorColor),
            typeof(Color),
            typeof(CustomEntry),
            Color.Default,
            BindingMode.TwoWay);

        public string ValidateRegex { get { return (string)GetValue(ValidateRegexProperty); } set { SetValue(ValidateRegexProperty, value); } }
        public static readonly BindableProperty ValidateRegexProperty = BindableProperty.Create(
            nameof(ValidateRegex),
            typeof(string),
            typeof(CustomEntry),
            string.Empty,
            BindingMode.TwoWay);

        public bool ValidateEntry { get { return (bool)GetValue(ValidateEntryProperty); } set { SetValue(ValidateEntryProperty, value); } }
        public static readonly BindableProperty ValidateEntryProperty = BindableProperty.Create(
            nameof(ValidateEntry),
            typeof(bool),
            typeof(CustomEntry),
            false,
            BindingMode.TwoWay,
            propertyChanged: (s, o, n) =>
            {
                var sender = s as CustomEntry;
                if (sender == null || !(bool)n) return;
                sender.CustomEntry_TextChanged(sender, null);
                sender.ValidateEntry = false;
            });

        public Color BorderColor { get { return (Color)GetValue(BorderColorProperty); } set { SetValue(BorderColorProperty, value); } }
        public static BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor),
            typeof(Color),
            typeof(CustomEntry),
            Color.Default,
            propertyChanged: OnItemsSourcePropertyChanged);

        public Color FocusedBorderColor { get { return (Color)GetValue(FocusedBorderColorProperty); } set { SetValue(FocusedBorderColorProperty, value); } }
        public static BindableProperty FocusedBorderColorProperty = BindableProperty.Create(
            nameof(FocusedBorderColor),
            typeof(Color),
            typeof(CustomEntry),
            Color.Default,
            propertyChanged: OnItemsSourcePropertyChanged);

        public new Color BackgroundColor { get { return (Color)GetValue(BackgroundColorProperty); } set { SetValue(BackgroundColorProperty, value); } }
        public new static BindableProperty BackgroundColorProperty = BindableProperty.Create(
            nameof(BackgroundColor),
            typeof(Color),
            typeof(CustomEntry),
            Color.Default,
            propertyChanged: OnItemsSourcePropertyChanged);

        /// <summary>
        /// 0% - 100%
        /// </summary>
        public int BorderRadius { get { return (int)GetValue(BorderRadiusProperty); } set { SetValue(BorderRadiusProperty, value); } }
        public static BindableProperty BorderRadiusProperty = BindableProperty.Create(
            nameof(BorderRadius),
            typeof(int),
            typeof(CustomEntry),
            0,
            propertyChanged: OnItemsSourcePropertyChanged);

        public int BorderStroke { get { return (int)GetValue(BorderStrockeProperty); } set { SetValue(BorderStrockeProperty, value); } }
        public static BindableProperty BorderStrockeProperty = BindableProperty.Create(
           nameof(BorderStroke),
           typeof(int),
           typeof(CustomEntry),
           1,
           propertyChanged: OnItemsSourcePropertyChanged);

        public CustomEntryBorderType BorderType { get { return (CustomEntryBorderType)GetValue(BorderTypeProperty); } set { SetValue(BorderTypeProperty, value); } }
        public static BindableProperty BorderTypeProperty = BindableProperty.Create(
           nameof(BorderType),
           typeof(CustomEntryBorderType),
           typeof(CustomEntry),
           CustomEntryBorderType.Frame);

        public CustomEntry()
        {
            this.BorderType = (CustomEntryBorderType)BorderTypeProperty.DefaultValue;
            this.SetDynamicResource(CustomEntry.OKColorProperty, ColorKeys.EntryBorderColor);
            this.SetDynamicResource(CustomEntry.ErrorColorProperty, ColorKeys.Danger);
            this.SetDynamicResource(CustomEntry.BorderColorProperty, ColorKeys.EntryBorderColor);
            this.SetDynamicResource(CustomEntry.BackgroundColorProperty, ColorKeys.EntryBackgroundColor);
            this.SetDynamicResource(CustomEntry.TextColorProperty, ColorKeys.TextPrimary);
            this.SetDynamicResource(CustomEntry.PlaceholderColorProperty, ColorKeys.TextHint);
            this.TextChanged += CustomEntry_TextChanged;
            BorderRadius = 20;
            BorderStroke = 1;
            BorderType = CustomEntryBorderType.Frame;
        }

        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ValidateRegex)) return;
            var ent = sender as CustomEntry;
            if (ent == null) return;
            {
                if (Regex.IsMatch(string.IsNullOrEmpty(ent.Text) ? "" : ent.Text, ValidateRegex))
                    ent.BorderColor = OKColor;
                else
                    ent.BorderColor = ErrorColor;
                ent.BorderRadius = 12;
            }
        }

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as CustomEntry;
            var changingFrom = oldValue;
            var changingTo = newValue;
        }
    }

    public enum CustomEntryBorderType
    {
        Frame, Line, None
    }
}
