using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SAARTAC {
    public partial class Form1 : Form {
        private static MatrizDicom auxUH;
        private Seccion seccion;
        private Regla regla;
        private bool draw = false, reglaBool = false;
        private List<bool[,]> matrizTratada = new List<bool[,]>();
        int id_tac, num_tacs, uh_per, factor_per,bandera = 0;
        LecturaArchivosDicom lect;
        public Form1() {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e) {
            /*try {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                    Console.WriteLine("si entre we");
                    id_tac = 0;
                    string imagen = folderBrowserDialog1.SelectedPath;
                    lect = new LecturaArchivosDicom(imagen);
                    num_tacs = lect.num_archivos(imagen);
                    Console.WriteLine(num_tacs);
                    var aux = lect.obtenerArchivo(id_tac);
                    auxUH = lect.obtenerArchivo(id_tac);
                    pictureBox1.Image = aux.ObtenerImagen();
                }
                else
                    Console.WriteLine("aqui es el pedo we");
            }
            catch (Exception ex) {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e){
            int x = pictureBox1.PointToClient(Cursor.Position).X;
            int y = pictureBox1.PointToClient(Cursor.Position).Y;
            if (auxUH != null){
                label2.Text = (auxUH.ObtenerUH(x, y)).ToString();
            }
            if (draw & e.Button == MouseButtons.Left){
                seccion.setFinal(x, y);
                Graphics objGrafico = this.pictureBox1.CreateGraphics();
                seccion.setRectangle();
                objGrafico.DrawRectangle(seccion.getPen(), seccion.getRectangle());
                pictureBox1.Invalidate();
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left && reglaBool != true && auxUH != null && bandera != 1){
                Console.WriteLine("promedios");
                draw = true;
                seccion = new Seccion(pictureBox1.PointToClient(Cursor.Position).X, pictureBox1.PointToClient(Cursor.Position).Y, auxUH);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e){
            if (draw){
                Graphics objGrafico = this.pictureBox1.CreateGraphics();
                seccion.setRectangle();
                objGrafico.DrawRectangle(seccion.getPen(), seccion.getRectangle());
                label5.Text = (seccion.createAverage()).ToString();
                draw = false;
                int milliseconds = 1200;
                Thread.Sleep(milliseconds);
                pictureBox1.Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (id_tac >= num_tacs -1)
                id_tac = 0;
            else
                id_tac++;
            MostrarImagen1();
            if(matrizTratada.Count > 0)
                MostrarImagen2();
            Console.WriteLine(id_tac);
            
        }

        private void MostrarImagen1() {
            var aux = lect.obtenerArchivo(id_tac);
            auxUH = lect.obtenerArchivo(id_tac);
            pictureBox1.Image = aux.ObtenerImagen();
        }

        private void MostrarImagen1(Bitmap imagen) {
            pictureBox1.Image = imagen;
        }

        private void MostrarImagen2() {

            var imagenResultado = obtenerImagenUmbral(matrizTratada[id_tac], auxUH.ObtenerImagen(), Color.Red);
            pictureBox2.Image = imagenResultado;
        }

        private void MostrarImagen2(Bitmap imagen) {
            pictureBox2.Image = imagen;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                    Console.WriteLine("si entre we");
                    id_tac = 0;
                    string imagen = folderBrowserDialog1.SelectedPath;
                    lect = new LecturaArchivosDicom(imagen);
                    num_tacs = lect.num_archivos();
                    Console.WriteLine(num_tacs);
                    MostrarImagen1();
                }
                else
                    Console.WriteLine("aqui es el pedo we");
            }
            catch (Exception ex) {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            matrizTratada.Clear();
            Console.WriteLine(comboBox1.SelectedItem);
            string lectura = (string)comboBox1.SelectedItem;
            Umbralizacion operaciones = new Umbralizacion();
            if(lectura == "Personalizada"){
                label6.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
            } else {
                for (int i = 0; i < lect.num_archivos(); i++) {
                    var archivo = lect.obtenerArchivo(i);
                    var matrizResultado = operaciones.UmbralizacionPara(lectura, archivo.matriz);
                    matrizTratada.Add(matrizResultado);
                }
                MostrarImagen2();
            }
            
        }

        private void button4_Click(object sender, EventArgs e){
            reglaBool = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e){
            if (reglaBool && bandera == 0){
                Console.WriteLine("entro 1");
                regla = new Regla(pictureBox1.PointToClient(Cursor.Position).X, pictureBox1.PointToClient(Cursor.Position).Y);
                bandera = 1;
            }
            else if (reglaBool && bandera == 1){
                Console.WriteLine("entro 2");
                reglaBool = false;
                bandera = 0;
                regla.setFinal(pictureBox1.PointToClient(Cursor.Position).X, pictureBox1.PointToClient(Cursor.Position).Y);
                Graphics objGrafico = this.pictureBox1.CreateGraphics();
                Pen myPen = new Pen(Color.Red, 1);
                objGrafico.DrawLine(myPen, regla.getPointInicio(), regla.getPoinFinal());
                double [] distancias = LecturaArchivosDicom.Pregunta_Python_Dimensiones(1, auxUH.obtenerRuta());
                label9.Text = (regla.getDistancia(distancias[0], distancias[1])).ToString("N3");
                int milliseconds = 1200;
                Thread.Sleep(milliseconds);
                pictureBox1.Invalidate();


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {

        }

        private void label7_Click(object sender, EventArgs e) {

        }

        private void button1_Click_1(object sender, EventArgs e) {
            uh_per = int.Parse(textBox1.Text);
            factor_per = int.Parse(textBox2.Text);
            Console.WriteLine(uh_per);
            Console.WriteLine(factor_per);
            label6.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            Umbralizacion operaciones = new Umbralizacion();
            for(int i = 0; i < lect.num_archivos() ; i++) {
                var archivo = lect.obtenerArchivo(i);
                var matrizResultado = operaciones.UmbralEnRango(archivo.matriz, uh_per - factor_per, uh_per + factor_per);
                matrizTratada.Add(matrizResultado);
            }
            MostrarImagen2();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (id_tac == 0)
                id_tac = num_tacs - 1;
            else
                id_tac--;
            MostrarImagen1();

            if (matrizTratada.Count > 0)
                MostrarImagen2();

            Console.WriteLine(id_tac);
        }
        private Bitmap obtenerImagenUmbral(bool[,] umbral, Bitmap matrizOriginal, Color color) {
            Bitmap resultado = new Bitmap(matrizOriginal);
            int N = umbral.GetLength(0);
            int M = umbral.GetLength(1);
            for(int i = 0; i < N; i++) {
                for(int j = 0; j < M; j++) {
                    if(umbral[i, j]) {
                        resultado.SetPixel(i, j, color);
                    }
                }
            }
            return resultado;
        }

        private Bitmap obtenerImagenConVentana(int[,] matriz, int limiteInferior, int limiteSuperior) {
            int N = matriz.GetLength(0);
            int M = matriz.GetLength(1);
            Bitmap imagen = new Bitmap(N, M);

            int tam = limiteSuperior - limiteInferior + 1;
            double porcion = 255.0 / tam;

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < M; j++) {
                    int valorGris = (int)(porcion * (matriz [i, j] - limiteInferior + 1));
                    if (valorGris < 0 || valorGris > 255)
                        valorGris = 0;
                    Color color = Color.FromArgb(valorGris, valorGris, valorGris);
                    imagen.SetPixel(i, j, color);
                }
            }
            return imagen;
        }
    }
}