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
        public Form1() {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    Console.WriteLine("si entre we");
                    string imagen = openFileDialog1.FileName;
                    LecturaArchivosDicom lect = new LecturaArchivosDicom(imagen);
                    var aux = lect.obtenerArchivo(0);
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
    }
}