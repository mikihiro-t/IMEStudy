using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IMEStudy
{
    public class ImeAttachedProperties
    {
        public static InputMethodState GetIMEState(DependencyObject obj)
        {
            return (InputMethodState)obj.GetValue(IMEStateProperty);
        }
        public static void SetIMEState(DependencyObject obj, InputMethodState value)
        {
            obj.SetValue(IMEStateProperty, value);
        }
        public static readonly DependencyProperty IMEStateProperty = DependencyProperty.RegisterAttached("IMEState", typeof(InputMethodState), typeof(ImeAttachedProperties), new PropertyMetadata(InputMethodState.DoNotCare));
    }
}
