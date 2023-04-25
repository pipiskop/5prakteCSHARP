using YukiPesik.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace YukiPesik
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public VIBOR_POLZOVATELYA KUDA_NADO { get; }

        public ListPage(VIBOR_POLZOVATELYA userChoose)
        {
            InitializeComponent();

            KUDA_NADO = userChoose;
            MORGEN();
            OBNOVA();
        }

        private void MORGEN()
        {
            foreach (string option in VIBOR_POLZOVATELYA.NASTRIKCHKA)
            {
                var item = new ChooseItem(option, KUDA_NADO.items.Contains(option));
                listBox.Items.Add(item);
            }
        }
        private void OBNOVA()
        {
            DateLabel.Content = KUDA_NADO.date.ToString("d MMMM yyyy");
        }
        private void SOHRA(object sender, RoutedEventArgs e)
        {
            ZAPONMI_VIBOR();
            VIHOD();
        }
        private void ZAPONMI_VIBOR()
        {
            KUDA_NADO.items.Clear();

            foreach (ChooseItem item in listBox.Items.OfType<ChooseItem>())
            {
                if (item.isOn)
                {
                    KUDA_NADO.items.Add(item.name);
                }
            }
            SOHRANENIE.BARACUDA(KUDA_NADO);
        }

        private void FACK_NAZAD(object sender, RoutedEventArgs e)
        {
            VIHOD();
        }

        private void VIHOD()
        {
            var window = (MainWindow)App.Current.MainWindow;
            window.Frame.Content = new YUKI_RIJIY(KUDA_NADO.date);
        }
    }
}
