using System;
using System.Windows;
using System.Windows.Controls;
using ProgrammingInCSharp.Lab01.ViewModels;

namespace ProgrammingInCSharp.Lab01.Views
{
    /// <summary>
    /// Interaction logic for DatePickerView.xaml
    /// </summary>
    public partial class DatePickerView : UserControl
    {
        private DatePickerViewModel _viewModel;
        public DatePickerView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DatePickerViewModel();
        }
    }
}
