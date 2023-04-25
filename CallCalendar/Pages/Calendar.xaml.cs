using YukiPesik.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace YukiPesik
{
    /// <summary>
    /// Логика взаимодействия для Calendar.xaml
    /// </summary>
    public partial class YUKI_RIJIY : Page
    {
        public YUKI_RIJIY()
        {
            InitializeComponent();
            POPA.SelectedDate = DateTime.Now;
        }
        public YUKI_RIJIY(DateOnly date)
        {
            InitializeComponent();
            POPA.SelectedDate = date.ToDateTime(new TimeOnly());
        }
        private void ZAGRUZKA(object sender, RoutedEventArgs e)
        {
            Provero4ka();
        }
        private void NARUTO(object sender, SizeChangedEventArgs e)
        {
            OPEN();
        }
        private void VIBOR_DATE(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
                Provero4ka();
        }
        private void Dalshe(object sender, RoutedEventArgs e)
        {
            if (POPA.SelectedDate == null)
                return;
            POPA.SelectedDate = POPA.SelectedDate.Value.AddMonths(-1);
        }
        private void VPERED(object sender, RoutedEventArgs e)
        {
            if (POPA.SelectedDate == null)
                return;
            POPA.SelectedDate = POPA.SelectedDate.Value.AddMonths(1);
        }
        private void OPEN()
        {
            foreach (DateSquare fashik in OHIO.Children.OfType<DateSquare>())
                fashik.Margin = new Thickness(10 + ((fashik.Day - 1) % ((int)(OHIO.RenderSize.Width) / 80)) * 80, 10 + ((fashik.Day - 1) / ((int)OHIO.RenderSize.Width / 80)) * 80, 10, 10);
        }

        private void Provero4ka()
        {
            OHIO.Children.Clear();
            if (POPA.SelectedDate == null)
                return;

            DateTime selectedDate = POPA.SelectedDate ?? DateTime.Now;
            CHISLODEN.Content = selectedDate.ToString("MMMM yyyy");

            for (int i = 1; i <= DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month); i++)
            {
                DateSquare square = new (SOHRANENIE.LoadUserChoose(new DateOnly(selectedDate.Year, selectedDate.Month, i)))
                {
                    Margin = new Thickness(10 + 80 * (i - 1), 10, 10, 10),
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                OHIO.Children.Add(square);
            }

            OPEN();
        }
    }

}