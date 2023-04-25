using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace YukiPesik
{
    public partial class DateSquare : UserControl
    {
        public VIBOR_POLZOVATELYA choose;
        public int Day => choose.date.Day;
        private string image = "/KARTINKI/mood.png";
        public DateSquare(VIBOR_POLZOVATELYA choose)
        {
            InitializeComponent();

            this.choose = choose;
            label.Content = Day.ToString();

            image = "/KARTINKI/mood.png";
            if (choose.items.Count > 0)
                image = $"/KARTINKI/{choose.items[0]}.png";

            picture.Source = new BitmapImage(new Uri(image, UriKind.Relative)); ;
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow window = (MainWindow)App.Current.MainWindow;
            window.Frame.Content = new ListPage(choose);
        }
    }
}