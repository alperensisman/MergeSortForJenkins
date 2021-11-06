using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortForJenkins
{
    public class MergeSort
    {
        void merge(ref int[] dizi, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = dizi[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = dizi[m + 1 + j];
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    dizi[k] = L[i];
                    i++;
                }
                else
                {
                    dizi[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                dizi[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                dizi[k] = R[j];
                j++;
                k++;
            }

        }
        public void mergeSort(ref int[] dizi, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                mergeSort(ref dizi, l, m);
                mergeSort(ref dizi, m + 1, r);
                merge(ref dizi, l, m, r);
            }
        }
    }
    class Program
    {
        public static int[] randomDizi(int countArr)
        {
            int[] dizi = new int[countArr];
            Random rnd = new Random();
            for (int i = 0; i < countArr; i++) dizi[i] = rnd.Next(0, countArr + 1);
            return dizi;
        }

        public static void printDizi(string tag,int[] dizi)
        {
            Console.WriteLine("\n" + tag + "\n");
            for (int i = 0; i < dizi.Length; i++) Console.Write(dizi[i].ToString() + ",");
            Console.WriteLine(new string('_', 100));
        }

        static void Main(string[] args)
        {
            int uzunluk = 10000;
            int[] dizi = randomDizi(uzunluk);
            MergeSort ms = new MergeSort();
            Stopwatch stp = new Stopwatch();
            stp.Start();
            ms.mergeSort(ref dizi, 0, uzunluk - 1);
            stp.Stop();
            Console.WriteLine("Geçen Süre: " + stp.Elapsed);
        }
    }
}
