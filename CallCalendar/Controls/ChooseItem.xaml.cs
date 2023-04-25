using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace YukiPesik
{
    /// <summary>
    /// Логика взаимодействия для ChooseItem.xaml
    /// </summary>
    public partial class ChooseItem : UserControl
    {
        public string name { get; init; }
        public bool isOn => checkbox.IsChecked ?? false;
        public ChooseItem(string name, bool isOn)
        {
            InitializeComponent();

            this.name = name;
            picture.Source = new BitmapImage(new Uri("/KARTINKI/" + name + ".png", UriKind.Relative));
            label.Content = name;

            checkbox.IsChecked = isOn;
        }
    }
}