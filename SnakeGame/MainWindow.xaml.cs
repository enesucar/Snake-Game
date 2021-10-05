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

namespace SnakeGame
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Snake snake = new Snake();
        DispatcherTimer oynat_Timer = new DispatcherTimer();
        bool sag = true; bool sol = false; bool yukari = false; bool asagi = false;
        int yilansayisi = 0;
        int elmaleft;
        int elmatop;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            snake.YilanbasLEFT = 250;
            snake.YilanbasTOP = 200;
            govdeolustur(snake.YilanbasLEFT, snake.YilanbasTOP);
            elma();

            oynat_Timer.Interval = TimeSpan.FromMilliseconds(35);
            oynat_Timer.Tick += Oynat_Timer_Tick;
            oynat_Timer.Start();
        }
       
        private void Oynat_Timer_Tick(object sender, EventArgs e)
        {
            if (sag == true)
            {
                snake.HareketEttir("sag");
                yilankendinecarpti();
            }
            else if (sol == true)
            {
                snake.HareketEttir("sol");
                yilankendinecarpti();
            }
            else if(asagi == true)
            {
                snake.HareketEttir("asagi");
                yilankendinecarpti();
                elmaileyilanayniyerdemi();
            }
            else if (yukari == true)
            {
                snake.HareketEttir("yukari");
                yilankendinecarpti();
            }

            label1.Content = "Skor: " + (yilansayisi);
            elmaileyilanayniyerdemi();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.D || e.Key == Key.Right) && sol == false && snake.oynatma == true)
            {
                yonfalse();
                sag = true;
            }
            else if ((e.Key == Key.A || e.Key == Key.Left) && sag == false && snake.oynatma == true)
            {
                yonfalse();
                sol = true;
            }
            else if ((e.Key == Key.S || e.Key == Key.Down) && yukari == false && snake.oynatma == true)
            {
                yonfalse();
                asagi = true;
            }
            else if ((e.Key == Key.W || e.Key == Key.Up) && asagi == false && snake.oynatma == true)
            {
                yonfalse();
                yukari = true;
            }
        }

        private void govdeolustur(int left, int top)
        {
            Rectangle gövde = new Rectangle();
            gövde.Fill = Brushes.Yellow;
            gövde.Width = 10;
            gövde.Height = 10;

            gövde.HorizontalAlignment = HorizontalAlignment.Left;
            gövde.VerticalAlignment = VerticalAlignment.Top;

            gövde.Margin = new Thickness(left, top, 0, 0);
            gövde.Stroke = Brushes.Black;
            panel.Children.Add(gövde);

            snake.yilangövdeRectangle.Add(gövde);
            snake.yilangövdekoordinatlari[yilansayisi, 0] = left;
            snake.yilangövdekoordinatlari[yilansayisi, 1] = top;

            yilansayisi++;
        }

        Rectangle apple = new Rectangle();
        private void elma()
        {
            apple.Fill = Brushes.Red;
            apple.Width = 10;
            apple.Height = 10;
            apple.Stroke = Brushes.Black;
            apple.HorizontalAlignment = HorizontalAlignment.Left;
            apple.VerticalAlignment = VerticalAlignment.Top;

            Random rnd = new Random();

            elmakoordinatdegis();
            panel.Children.Add(apple);
        }

        private void elmakoordinatdegis()
        {
            Random rnd = new Random();
            Gel:
            int[] elmarandomleft = {30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310, 320, 330, 340, 350, 360, 370, 380, 390, 400, 410, 420, 430, 440, 450, 460, 460, 470, 480, 490, 500, 510, 520, 530, 540, 550, 560, 570, 580, 590, 600, 610, 620, 630, 640};
            int[] elmarandomtop = {30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310, 320, 330, 340, 350, 360, 370, 380, 390, 400, 410, 420 };

            int elmasanalleft = rnd.Next(0, elmarandomleft.Length);
            int elmasanaltop = rnd.Next(0, elmarandomtop.Length);

            if (snake.elmaolusturulduamayilanlaayniyerdemi(elmarandomleft[elmasanalleft], elmarandomtop[elmasanaltop]))
                goto Gel;

            apple.Margin = new Thickness(elmarandomleft[elmasanalleft], elmarandomtop[elmasanaltop], 0, 0);
            elmaleft = elmarandomleft[elmasanalleft];
            elmatop = elmarandomtop[elmasanaltop];
        }

        private void elmaileyilanayniyerdemi()
        {
            if (snake.YilanbasLEFT == elmaleft && snake.YilanbasTOP == elmatop)
            {
                govdeolustur(snake.YilansonLEFT, snake.YilansonTOP);
                elmakoordinatdegis();
            }
        }

        private void yilankendinecarpti()
        {
            if (snake.yilankendinecarpti())
            {
                elmakoordinatdegis();
                yilansayisi = 0;
                govdeolustur(250, 200);
            }
        }

        private void yonfalse()
        {
            sol = false;
            sag = false;
            yukari = false;
            asagi = false;
        }
    }
}
