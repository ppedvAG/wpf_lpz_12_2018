using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Validierung
{
    
    public class ValidationHelper
    {

        //Eigene Attached Property definieren mit Snippet: propa
        //MinimalValidationLength--------------------------------------------------------------
        public static int GetMinimalValidationLength(DependencyObject obj)
        {
            return (int)obj.GetValue(MinimalValidationLengthProperty);
        }

        public static void SetMinimalValidationLength(DependencyObject obj, int value)
        {
            obj.SetValue(MinimalValidationLengthProperty, value);
        }

        // Using a DependencyProperty as the backing store for MinimalValidationLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimalValidationLengthProperty =
            DependencyProperty.RegisterAttached("MinimalValidationLength", typeof(int), typeof(ValidationHelper), new PropertyMetadata(0, MinimalLengthChanged));

        private static void MinimalLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox text)
            {
                text.TextChanged += Text_TextChanged;
                SetValidationActivated(text, false);
            }
        }

        private static void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox box)
            {

                if (box.Text.Length < ValidationHelper.GetMinimalValidationLength(box) && GetValidationActivated(box) != true)
                {
                    SetValidationActivated(box, false);
                }
                else
                {
                    SetValidationActivated(box, true);
                }
            }
        }

        //2. Attached Property: ValidationActivated---------------------------------------------------------------------

        public static bool? GetValidationActivated(DependencyObject obj)
        {
            return (bool?)obj.GetValue(ValidationActivatedProperty);
        }

        public static void SetValidationActivated(DependencyObject obj, bool? value)
        {
            obj.SetValue(ValidationActivatedProperty, value);
        }

        // Using a DependencyProperty as the backing store for ValidationActivated.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationActivatedProperty =
            DependencyProperty.RegisterAttached("ValidationActivated", typeof(bool?), typeof(ValidationHelper), new PropertyMetadata(null));

    }
}