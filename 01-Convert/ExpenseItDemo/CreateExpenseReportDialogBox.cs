// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ExpenseItDemo.Data.Model;
using ExpenseItDemo.Data.Services;
using System.Windows;

namespace ExpenseItDemo
{
    /// <summary>
    ///     Interaction logic for CreateExpenseReportDialogBox.xaml
    /// </summary>
    public partial class CreateExpenseReportDialogBox : Window
    {
        private Employee CurrentEmployee;
        private DatabaseService dbService;
        public ExpenseReport Report { get; set; }

        public CreateExpenseReportDialogBox()
        {
            InitializeComponent();
            dbService = new DatabaseService();
        }

        private void addExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current;
        }

        private void viewChartButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ViewChartWindow {Owner = this};
            dlg.Show();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Expense Report Created!",
                "ExpenseIt Standalone",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            CurrentEmployee = (Application.Current as App).SelectedEmployee;

            Report = new ExpenseReport(CurrentEmployee.EmployeeId);
            this.DataContext = Report;
        }
    }
}