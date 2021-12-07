using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    internal class MergeSort
    {
        int[] dizi;
        public MergeSort(int[] dizi)
        {
            this.dizi = dizi;
        }

        public int[] Sort()
        {
            Sort(0, dizi.Length - 1);

            return dizi;
        }

        private void Sort(int sol, int sag)
        {
            if (sol < sag)//Eleman sayısı 1 den büyük ise
            {

                //orta indexi bul
                int orta = (sol + sag) / 2;

                //Sol kümeyi böl sırala
                Sort(sol, orta);

                //Sağ kümeyi böl sırala
                Sort(orta + 1, sag);

                Birlestir(sol, orta, sag);//Bölüp sıraladıklarını birleştir.
            }
        }

        private void Birlestir(int sol, int orta, int sag)
        {
            int solElemanSayisi = orta - sol + 1;
            int sagElemanSayisi = sag - orta;

            int[] SOL = new int[solElemanSayisi];
            int[] SAG = new int[sagElemanSayisi];

            for (int t = 0; t < solElemanSayisi; ++t)
                SOL[t] = dizi[sol + t];

            for (int z = 0; z < sagElemanSayisi; ++z)
                SAG[z] = dizi[orta + 1 + z];

            int i = 0, j = 0;
            int k = sol;
            while (i < solElemanSayisi && j < sagElemanSayisi)
            {
                //Soldaki sayi sağdakinden küçük eşitse diziye önce onu koy.
                if (SOL[i] <= SAG[j])
                {
                    dizi[k] = SOL[i];
                    i++;
                }

                //Sağdaki sayi soldakinden küçük eşitse diziye önce onu koy.
                else
                {
                    dizi[k] = SAG[j];
                    j++;
                }
                k++;
            }

            //SOL da kalanları diziye ekle
            while (i < solElemanSayisi)
            {
                dizi[k] = SOL[i];
                i++;
                k++;
            }

            //SAĞ da kalanları diziye ekle
            while (j < sagElemanSayisi)
            {
                dizi[k] = SAG[j];
                j++;
                k++;
            }

        }
    }
}
