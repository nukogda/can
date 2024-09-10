using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace can
{
    public partial class MainWindow : Window
    {
        private DateTime _endDate;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод для установки конечной даты (последний день учёбы)
        private void SetEndDate_Click(object sender, RoutedEventArgs e)
        {
            if (StudyCalendar.SelectedDate != null)
            {
                _endDate = (DateTime)StudyCalendar.SelectedDate;
                UpdateRemainingDays();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите дату окончания учёбы.");
            }
        }

        // Обновление оставшихся дней
        private void UpdateRemainingDays()
        {
            var today = DateTime.Today;
            var remainingDays = (_endDate - today).Days;

            RemainingDaysTextBlock.Text = remainingDays > 0
                ? $"Осталось дней: {remainingDays}"
                : "Учёба закончилась!";
        }

        // Событие для обработки выбора даты в календаре
        private void StudyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudyCalendar.SelectedDate != null)
            {
                CountdownTextBlock.Text = $"Выбранная дата: {StudyCalendar.SelectedDate.Value.ToShortDateString()}";
            }
        }
    }
}