using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weather
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CloseGrids()
        {
            TodayGrid.Visibility = Visibility.Hidden;
            TomorrowGrid.Visibility = Visibility.Hidden;
            DayAfterTomorrowGrid.Visibility = Visibility.Hidden;
        }

        private void TodayButton_Click(object sender, RoutedEventArgs e)
        {
            CloseGrids();
            TodayGrid.Visibility = Visibility.Visible;
        }

        private void TomorrowButton_Click(object sender, RoutedEventArgs e)
        {
            CloseGrids();
            TomorrowGrid.Visibility = Visibility.Visible;
        }

        private void DayAfterTomorrowButton_Click(object sender, RoutedEventArgs e)
        {
            CloseGrids();
            DayAfterTomorrowGrid.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            CloseGrids();
        }
    }
}
