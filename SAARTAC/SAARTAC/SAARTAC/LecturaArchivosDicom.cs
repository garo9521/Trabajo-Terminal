﻿using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
//esto es una prueba
//esto es una prueba x2
namespace SAARTAC {

    internal class LecturaArchivosDicom {

        public static MatrizDicom[] archivosDicom;
        public Thread[] threadsArray;

        public MatrizDicom obtenerArchivo(int x) {
            return archivosDicom[x];
        }

        public LecturaArchivosDicom(string ruta) {
            int x = 0;
            string[] fileEntries = Directory.GetFiles(ruta);

            DateTime start = DateTime.Now;
            int N = fileEntries.Length;
            threadsArray = new Thread[N];
            archivosDicom = new MatrizDicom[N];

            for (int i = 0; i < N; i++) {
                //Console.WriteLine(fileEntries[i]);
                string parametro = "\"" + fileEntries[i] + "\"";
                ParametroPython aux = new ParametroPython(x, parametro, i);
                threadsArray[i] = new Thread(() => Pregunta_Python(aux));

            }
            for (int i = 0; i < N; i++) {
                threadsArray [i].Start();
            }
            for (int i = 0; i < N; i++) {
                threadsArray [i].Join();
            }


            TimeSpan timeDiff = DateTime.Now - start;
            var res = timeDiff.TotalMilliseconds;

            Console.WriteLine("Tiempo de ejecucion: " + res);
            //var pruebaImagen = archivosDicom[1].ObtenerImagen();
            //pruebaImagen.Save("prueba.jpg");
            //pruebaImagen.Dispose();

            //Console.WriteLine("llegue aqui");
        }

        public int num_archivos(){
            return archivosDicom.Length;
        }

        public static double[] Pregunta_Python_Dimensiones(int pregunta, string ruta) {

            string python = @"C:\Python27\python.exe";
            string myPythonApp = @"C:\Users\raull\Documents\GitHub\Trabajo-Terminal\TT2.0C#\sum.py";
            
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            myProcessStartInfo.Arguments = myPythonApp + " " + pregunta + " " + ruta;
            myProcessStartInfo.CreateNoWindow = true;
            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;

            //Console.WriteLine("Calling Python script with arguments {0} and {1} pos == {2}", pregunta, ruta, pos);
            myProcess.Start();

            StreamReader myStreamReader = myProcess.StandardOutput;

            string myString = myStreamReader.ReadLine();
            string [] tokens = myString.Split();
            double[] M = { Convert.ToDouble(tokens [0]), Convert.ToDouble(tokens[1])};
            return M;
        }

        public static void Pregunta_Python(ParametroPython o) {
            string ruta = o.ruta;
            int pregunta = o.x;
            int pos = o.pos;            
            string python = @"C:\Python27\python.exe";
            string myPythonApp = @"C:\Users\raull\Documents\GitHub\Trabajo-Terminal\TT2.0C#\sum.py";            
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            myProcessStartInfo.Arguments = myPythonApp + " " + pregunta + " " + ruta;
            myProcessStartInfo.CreateNoWindow = true;
            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;

            //Console.WriteLine("Calling Python script with arguments {0} and {1} pos == {2}", pregunta, ruta, pos);
            myProcess.Start();

            StreamReader myStreamReader = myProcess.StandardOutput;

            string myString = myStreamReader.ReadLine();
            string [] tokens = myString.Split();
            int N = Convert.ToInt32(tokens [0]);
            int M = Convert.ToInt32(tokens [1]);
            MatrizDicom dicom = new MatrizDicom(ruta, N, M);
            int [,] auxMatriz = new int[N, M];
            for (int j = 0; j < N; j++) {
                myString = myStreamReader.ReadLine();
                string[] tokens2 = myString.Split();
                int[] filaDicom = Array.ConvertAll(tokens2, int.Parse);
                for (int k = 0; k < M; k++) {
                    auxMatriz[j, k] = filaDicom[k] - 1000;
                }
            }
            dicom.CopiarMatriz(ref auxMatriz);
            myProcess.WaitForExit();
            myProcess.Close();            
            archivosDicom[pos] = dicom;
        }
    }
	
	//Esto es un prueba x3
}