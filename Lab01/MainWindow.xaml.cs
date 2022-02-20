using System.Windows;
using ProgrammingInCSharp.Lab01.Views;

namespace ProgrammingInCSharp.Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new DatePickerView();
        }


    }
}
