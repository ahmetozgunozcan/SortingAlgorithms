﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SortingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isValid(out int[]? dizi)
        {
            dizi = null;

            var text = Elemanlar.Text.Replace(" ", "");

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Lütfen sayısal değerler giriniz.");
                return false;
            }

            var elemanlar = text.Split(',');


            if (elemanlar.Any(p => !int.TryParse(p, out _)))
            {
                MessageBox.Show("Lütfen sayısal değerler giriniz.");
                return false;
            }

            dizi = elemanlar.Select(p => Convert.ToInt32(p)).ToArray();

            return true;
        }

        private void Random(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int[] dizi = new int[20];

            for (int i = 0; i < dizi.Length; i++)
            {
                int num = rnd.Next(1, 50);
                dizi[i] = num;
            }

            Elemanlar.Text = string.Join(",", dizi);

        }


        private void Bubble(object sender, RoutedEventArgs e)
        {
            BubbleSortSonuc.Content = "";

            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            int[]? dizi = null;
            if (!isValid(out dizi))
                return;

            if (dizi == null) return;

            //eleman sayısı
            var n = dizi.Length;
            //Ana döngüyü oluşturuyoruz.
            //dizinin eleman sayısının 1 eksiği kadar döngü gerçekleşmeli.
            for (int dongu = 0; dongu < (n - 1); dongu++)
            {
                //her düngüde 1 eleman yerleşeceği için adım sayısı önceki döngüye göre 1 eksik olmalıdır.
                for (int i = 0; i < n - 1 - dongu; i++)
                {
                    var e1 = dizi[i];
                    var e2 = dizi[i + 1];
                    //sıralı ise bir sonraki adıma geç.

                    if (e1 <= e2)
                        continue;

                    //sıralı değilse yer değiştir.  
                    dizi[i] = e2;
                    dizi[i + 1] = e1;
                }
            }
            //sw.Stop();

            BubbleSortSonuc.Content = string.Join(",", dizi);
        }



        private void Insertion(object sender, RoutedEventArgs e)
        {
            InsertionSortSonuc.Content = "";

            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            int[]? dizi = null;
            if (!isValid(out dizi))
                return;

            if (dizi == null) return;

            //dizinin ilk elemanını yerinde bıraktık.

            //2. elemanından başlıyoruz.
            for (int i = 1; i <= (dizi.Length - 1); i++)
            {
                //araya sokacağımız veriyi tutuyoruz.
                var current = dizi[i];

                //hangi indexte bulunduğumuzu tutuyoruz.
                int currentRealIndex = i;

                //sola doğru yani sıralanmış kayıtlar arasında tarama yapıyoruz.
                //Sayımızın büyük olduğu elemana kadar ilerleyip araya sokacağımız index değerini buluyoruz.
                for (int j = i - 1; j >= 0 && currentRealIndex > 0; j--)
                {
                    if (dizi[j] < current)
                        break;

                    currentRealIndex--;
                }

                //araya sokulacak indexten sonraki tüm elemanları bir adım sağa kaydırıyoruz.
                for (int j = i; j > currentRealIndex; j--)
                {
                    dizi[j] = dizi[j - 1];
                }

                //araya elemanımızı yerleştiriyoruz.
                dizi[currentRealIndex] = current;
            }

            //sw.Stop();

            InsertionSortSonuc.Content = string.Join(",", dizi);
        }
    }
}
