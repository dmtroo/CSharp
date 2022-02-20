using System.Windows.Controls;
using ProgrammingInCSharp.Lab01.ViewModels;

namespace ProgrammingInCSharp.Lab01.Views
{
    /// <summary>
    /// Interaction logic for DatePickerView.xaml
    /// </summary>
    public partial class DatePickerView : UserControl
    {
        public DatePickerView()
        {
            InitializeComponent();
            DataContext = new DatePickerViewModel();
        }
    }
}
