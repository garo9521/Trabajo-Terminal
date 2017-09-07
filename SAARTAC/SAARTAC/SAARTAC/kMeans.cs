using SAARTAC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAARTA
{
    class kMeans
    {

        private MatrizDicom matriz;
        private int numerosK, ite;
        private int min = -1000, max = 2000;
        private List<Double> centros;
        private List<Double> conjunto = new List<Double>();
        private List<List<Tuple<int, int>>> clases;
        private Random rnd;

        public kMeans(MatrizDicom mtrz, int k, int iteraciones){
            matriz = mtrz;
            numerosK = k;
            clases = new List<List<Tuple<int, int>>>(k);
            ite = iteraciones;
            generarCentros();
            mainKmeans();
        }

        public void generarCentros(){
            centros = new List<Double>();
            rnd = new Random();
            for (int i = 0; i < numerosK; i++)
                centros.Add(rnd.Next(min, max));            
        }

        public void mainKmeans(){
            for (int k = 0; k < ite; k++){
                Console.WriteLine(k + 1);
                clases.Clear();
                for (int i = 0; i < numerosK; i++)
                    clases.Add(new List<Tuple<int, int>>());
                for (int i = 0; i < 512; i++)
                    for (int j = 0; j < 512; j++)
                        distanciaEuclidiana(i, j);
                promedio();
            }

        }

        public void distanciaEuclidiana(int i, int j)
        {
            int indc = 0;
            conjunto.Clear();
            foreach (Double indice in centros)
            {
                Double resta = Math.Abs(matriz.ObtenerUH(i, j) - indice);
                conjunto.Add(resta);
            }
            for (int k = 1; k < conjunto.Count; k++)
                if (conjunto[indc] > conjunto[k])
                    indc = k;
            clases[indc].Add(new Tuple<int, int>(i, j));            
        }

        public void promedio(){
            centros.Clear();
            foreach (List<Tuple<int, int>> i in clases){
                int n = i.Count;
                int sumaUH = 0;
                foreach (Tuple<int, int> j in i)
                    sumaUH += matriz.ObtenerUH(j.Item1, j.Item2);                
                Double promedio = sumaUH / n;                
                centros.Add(promedio);
            }
        }

        public List<List<Tuple<int, int>>> getClases(){
            return clases;
        }

    }
}
