using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMEStudy
{
    public partial class MainWindow : Window
    {
        public DateTerm Date1 { get; set; } = new DateTerm();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Date1.Date = new DateTime(2022, 1, 1);
            Date1.IMEState = InputMethodState.Off;  //InputMethodState.On;

            //コードで追加
            var datePicker = new DatePicker() { Width = 200, Height = 30, FontSize=18 , HorizontalAlignment=HorizontalAlignment.Left ,Margin= new Thickness(210,20,0,0)};
            datePicker.Style = (Style)Application.Current.Resources["DatePickerStyle1"];
            InputMethod.SetPreferredImeState(datePicker, InputMethodState.Off);
            RootStackPanel.Children.Add(datePicker);
        }
    }

    public class DateTerm : NotifyBase
    {
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => SetField(ref _date, value);
        }
        private InputMethodState _imeState;
        public InputMethodState IMEState
        {
            get => _imeState;
            set => SetField(ref _imeState, value);
        }
    }

    public abstract class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

}
