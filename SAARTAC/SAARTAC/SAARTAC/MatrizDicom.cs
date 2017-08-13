using System;
using System.IO;
using System.Drawing;

namespace SAARTAC { 

    internal class MatrizDicom {
        private static int N;
        public int[,] matriz;
        public int minValor;
        public int maxValor;

        public MatrizDicom() {
            N = 512;
            matriz = new int[N + 10, N + 10];
            minValor = 10000;
            maxValor = -10000;
        }

        public int ObtenerUH(int x, int y){
            return matriz[x,y];
        }

        public void CopiarMatriz(ref int[,] A) {
            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    matriz[i, j] = A[i, j];
                    minValor = Math.Min(minValor, matriz[i, j]);
                    maxValor = Math.Max(maxValor, matriz[i, j]);
                }
            }
        }

        public void ImprimeMatriz() {
            Console.WriteLine(matriz[0, 1]);
        }



        public Bitmap ObtenerImagen() {
            Bitmap imagen = new Bitmap(512, 512);
            int tam = maxValor - minValor + 1;
            double porcion = 255.0 / tam;

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    int valorGris = (int)(porcion * matriz[i, j]);
                    Color color = Color.FromArgb(valorGris, valorGris, valorGris);
                    imagen.SetPixel(i, j, color);
                }
            }
            Console.ReadLine();
            return imagen;

        }
    }
}