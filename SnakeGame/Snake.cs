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
    partial class Snake
    {
        public bool oynatma = true;

        public void HareketEttir(string yon)
        {
            oynatma = false;

            if (yon == "sag")
            {
                yilanbasLeft += 10;
                yilanekrandancikti(yon);
                koordinatgüncelle(yon);
                yonlendir();
            }
            else if(yon=="sol")
            {
                yilanbasLeft -= 10;
                yilanekrandancikti(yon);
                koordinatgüncelle(yon);
                yonlendir();
            }
            else if(yon=="asagi")
            {
                yilanbasTop += 10;
                yilanekrandancikti(yon);
                koordinatgüncelle(yon);
                yonlendir();
            }
            else if(yon == "yukari")
            {
                yilanbasTop -= 10;
                yilanekrandancikti(yon);
                koordinatgüncelle(yon);
                yonlendir();
            }

            oynatma = true;
        }

        private void koordinatgüncelle(string yon)
        {
            yilansonLeft = yilangövdekoordinatlari[yilangövdeRectangle.Count - 1, 0]; //  Yılanın son gövdesinin lefti alındı.
            yilansonTop  = yilangövdekoordinatlari[yilangövdeRectangle.Count - 1, 1]; // Yılanın son gövdesinin topu alındı.

            int[,] sanaldiziyilangövdekoordinatları = new int[100, 2];

            for (int i = 0; i < yilangövdeRectangle.Count; i++) // İkinci diziye elemanları aktardık.
            {
                sanaldiziyilangövdekoordinatları[i, 0] = yilangövdekoordinatlari[i, 0];
                sanaldiziyilangövdekoordinatları[i, 1] = yilangövdekoordinatlari[i, 1];
            }

            for (int i = 1; i < yilangövdeRectangle.Count; i++)
            {
                yilangövdekoordinatlari[i, 0] = sanaldiziyilangövdekoordinatları[i - 1, 0] ;
                yilangövdekoordinatlari[i, 1] = sanaldiziyilangövdekoordinatları[i - 1, 1] ;
            }

            yilangövdekoordinatlari[0,0] = this.yilanbasLeft;
            yilangövdekoordinatlari[0,1] = this.yilanbasTop;
        }

        private void yonlendir()
        {
            for (int i = 0; i < yilangövdeRectangle.Count; i++)
            {
                Rectangle sanalgövde = (Rectangle)yilangövdeRectangle[i];
                sanalgövde.Margin = new System.Windows.Thickness(yilangövdekoordinatlari[i, 0], yilangövdekoordinatlari[i, 1],0,0);
                yilangövdeRectangle[i] = sanalgövde;
            }
        }

        private void yilanekrandancikti(string yon)
        {
            if (yon == "sag" && yilanbasLeft>670)
            {
               yilanbasLeft = 0;
            }
            else if (yon == "sol" &&  yilanbasLeft<0)
            {
                yilanbasLeft = 670;
            }

            else if (yon == "yukari" && yilanbasTop<0)
            {
                yilanbasTop = 450;
            }
            else if (yon == "asagi" && yilanbasTop>450)
            {
                yilanbasTop = 0;
            }
        }

        public bool  yilankendinecarpti()
        {
            bool durum = false;
            for (int i = 1; i < yilangövdeRectangle.Count; i++)
            {
                if (yilanbasLeft == yilangövdekoordinatlari[i,0] && yilanbasTop == yilangövdekoordinatlari[i,1])
                {
                    durum = true;
                    break;
                }
            }

            if (durum)
            {
                for (int i = 0; i < yilangövdeRectangle.Count; i++)
                {
                    Rectangle sanal = (Rectangle)yilangövdeRectangle[i];
                    sanal.Fill = Brushes.Black;
                }
                yilangövdeRectangle.Clear();
            }
            return durum;
         }

        public bool elmaolusturulduamayilanlaayniyerdemi(int elmaleft, int elmatop)
        {
            bool durum = false;
            for (int i = 0; i < yilangövdeRectangle.Count; i++)
            {
                if (elmaleft == yilangövdekoordinatlari[i, 0] && elmatop == yilangövdekoordinatlari[i, 1])
                {
                    durum = true;
                    break;
                }
            }

            return durum;
        }
    }
}
