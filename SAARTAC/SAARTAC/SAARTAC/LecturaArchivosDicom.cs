using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

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
                threadsArray[i].Start();
            }

            TimeSpan timeDiff = DateTime.Now - start;
            var res = timeDiff.TotalMilliseconds;

            Console.WriteLine("Tiempo de ejecucion: " + res);
            //var pruebaImagen = archivosDicom[1].ObtenerImagen();
            //pruebaImagen.Save("prueba.jpg");
            //pruebaImagen.Dispose();

            //Console.WriteLine("llegue aqui");
        }

        public int num_archivos(String path){
            string[] fileEntries = Directory.GetFiles(path);
            return fileEntries.Length;
        }

        public static double[] Pregunta_Python_Dimensiones(int pregunta, string ruta) {
            string python = @"D:\Python27\python.exe";
            string myPythonApp = @"C:\Users\AlexisAlan\Documents\GitHub\Trabajo-Terminal\TT2.0C#\sum.py";

            ruta = "\"" + ruta + "\"";

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
            MatrizDicom dicom = new MatrizDicom(ruta);
            string python = @"C:\Python27\python.exe";
            string myPythonApp = @"C:\Users\AlexisAlan\Documents\GitHub\Trabajo-Terminal\TT2.0C#\sum.py";

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
            int M = Convert.ToInt32(myString);
            int[,] auxMatriz = new int[512, 512];
            for (int j = 0; j < M; j++) {
                myString = myStreamReader.ReadLine();
                string[] tokens = myString.Split();
                int[] filaDicom = Array.ConvertAll(tokens, int.Parse);
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
}