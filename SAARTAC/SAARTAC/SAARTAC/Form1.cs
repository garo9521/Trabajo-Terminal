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
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace SAARTAC {
    public partial class Form1 : Form {
        private static MatrizDicom auxUH;
        int id_tac, num_tacs;
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
                Console.WriteLine("X = " + x + " Y = " + y);
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
            if(lectura == "Personalizada")
                textBox1.

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