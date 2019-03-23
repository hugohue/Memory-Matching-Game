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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Matching game;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            if (game == null)
            {
                Button[] buttons = new Button[20];
                for (int i = 0; i < 20; i++)
                {
                    buttons[i] = panel.Children[i] as Button;

                }
                game = new Matching(buttons);
            }
            game.Restart();
            }
        }

        public class Matching
        {
           //intialization
            private Button[] button_match;
            public int[] button_num = new int[20];
            private Button[] select_button = new Button[2];
            private bool[] correct_button = new bool[20];
            private int correct_count;
            private int click_count = 2;
            private Random rnd = new Random();

        public Matching(Button[] buttons)
            {
                button_match = buttons;
                for (int i = 0; i < 20; i++)
                {
                    button_match[i].Click += new RoutedEventHandler(Mouse);
                    button_match[i].Tag = i;
                }
            }

        public void Restart()
        {
            int[] num = new int[20];
            correct_button = new bool[20];
            for (int i=0; i<20; i++)
            {
                Load(button_match[i], -1);
                num[i] = i / 2;
            }
            for (int i=0; i<20; i++)
            {
                int roll = rnd.Next(0, 20 - i);
                button_num[i] = num[roll];
                num[roll] = num[19 - i];
            }
            correct_count = 0;
            click_count = 0;            
        }

            public void Mouse(object sender, RoutedEventArgs e)
            {

                Button btn = sender as Button;
                int tag = (int)btn.Tag;
                if (click_count == 2 ||  correct_button[tag] || btn == select_button[0] && click_count == 1)
                    return;
                Load(btn, button_num[tag]);
                if (click_count == 0)
                {
                select_button[0] = btn;
                    click_count++;
                }
                else
                {
                select_button[1] = btn;
                    click_count++;
                    if (button_num[tag] == button_num[(int)select_button[0].Tag])
                    {
                        click_count = 0;
                        correct_button[tag] = correct_button[(int)select_button[0].Tag] = true;
                        correct_button[tag] = true;
                        correct_count++;
                        if (correct_count == 10)
                        {
                            MessageBox.Show("Win!!");

                        }
                    }
                    else
                    {
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = new TimeSpan(0,0,1);
                        timer.Tick += new EventHandler((o, arg) =>
                        {
                            (o as DispatcherTimer).Stop();
                            Load(select_button[0], -1);
                            Load(select_button[1], -1);
                            click_count = 0;

                        });
                        timer.Start();
                    }
                }
            }
        private int Finding_image(Button image)
        {
            for (int i = 0; i < 20; i++)
                if (button_match[i] == image)
                    return i;
            return -1;
        }

        private void Load(Button btn, int file_num)
            {
            
            string file_name;
            int tag = (int)btn.Tag;

            if (file_num == -1)
            {
                file_name = "images/cover.png";
            }
            else
            {
                file_name = string.Format("images/pic{0}.png", file_num);
            }
            //changing picture
            file_name = System.IO.Path.Combine(Environment.CurrentDirectory, file_name);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(file_name);
            image.EndInit();

            Image i = new Image();
            i.Source = image;
            btn.Content = i;

        }

            
        }
}

  
