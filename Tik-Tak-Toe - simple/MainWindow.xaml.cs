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

namespace Tik_Tak_Toe___simple
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool[] used = {false, false, false, false, false, false, false, false, false};
        public bool[] Used 
        { 
            get 
            { return used; } 
            set 
            { used = value; } 
        }
        private bool player;
        public string playerModel;
        public bool[] playerX = { false, false, false, false, false, false, false, false, false };
        public bool[] playerO = { false, false, false, false, false, false, false, false, false };
        public bool Player
        {
            get 
            { return player; }
            set 
            { player = value;
                if (value)
                    playerModel = "X";
                else
                    playerModel = "O";
                        }
        }
        public static readonly DependencyProperty _fontsize = DependencyProperty.Register("Fontsize", typeof(double), typeof(MainWindow), new PropertyMetadata(100.0));
        public double Fontsize 
        { 
            get 
            { return (double)GetValue(_fontsize); } 
            set 
            { SetValue(_fontsize, value); } 
        }
        public MainWindow()
        {
            InitializeComponent();
            Player = true;
            this.DataContext = this;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height >= 300 || Width >= 300)
            {
                if (Height > Width)
                {
                    field.Height = Width - 100;
                    field.Width = Width - 100;
                    Fontsize = Height / 8;
                }
                else
                {
                    field.Height = Height - 100;
                    field.Width = Height - 100;
                    Fontsize = Width / 8;
                }
            }
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border1, 0);

        private void Border_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border2, 1);

        private void Border_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border3, 2);

        private void Border_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border4, 3);

        private void Border_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border5, 4);

        private void Border_MouseLeftButtonDown_6(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border6, 5);

        private void Border_MouseLeftButtonDown_7(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border7, 6);

        private void Border_MouseLeftButtonDown_8(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border8, 7);

        private void Border_MouseLeftButtonDown_9(object sender, MouseButtonEventArgs e) =>
            BorderTemplete(Border9, 8);

        private void BorderTemplete(TextBlock Border, int pos)
        {
            if (!(Used[pos]))
            {
                Border.Text = playerModel;
                if (playerModel == "X")
                {
                    playerX[pos] = true;
                    if (WinConditions(playerX))
                        MessageBox.Show("Gewonnen");
                }
                else
                {
                    playerO[pos] = true;
                    if (WinConditions(playerO))
                        MessageBox.Show("Gewonnen");
                }
                Player = !Player;
                Used[pos] = true;
            }
        }
        private bool WinConditions(bool[] play)
        {
            if ((play[0] && play[1] && play[2]) || (play[3] && play[4] && play[5]) || (play[6] && play[7] && play[8]) ||
                (play[0] && play[3] && play[6]) || (play[1] && play[4] && play[7]) || (play[2] && play[5] && play[8]) ||
                (play[0] && play[4] && play[8]) || (play[2] && play[4] && play[6]))
                return true;
            return false;
        }
    }
}
