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
            Console.WriteLine(id_tac);
            
        }

        private void MostrarImagen1() {
            lect.threadsArray[id_tac].Join();
            var aux = lect.obtenerArchivo(id_tac);
            auxUH = lect.obtenerArchivo(id_tac);
            pictureBox1.Image = aux.ObtenerImagen();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                    Console.WriteLine("si entre we");
                    id_tac = 0;
                    string imagen = folderBrowserDialog1.SelectedPath;
                    lect = new LecturaArchivosDicom(imagen);
                    //double [] longitud = LecturaArchivosDicom.Pregunta_Python_Dimensiones(1, ruta);
                    num_tacs = lect.num_archivos(imagen);
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
            Console.WriteLine(comboBox1.SelectedItem);
            string lectura = (string)comboBox1.SelectedItem;
            if(lectura == "Personalizada"){
                label6.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
            }
            
        }

        private void button4_Click(object sender, EventArgs e){
            reglaBool = true;
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
        }

        private void button2_Click(object sender, EventArgs e) {
            if (id_tac == 0)
                id_tac = num_tacs - 1;
            else
                id_tac--;
            MostrarImagen1();
            Console.WriteLine(id_tac);
        }
    }
}