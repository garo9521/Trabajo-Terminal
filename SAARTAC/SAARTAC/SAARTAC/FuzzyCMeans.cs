using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAARTAC
{
    class FuzzyCMeans
    {
        private LecturaArchivosDicom matrices;
        private MatrizDicom matriz_actual;
        private int numerosK, ite, numArchivos;
        private int min = -1000, max = 1600;
        private List<Double> centros;
        private List<Double> conjunto = new List<Double>();
        private int[,,] clases;
        private double[,,,] pertenencia;
        private double[,,,] distancias;
        private Random rnd;
        private double m = 2.0;

        public FuzzyCMeans(LecturaArchivosDicom lect, int k, int iteraciones, int numeros_archivos)
        {
            matrices = lect;
            numerosK = k;
            numArchivos = numeros_archivos;
            clases = new int[512, 512, numeros_archivos];
            pertenencia = new double[512, 512, k, numeros_archivos];
            distancias = new double[512, 512, k, numeros_archivos];
            ite = iteraciones;
            rnd = new Random();
            generarCentros();
            for(int i = 0; i < iteraciones; i++){
	            GenerarDistancias();
	            ActualizarPertenencia();
	           	GeneraNuevosCentros();
        	}
        }

        public void generarCentros()
        {
            centros = new List<Double>();
            rnd = new Random();
            for (int i = 0; i < numerosK; i++)
                centros.Add(rnd.Next(min, max));
        }

        public void GenerarDistancias()
        {
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {

                    for (int p = 0; p < numArchivos; p++)
                    {
                        matriz_actual = matrices.obtenerArchivo(p);

                        for (int k = 0; k < numerosK; k++)
                        {
                            double dist = matriz_actual.ObtenerUH(i, j) - centros[k];
                            distancias[i, j, k, p] = dist * dist;
                        }
                    }
                }
            }
        }
    

        public void ActualizarPertenencia()
        {
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {

                    for (int p = 0; p < numArchivos; p++)
                    {
                        double test = 0.0;
                        for (int k = 0; k < numerosK; k++)
                        {
                            double sum = 0.0;
                            for(int l = 0; l < numerosK; l++)
                            {
                                sum += Math.Pow(distancias[i, j, k, p] / distancias[i, j, l, p], 2.0 / (m - 1.0));
                            }
                            pertenencia[i, j, k, p] = 1.0 / sum;
                            test += pertenencia[i, j, k, p];
                        }
                    }
                }
            }
        }

        public void GeneraNuevosCentros(){
        	for(int k = 0; k < numerosK; k++){
        		double a = 0.0;
        		double b = 0.0;
                long aa = 0;
                long bb = 0;
				for(int p = 0; p < numArchivos; p++){
					matriz_actual = matrices.obtenerArchivo(p);
	        		for(int i = 0; i < 512; i++){
	        			for(int j = 0; j < 512; j++){
                            double valor = Math.Round(Math.Pow(pertenencia [i, j, k, p], m), 5);
                            if (valor <= 0.001)
                                continue;
                            aa +=(long) (Math.Round(valor * matriz_actual.ObtenerUH(i, j), 5) * 100000);
                            bb += (long) (valor * 100000);
                            a += valor * matriz_actual.ObtenerUH(i, j);
                            b += valor;
                            a = Math.Round(a, 5);
                            b = Math.Round(b, 5);

                        }
                    }
        		}
        		centros[k] = (double)aa / (double)bb;
        	}
        }

    }
}

