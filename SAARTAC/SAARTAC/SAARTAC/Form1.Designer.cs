namespace SAARTAC
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textoUH = new System.Windows.Forms.Label();
            this.contUH = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotarDerechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotarIzquierdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionUmbralizacion = new System.Windows.Forms.ComboBox();
            this.texto_umbralizacion = new System.Windows.Forms.Label();
            this.textoPromedio = new System.Windows.Forms.Label();
            this.contPromedio = new System.Windows.Forms.Label();
            this.centroUmbralizacion = new System.Windows.Forms.TextBox();
            this.ventanaUmbralizacion = new System.Windows.Forms.TextBox();
            this.textoUHumbralizacion = new System.Windows.Forms.Label();
            this.textoMasmenos = new System.Windows.Forms.Label();
            this.botonUmbralizacion = new System.Windows.Forms.Button();
            this.botonRegla = new System.Windows.Forms.Button();
            this.textoDistancia = new System.Windows.Forms.Label();
            this.contMedida = new System.Windows.Forms.Label();
            this.textoMm = new System.Windows.Forms.Label();
            this.centroVentana = new System.Windows.Forms.TextBox();
            this.ventanaVentana = new System.Windows.Forms.TextBox();
            this.botonVentana = new System.Windows.Forms.Button();
            this.barraZoom = new System.Windows.Forms.TrackBar();
            this.botonKmeans = new System.Windows.Forms.Button();
            this.botonZoom = new System.Windows.Forms.Button();
            this.boton3D = new System.Windows.Forms.Button();
            this.barraHerramientas = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.visibleZoom = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.botonDerecha = new System.Windows.Forms.Button();
            this.botonIzquierda = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraZoom)).BeginInit();
            this.barraHerramientas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visibleZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textoUH
            // 
            this.textoUH.AutoSize = true;
            this.textoUH.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoUH.Location = new System.Drawing.Point(12, 612);
            this.textoUH.Name = "textoUH";
            this.textoUH.Size = new System.Drawing.Size(34, 16);
            this.textoUH.TabIndex = 2;
            this.textoUH.Text = "UH: ";
            // 
            // contUH
            // 
            this.contUH.AutoSize = true;
            this.contUH.Font = new System.Drawing.Font("Arial", 10F);
            this.contUH.Location = new System.Drawing.Point(46, 610);
            this.contUH.Name = "contUH";
            this.contUH.Size = new System.Drawing.Size(0, 16);
            this.contUH.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1354, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotarDerechaToolStripMenuItem,
            this.rotarIzquierdaToolStripMenuItem});
            this.herramientasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(98, 21);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // rotarDerechaToolStripMenuItem
            // 
            this.rotarDerechaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.rotarDerechaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rotarDerechaToolStripMenuItem.Name = "rotarDerechaToolStripMenuItem";
            this.rotarDerechaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rotarDerechaToolStripMenuItem.Text = "Rotar Derecha";
            this.rotarDerechaToolStripMenuItem.Click += new System.EventHandler(this.rotarDerechaToolStripMenuItem_Click_1);
            // 
            // rotarIzquierdaToolStripMenuItem
            // 
            this.rotarIzquierdaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.rotarIzquierdaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rotarIzquierdaToolStripMenuItem.Name = "rotarIzquierdaToolStripMenuItem";
            this.rotarIzquierdaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rotarIzquierdaToolStripMenuItem.Text = "Rotar Izquierda";
            this.rotarIzquierdaToolStripMenuItem.Click += new System.EventHandler(this.rotarIzquierdaToolStripMenuItem_Click_1);
            // 
            // seleccionUmbralizacion
            // 
            this.seleccionUmbralizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seleccionUmbralizacion.FormattingEnabled = true;
            this.seleccionUmbralizacion.Items.AddRange(new object[] {
            "Agua",
            "Aire",
            "Grasa",
            "Hueso compacto",
            "Hueso esponjoso",
            "Organos",
            "Pulmones",
            "Sangre",
            "Personalizada"});
            this.seleccionUmbralizacion.Location = new System.Drawing.Point(1086, 67);
            this.seleccionUmbralizacion.Name = "seleccionUmbralizacion";
            this.seleccionUmbralizacion.Size = new System.Drawing.Size(183, 22);
            this.seleccionUmbralizacion.TabIndex = 8;
            this.seleccionUmbralizacion.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // texto_umbralizacion
            // 
            this.texto_umbralizacion.AutoSize = true;
            this.texto_umbralizacion.Location = new System.Drawing.Point(1086, 43);
            this.texto_umbralizacion.Name = "texto_umbralizacion";
            this.texto_umbralizacion.Size = new System.Drawing.Size(117, 14);
            this.texto_umbralizacion.TabIndex = 9;
            this.texto_umbralizacion.Text = "Umbralización de tejido";
            // 
            // textoPromedio
            // 
            this.textoPromedio.AutoSize = true;
            this.textoPromedio.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoPromedio.Location = new System.Drawing.Point(77, 612);
            this.textoPromedio.Name = "textoPromedio";
            this.textoPromedio.Size = new System.Drawing.Size(76, 16);
            this.textoPromedio.TabIndex = 11;
            this.textoPromedio.Text = "Promedio: ";
            // 
            // contPromedio
            // 
            this.contPromedio.AutoSize = true;
            this.contPromedio.Location = new System.Drawing.Point(153, 614);
            this.contPromedio.Name = "contPromedio";
            this.contPromedio.Size = new System.Drawing.Size(0, 14);
            this.contPromedio.TabIndex = 12;
            // 
            // centroUmbralizacion
            // 
            this.centroUmbralizacion.Location = new System.Drawing.Point(1113, 96);
            this.centroUmbralizacion.Name = "centroUmbralizacion";
            this.centroUmbralizacion.Size = new System.Drawing.Size(30, 20);
            this.centroUmbralizacion.TabIndex = 13;
            this.centroUmbralizacion.Visible = false;
            this.centroUmbralizacion.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ventanaUmbralizacion
            // 
            this.ventanaUmbralizacion.Location = new System.Drawing.Point(1182, 96);
            this.ventanaUmbralizacion.Name = "ventanaUmbralizacion";
            this.ventanaUmbralizacion.Size = new System.Drawing.Size(30, 20);
            this.ventanaUmbralizacion.TabIndex = 14;
            this.ventanaUmbralizacion.Visible = false;
            // 
            // textoUHumbralizacion
            // 
            this.textoUHumbralizacion.AutoSize = true;
            this.textoUHumbralizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoUHumbralizacion.Location = new System.Drawing.Point(1083, 99);
            this.textoUHumbralizacion.Name = "textoUHumbralizacion";
            this.textoUHumbralizacion.Size = new System.Drawing.Size(29, 13);
            this.textoUHumbralizacion.TabIndex = 15;
            this.textoUHumbralizacion.Text = "UH: ";
            this.textoUHumbralizacion.Visible = false;
            // 
            // textoMasmenos
            // 
            this.textoMasmenos.AutoSize = true;
            this.textoMasmenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoMasmenos.Location = new System.Drawing.Point(1149, 96);
            this.textoMasmenos.Name = "textoMasmenos";
            this.textoMasmenos.Size = new System.Drawing.Size(27, 15);
            this.textoMasmenos.TabIndex = 16;
            this.textoMasmenos.Text = "+/- :";
            this.textoMasmenos.Visible = false;
            this.textoMasmenos.Click += new System.EventHandler(this.label7_Click);
            // 
            // botonUmbralizacion
            // 
            this.botonUmbralizacion.BackColor = System.Drawing.Color.DarkCyan;
            this.botonUmbralizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonUmbralizacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.botonUmbralizacion.Location = new System.Drawing.Point(1218, 96);
            this.botonUmbralizacion.Name = "botonUmbralizacion";
            this.botonUmbralizacion.Size = new System.Drawing.Size(50, 25);
            this.botonUmbralizacion.TabIndex = 17;
            this.botonUmbralizacion.Text = "Aplicar";
            this.botonUmbralizacion.UseVisualStyleBackColor = false;
            this.botonUmbralizacion.Visible = false;
            this.botonUmbralizacion.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // botonRegla
            // 
            this.botonRegla.BackColor = System.Drawing.Color.DarkCyan;
            this.botonRegla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRegla.Location = new System.Drawing.Point(1086, 138);
            this.botonRegla.Name = "botonRegla";
            this.botonRegla.Size = new System.Drawing.Size(75, 25);
            this.botonRegla.TabIndex = 18;
            this.botonRegla.Text = "Regla";
            this.botonRegla.UseVisualStyleBackColor = false;
            this.botonRegla.Click += new System.EventHandler(this.button4_Click);
            // 
            // textoDistancia
            // 
            this.textoDistancia.AutoSize = true;
            this.textoDistancia.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoDistancia.Location = new System.Drawing.Point(178, 612);
            this.textoDistancia.Name = "textoDistancia";
            this.textoDistancia.Size = new System.Drawing.Size(74, 16);
            this.textoDistancia.TabIndex = 19;
            this.textoDistancia.Text = "Distancia: ";
            // 
            // contMedida
            // 
            this.contMedida.AutoSize = true;
            this.contMedida.Location = new System.Drawing.Point(252, 616);
            this.contMedida.Name = "contMedida";
            this.contMedida.Size = new System.Drawing.Size(0, 14);
            this.contMedida.TabIndex = 20;
            // 
            // textoMm
            // 
            this.textoMm.AutoSize = true;
            this.textoMm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoMm.Location = new System.Drawing.Point(275, 612);
            this.textoMm.Name = "textoMm";
            this.textoMm.Size = new System.Drawing.Size(30, 16);
            this.textoMm.TabIndex = 21;
            this.textoMm.Text = "mm";
            this.textoMm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // centroVentana
            // 
            this.centroVentana.Location = new System.Drawing.Point(1097, 419);
            this.centroVentana.Name = "centroVentana";
            this.centroVentana.Size = new System.Drawing.Size(45, 20);
            this.centroVentana.TabIndex = 22;
            // 
            // ventanaVentana
            // 
            this.ventanaVentana.Location = new System.Drawing.Point(1178, 419);
            this.ventanaVentana.Name = "ventanaVentana";
            this.ventanaVentana.Size = new System.Drawing.Size(34, 20);
            this.ventanaVentana.TabIndex = 23;
            // 
            // botonVentana
            // 
            this.botonVentana.Location = new System.Drawing.Point(1139, 459);
            this.botonVentana.Name = "botonVentana";
            this.botonVentana.Size = new System.Drawing.Size(63, 32);
            this.botonVentana.TabIndex = 24;
            this.botonVentana.Text = "button5";
            this.botonVentana.UseVisualStyleBackColor = true;
            this.botonVentana.Click += new System.EventHandler(this.button5_Click);
            // 
            // barraZoom
            // 
            this.barraZoom.Location = new System.Drawing.Point(1089, 190);
            this.barraZoom.Maximum = 5;
            this.barraZoom.Minimum = 1;
            this.barraZoom.Name = "barraZoom";
            this.barraZoom.Size = new System.Drawing.Size(167, 45);
            this.barraZoom.TabIndex = 26;
            this.barraZoom.Value = 1;
            this.barraZoom.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // botonKmeans
            // 
            this.botonKmeans.Location = new System.Drawing.Point(1097, 530);
            this.botonKmeans.Name = "botonKmeans";
            this.botonKmeans.Size = new System.Drawing.Size(75, 25);
            this.botonKmeans.TabIndex = 27;
            this.botonKmeans.Text = "K-means";
            this.botonKmeans.UseVisualStyleBackColor = true;
            this.botonKmeans.Click += new System.EventHandler(this.button6_Click);
            // 
            // botonZoom
            // 
            this.botonZoom.Location = new System.Drawing.Point(1178, 138);
            this.botonZoom.Name = "botonZoom";
            this.botonZoom.Size = new System.Drawing.Size(91, 25);
            this.botonZoom.TabIndex = 28;
            this.botonZoom.Text = "Activar zoom";
            this.botonZoom.UseVisualStyleBackColor = true;
            this.botonZoom.Click += new System.EventHandler(this.Bzoom_Click);
            // 
            // boton3D
            // 
            this.boton3D.Location = new System.Drawing.Point(1114, 599);
            this.boton3D.Name = "boton3D";
            this.boton3D.Size = new System.Drawing.Size(123, 45);
            this.boton3D.TabIndex = 29;
            this.boton3D.Text = "reconstruccion";
            this.boton3D.UseVisualStyleBackColor = true;
            this.boton3D.Click += new System.EventHandler(this.button7_Click);
            // 
            // barraHerramientas
            // 
            this.barraHerramientas.AllowDrop = true;
            this.barraHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.barraHerramientas.Location = new System.Drawing.Point(0, 25);
            this.barraHerramientas.Name = "barraHerramientas";
            this.barraHerramientas.Size = new System.Drawing.Size(1354, 25);
            this.barraHerramientas.TabIndex = 30;
            this.barraHerramientas.Text = "toolStrip1";
            this.barraHerramientas.Visible = false;
            this.barraHerramientas.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked_1);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // visibleZoom
            // 
            this.visibleZoom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.visibleZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.visibleZoom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.visibleZoom.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.visibleZoom.Location = new System.Drawing.Point(1097, 244);
            this.visibleZoom.Name = "visibleZoom";
            this.visibleZoom.Size = new System.Drawing.Size(159, 149);
            this.visibleZoom.TabIndex = 25;
            this.visibleZoom.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(547, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 512);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // botonDerecha
            // 
            this.botonDerecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.botonDerecha.BackgroundImage = global::SAARTAC.Properties.Resources._905535_32;
            this.botonDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonDerecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.botonDerecha.Location = new System.Drawing.Point(488, 608);
            this.botonDerecha.Name = "botonDerecha";
            this.botonDerecha.Size = new System.Drawing.Size(36, 36);
            this.botonDerecha.TabIndex = 5;
            this.botonDerecha.UseVisualStyleBackColor = false;
            this.botonDerecha.Click += new System.EventHandler(this.button3_Click);
            // 
            // botonIzquierda
            // 
            this.botonIzquierda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.botonIzquierda.BackgroundImage = global::SAARTAC.Properties.Resources._905524_32;
            this.botonIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonIzquierda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.botonIzquierda.Location = new System.Drawing.Point(446, 608);
            this.botonIzquierda.Name = "botonIzquierda";
            this.botonIzquierda.Size = new System.Drawing.Size(36, 36);
            this.botonIzquierda.TabIndex = 4;
            this.botonIzquierda.UseVisualStyleBackColor = false;
            this.botonIzquierda.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.barraHerramientas);
            this.Controls.Add(this.boton3D);
            this.Controls.Add(this.botonZoom);
            this.Controls.Add(this.botonKmeans);
            this.Controls.Add(this.barraZoom);
            this.Controls.Add(this.visibleZoom);
            this.Controls.Add(this.botonVentana);
            this.Controls.Add(this.ventanaVentana);
            this.Controls.Add(this.centroVentana);
            this.Controls.Add(this.textoMm);
            this.Controls.Add(this.contMedida);
            this.Controls.Add(this.textoDistancia);
            this.Controls.Add(this.botonRegla);
            this.Controls.Add(this.botonUmbralizacion);
            this.Controls.Add(this.textoMasmenos);
            this.Controls.Add(this.textoUHumbralizacion);
            this.Controls.Add(this.ventanaUmbralizacion);
            this.Controls.Add(this.centroUmbralizacion);
            this.Controls.Add(this.contPromedio);
            this.Controls.Add(this.textoPromedio);
            this.Controls.Add(this.texto_umbralizacion);
            this.Controls.Add(this.seleccionUmbralizacion);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.botonDerecha);
            this.Controls.Add(this.botonIzquierda);
            this.Controls.Add(this.contUH);
            this.Controls.Add(this.textoUH);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SAARTAC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraZoom)).EndInit();
            this.barraHerramientas.ResumeLayout(false);
            this.barraHerramientas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visibleZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label textoUH;
        private System.Windows.Forms.Label contUH;
        private System.Windows.Forms.Button botonIzquierda;
        private System.Windows.Forms.Button botonDerecha;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox seleccionUmbralizacion;
        private System.Windows.Forms.Label texto_umbralizacion;
        private System.Windows.Forms.Label textoPromedio;
        private System.Windows.Forms.Label contPromedio;
        private System.Windows.Forms.TextBox centroUmbralizacion;
        private System.Windows.Forms.TextBox ventanaUmbralizacion;
        private System.Windows.Forms.Label textoUHumbralizacion;
        private System.Windows.Forms.Label textoMasmenos;
        private System.Windows.Forms.Button botonUmbralizacion;
        private System.Windows.Forms.Button botonRegla;
        private System.Windows.Forms.Label textoDistancia;
        private System.Windows.Forms.Label contMedida;
        private System.Windows.Forms.Label textoMm;
        private System.Windows.Forms.TextBox centroVentana;
        private System.Windows.Forms.TextBox ventanaVentana;
        private System.Windows.Forms.Button botonVentana;
        private System.Windows.Forms.PictureBox visibleZoom;
        private System.Windows.Forms.TrackBar barraZoom;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotarDerechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotarIzquierdaToolStripMenuItem;
        private System.Windows.Forms.Button botonKmeans;
        private System.Windows.Forms.Button botonZoom;
        private System.Windows.Forms.Button boton3D;
        private System.Windows.Forms.ToolStrip barraHerramientas;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
    }
}

