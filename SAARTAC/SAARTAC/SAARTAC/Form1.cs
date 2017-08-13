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
        public Form1() {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e) {
            try {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                    Console.WriteLine("si entre we");
                    string imagen = folderBrowserDialog1.SelectedPath;
                    LecturaArchivosDicom lect = new LecturaArchivosDicom(imagen);
                    var aux = lect.obtenerArchivo(0);
                    auxUH = lect.obtenerArchivo(0);
                    pictureBox1.Image = aux.ObtenerImagen();
                }
                else
                    Console.WriteLine("aqui es el pedo we");
            }
            catch (Exception ex) {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
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
    }
}