namespace TP4
{
    partial class Tp4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_llegadas = new System.Windows.Forms.GroupBox();
            this.txt_llegadas_lambda = new System.Windows.Forms.TextBox();
            this.lbl_llegadas_lambda = new System.Windows.Forms.Label();
            this.txt_recepcion_a = new System.Windows.Forms.TextBox();
            this.lbl_recepcion_a = new System.Windows.Forms.Label();
            this.gb_recepcion = new System.Windows.Forms.GroupBox();
            this.txt_recepcion_b = new System.Windows.Forms.TextBox();
            this.lbl_recepcion_b = new System.Windows.Forms.Label();
            this.gb_balanza = new System.Windows.Forms.GroupBox();
            this.txt_balanza_b = new System.Windows.Forms.TextBox();
            this.lbl_balanza_b = new System.Windows.Forms.Label();
            this.txt_balanza_a = new System.Windows.Forms.TextBox();
            this.lbl_balanza_a = new System.Windows.Forms.Label();
            this.gb_darsenas = new System.Windows.Forms.GroupBox();
            this.txt_darsenas_b = new System.Windows.Forms.TextBox();
            this.lbl_darsenas_b = new System.Windows.Forms.Label();
            this.txt_darsenas_a = new System.Windows.Forms.TextBox();
            this.lbl_darsenas_a = new System.Windows.Forms.Label();
            this.gb_recalibracion = new System.Windows.Forms.GroupBox();
            this.txt_recalibracion_varianza = new System.Windows.Forms.TextBox();
            this.lbl_recalibracion_varianza = new System.Windows.Forms.Label();
            this.txt_recalibracion_media = new System.Windows.Forms.TextBox();
            this.lbl_recalibracion_media = new System.Windows.Forms.Label();
            this.gb_estrategias = new System.Windows.Forms.GroupBox();
            this.txt_permanencia_b = new System.Windows.Forms.TextBox();
            this.txt_permanencia_a = new System.Windows.Forms.TextBox();
            this.lbl_permanencia = new System.Windows.Forms.Label();
            this.txt_no_atendidos_b = new System.Windows.Forms.TextBox();
            this.txt_no_atendidos_a = new System.Windows.Forms.TextBox();
            this.lbl_no_atendidos = new System.Windows.Forms.Label();
            this.txt_atendidos_b = new System.Windows.Forms.TextBox();
            this.txt_atendidos_a = new System.Windows.Forms.TextBox();
            this.lbl_atendidos = new System.Windows.Forms.Label();
            this.rb_estrategia_b = new System.Windows.Forms.RadioButton();
            this.rb_estrategia_a = new System.Windows.Forms.RadioButton();
            this.lk_estrategia_b = new System.Windows.Forms.LinkLabel();
            this.lk_estrategia_a = new System.Windows.Forms.LinkLabel();
            this.gb_cantidades = new System.Windows.Forms.GroupBox();
            this.txt_hasta = new System.Windows.Forms.TextBox();
            this.txt_desde = new System.Windows.Forms.TextBox();
            this.txt_dias = new System.Windows.Forms.TextBox();
            this.lbl_dias = new System.Windows.Forms.Label();
            this.lbl_hasta = new System.Windows.Forms.Label();
            this.lbl_desde = new System.Windows.Forms.Label();
            this.btn_simular = new System.Windows.Forms.Button();
            this.btn_comparar = new System.Windows.Forms.Button();
            this.dg_simulaciones = new System.Windows.Forms.DataGridView();
            this.reloj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxima_llegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cola_recepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_recepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_fin_recepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cola_balanza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_balanza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_fin_balanza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cola_darsenas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_darsena_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_fin_darsena_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atendidos_darsena_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_darsena_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_fin_darsena_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atendidos_darsena_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_atendidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sin_atender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permanencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_detener = new System.Windows.Forms.Button();
            this.gb_llegadas.SuspendLayout();
            this.gb_recepcion.SuspendLayout();
            this.gb_balanza.SuspendLayout();
            this.gb_darsenas.SuspendLayout();
            this.gb_recalibracion.SuspendLayout();
            this.gb_estrategias.SuspendLayout();
            this.gb_cantidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_simulaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_llegadas
            // 
            this.gb_llegadas.Controls.Add(this.txt_llegadas_lambda);
            this.gb_llegadas.Controls.Add(this.lbl_llegadas_lambda);
            this.gb_llegadas.Location = new System.Drawing.Point(12, 132);
            this.gb_llegadas.Name = "gb_llegadas";
            this.gb_llegadas.Size = new System.Drawing.Size(125, 57);
            this.gb_llegadas.TabIndex = 0;
            this.gb_llegadas.TabStop = false;
            this.gb_llegadas.Text = "Llegadas (A):";
            // 
            // txt_llegadas_lambda
            // 
            this.txt_llegadas_lambda.Location = new System.Drawing.Point(71, 22);
            this.txt_llegadas_lambda.Name = "txt_llegadas_lambda";
            this.txt_llegadas_lambda.Size = new System.Drawing.Size(37, 20);
            this.txt_llegadas_lambda.TabIndex = 1;
            this.txt_llegadas_lambda.Text = "0.067";
            // 
            // lbl_llegadas_lambda
            // 
            this.lbl_llegadas_lambda.AutoSize = true;
            this.lbl_llegadas_lambda.Location = new System.Drawing.Point(17, 25);
            this.lbl_llegadas_lambda.Name = "lbl_llegadas_lambda";
            this.lbl_llegadas_lambda.Size = new System.Drawing.Size(48, 13);
            this.lbl_llegadas_lambda.TabIndex = 0;
            this.lbl_llegadas_lambda.Text = "Lambda:";
            // 
            // txt_recepcion_a
            // 
            this.txt_recepcion_a.Location = new System.Drawing.Point(71, 22);
            this.txt_recepcion_a.Name = "txt_recepcion_a";
            this.txt_recepcion_a.Size = new System.Drawing.Size(37, 20);
            this.txt_recepcion_a.TabIndex = 1;
            this.txt_recepcion_a.Text = "3";
            // 
            // lbl_recepcion_a
            // 
            this.lbl_recepcion_a.AutoSize = true;
            this.lbl_recepcion_a.Location = new System.Drawing.Point(17, 25);
            this.lbl_recepcion_a.Name = "lbl_recepcion_a";
            this.lbl_recepcion_a.Size = new System.Drawing.Size(17, 13);
            this.lbl_recepcion_a.TabIndex = 0;
            this.lbl_recepcion_a.Text = "A:";
            // 
            // gb_recepcion
            // 
            this.gb_recepcion.Controls.Add(this.txt_recepcion_b);
            this.gb_recepcion.Controls.Add(this.lbl_recepcion_b);
            this.gb_recepcion.Controls.Add(this.txt_recepcion_a);
            this.gb_recepcion.Controls.Add(this.lbl_recepcion_a);
            this.gb_recepcion.Location = new System.Drawing.Point(12, 195);
            this.gb_recepcion.Name = "gb_recepcion";
            this.gb_recepcion.Size = new System.Drawing.Size(125, 85);
            this.gb_recepcion.TabIndex = 2;
            this.gb_recepcion.TabStop = false;
            this.gb_recepcion.Text = "Recepción:";
            // 
            // txt_recepcion_b
            // 
            this.txt_recepcion_b.Location = new System.Drawing.Point(71, 48);
            this.txt_recepcion_b.Name = "txt_recepcion_b";
            this.txt_recepcion_b.Size = new System.Drawing.Size(37, 20);
            this.txt_recepcion_b.TabIndex = 3;
            this.txt_recepcion_b.Text = "7";
            // 
            // lbl_recepcion_b
            // 
            this.lbl_recepcion_b.AutoSize = true;
            this.lbl_recepcion_b.Location = new System.Drawing.Point(17, 51);
            this.lbl_recepcion_b.Name = "lbl_recepcion_b";
            this.lbl_recepcion_b.Size = new System.Drawing.Size(17, 13);
            this.lbl_recepcion_b.TabIndex = 2;
            this.lbl_recepcion_b.Text = "B:";
            // 
            // gb_balanza
            // 
            this.gb_balanza.Controls.Add(this.txt_balanza_b);
            this.gb_balanza.Controls.Add(this.lbl_balanza_b);
            this.gb_balanza.Controls.Add(this.txt_balanza_a);
            this.gb_balanza.Controls.Add(this.lbl_balanza_a);
            this.gb_balanza.Location = new System.Drawing.Point(12, 286);
            this.gb_balanza.Name = "gb_balanza";
            this.gb_balanza.Size = new System.Drawing.Size(125, 85);
            this.gb_balanza.TabIndex = 4;
            this.gb_balanza.TabStop = false;
            this.gb_balanza.Text = "Balanza:";
            // 
            // txt_balanza_b
            // 
            this.txt_balanza_b.Location = new System.Drawing.Point(71, 48);
            this.txt_balanza_b.Name = "txt_balanza_b";
            this.txt_balanza_b.Size = new System.Drawing.Size(37, 20);
            this.txt_balanza_b.TabIndex = 3;
            this.txt_balanza_b.Text = "7";
            // 
            // lbl_balanza_b
            // 
            this.lbl_balanza_b.AutoSize = true;
            this.lbl_balanza_b.Location = new System.Drawing.Point(17, 51);
            this.lbl_balanza_b.Name = "lbl_balanza_b";
            this.lbl_balanza_b.Size = new System.Drawing.Size(17, 13);
            this.lbl_balanza_b.TabIndex = 2;
            this.lbl_balanza_b.Text = "B:";
            // 
            // txt_balanza_a
            // 
            this.txt_balanza_a.Location = new System.Drawing.Point(71, 22);
            this.txt_balanza_a.Name = "txt_balanza_a";
            this.txt_balanza_a.Size = new System.Drawing.Size(37, 20);
            this.txt_balanza_a.TabIndex = 1;
            this.txt_balanza_a.Text = "5";
            // 
            // lbl_balanza_a
            // 
            this.lbl_balanza_a.AutoSize = true;
            this.lbl_balanza_a.Location = new System.Drawing.Point(17, 25);
            this.lbl_balanza_a.Name = "lbl_balanza_a";
            this.lbl_balanza_a.Size = new System.Drawing.Size(17, 13);
            this.lbl_balanza_a.TabIndex = 0;
            this.lbl_balanza_a.Text = "A:";
            // 
            // gb_darsenas
            // 
            this.gb_darsenas.Controls.Add(this.txt_darsenas_b);
            this.gb_darsenas.Controls.Add(this.lbl_darsenas_b);
            this.gb_darsenas.Controls.Add(this.txt_darsenas_a);
            this.gb_darsenas.Controls.Add(this.lbl_darsenas_a);
            this.gb_darsenas.Location = new System.Drawing.Point(12, 377);
            this.gb_darsenas.Name = "gb_darsenas";
            this.gb_darsenas.Size = new System.Drawing.Size(125, 85);
            this.gb_darsenas.TabIndex = 5;
            this.gb_darsenas.TabStop = false;
            this.gb_darsenas.Text = "Dársenas:";
            // 
            // txt_darsenas_b
            // 
            this.txt_darsenas_b.Location = new System.Drawing.Point(71, 48);
            this.txt_darsenas_b.Name = "txt_darsenas_b";
            this.txt_darsenas_b.Size = new System.Drawing.Size(37, 20);
            this.txt_darsenas_b.TabIndex = 3;
            this.txt_darsenas_b.Text = "25";
            // 
            // lbl_darsenas_b
            // 
            this.lbl_darsenas_b.AutoSize = true;
            this.lbl_darsenas_b.Location = new System.Drawing.Point(17, 51);
            this.lbl_darsenas_b.Name = "lbl_darsenas_b";
            this.lbl_darsenas_b.Size = new System.Drawing.Size(17, 13);
            this.lbl_darsenas_b.TabIndex = 2;
            this.lbl_darsenas_b.Text = "B:";
            // 
            // txt_darsenas_a
            // 
            this.txt_darsenas_a.Location = new System.Drawing.Point(71, 22);
            this.txt_darsenas_a.Name = "txt_darsenas_a";
            this.txt_darsenas_a.Size = new System.Drawing.Size(37, 20);
            this.txt_darsenas_a.TabIndex = 1;
            this.txt_darsenas_a.Text = "20";
            // 
            // lbl_darsenas_a
            // 
            this.lbl_darsenas_a.AutoSize = true;
            this.lbl_darsenas_a.Location = new System.Drawing.Point(17, 25);
            this.lbl_darsenas_a.Name = "lbl_darsenas_a";
            this.lbl_darsenas_a.Size = new System.Drawing.Size(17, 13);
            this.lbl_darsenas_a.TabIndex = 0;
            this.lbl_darsenas_a.Text = "A:";
            // 
            // gb_recalibracion
            // 
            this.gb_recalibracion.Controls.Add(this.txt_recalibracion_varianza);
            this.gb_recalibracion.Controls.Add(this.lbl_recalibracion_varianza);
            this.gb_recalibracion.Controls.Add(this.txt_recalibracion_media);
            this.gb_recalibracion.Controls.Add(this.lbl_recalibracion_media);
            this.gb_recalibracion.Location = new System.Drawing.Point(12, 468);
            this.gb_recalibracion.Name = "gb_recalibracion";
            this.gb_recalibracion.Size = new System.Drawing.Size(125, 85);
            this.gb_recalibracion.TabIndex = 6;
            this.gb_recalibracion.TabStop = false;
            this.gb_recalibracion.Text = "Recalibración:";
            // 
            // txt_recalibracion_varianza
            // 
            this.txt_recalibracion_varianza.Location = new System.Drawing.Point(71, 48);
            this.txt_recalibracion_varianza.Name = "txt_recalibracion_varianza";
            this.txt_recalibracion_varianza.Size = new System.Drawing.Size(37, 20);
            this.txt_recalibracion_varianza.TabIndex = 3;
            this.txt_recalibracion_varianza.Text = "7.5";
            // 
            // lbl_recalibracion_varianza
            // 
            this.lbl_recalibracion_varianza.AutoSize = true;
            this.lbl_recalibracion_varianza.Location = new System.Drawing.Point(17, 51);
            this.lbl_recalibracion_varianza.Name = "lbl_recalibracion_varianza";
            this.lbl_recalibracion_varianza.Size = new System.Drawing.Size(51, 13);
            this.lbl_recalibracion_varianza.TabIndex = 2;
            this.lbl_recalibracion_varianza.Text = "Varianza:";
            // 
            // txt_recalibracion_media
            // 
            this.txt_recalibracion_media.Location = new System.Drawing.Point(71, 22);
            this.txt_recalibracion_media.Name = "txt_recalibracion_media";
            this.txt_recalibracion_media.Size = new System.Drawing.Size(37, 20);
            this.txt_recalibracion_media.TabIndex = 1;
            this.txt_recalibracion_media.Text = "10";
            // 
            // lbl_recalibracion_media
            // 
            this.lbl_recalibracion_media.AutoSize = true;
            this.lbl_recalibracion_media.Location = new System.Drawing.Point(17, 25);
            this.lbl_recalibracion_media.Name = "lbl_recalibracion_media";
            this.lbl_recalibracion_media.Size = new System.Drawing.Size(39, 13);
            this.lbl_recalibracion_media.TabIndex = 0;
            this.lbl_recalibracion_media.Text = "Media:";
            // 
            // gb_estrategias
            // 
            this.gb_estrategias.Controls.Add(this.txt_permanencia_b);
            this.gb_estrategias.Controls.Add(this.txt_permanencia_a);
            this.gb_estrategias.Controls.Add(this.lbl_permanencia);
            this.gb_estrategias.Controls.Add(this.txt_no_atendidos_b);
            this.gb_estrategias.Controls.Add(this.txt_no_atendidos_a);
            this.gb_estrategias.Controls.Add(this.lbl_no_atendidos);
            this.gb_estrategias.Controls.Add(this.txt_atendidos_b);
            this.gb_estrategias.Controls.Add(this.txt_atendidos_a);
            this.gb_estrategias.Controls.Add(this.lbl_atendidos);
            this.gb_estrategias.Controls.Add(this.rb_estrategia_b);
            this.gb_estrategias.Controls.Add(this.rb_estrategia_a);
            this.gb_estrategias.Controls.Add(this.lk_estrategia_b);
            this.gb_estrategias.Controls.Add(this.lk_estrategia_a);
            this.gb_estrategias.Location = new System.Drawing.Point(197, 12);
            this.gb_estrategias.Name = "gb_estrategias";
            this.gb_estrategias.Size = new System.Drawing.Size(393, 114);
            this.gb_estrategias.TabIndex = 7;
            this.gb_estrategias.TabStop = false;
            this.gb_estrategias.Text = "Estrategias:";
            // 
            // txt_permanencia_b
            // 
            this.txt_permanencia_b.Enabled = false;
            this.txt_permanencia_b.Location = new System.Drawing.Point(312, 77);
            this.txt_permanencia_b.Name = "txt_permanencia_b";
            this.txt_permanencia_b.Size = new System.Drawing.Size(64, 20);
            this.txt_permanencia_b.TabIndex = 12;
            // 
            // txt_permanencia_a
            // 
            this.txt_permanencia_a.Enabled = false;
            this.txt_permanencia_a.Location = new System.Drawing.Point(312, 52);
            this.txt_permanencia_a.Name = "txt_permanencia_a";
            this.txt_permanencia_a.Size = new System.Drawing.Size(64, 20);
            this.txt_permanencia_a.TabIndex = 11;
            // 
            // lbl_permanencia
            // 
            this.lbl_permanencia.Location = new System.Drawing.Point(303, 16);
            this.lbl_permanencia.Name = "lbl_permanencia";
            this.lbl_permanencia.Size = new System.Drawing.Size(81, 33);
            this.lbl_permanencia.TabIndex = 10;
            this.lbl_permanencia.Text = "Permanencia promedio:";
            this.lbl_permanencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_no_atendidos_b
            // 
            this.txt_no_atendidos_b.Enabled = false;
            this.txt_no_atendidos_b.Location = new System.Drawing.Point(218, 77);
            this.txt_no_atendidos_b.Name = "txt_no_atendidos_b";
            this.txt_no_atendidos_b.Size = new System.Drawing.Size(64, 20);
            this.txt_no_atendidos_b.TabIndex = 9;
            // 
            // txt_no_atendidos_a
            // 
            this.txt_no_atendidos_a.Enabled = false;
            this.txt_no_atendidos_a.Location = new System.Drawing.Point(218, 52);
            this.txt_no_atendidos_a.Name = "txt_no_atendidos_a";
            this.txt_no_atendidos_a.Size = new System.Drawing.Size(64, 20);
            this.txt_no_atendidos_a.TabIndex = 8;
            // 
            // lbl_no_atendidos
            // 
            this.lbl_no_atendidos.Location = new System.Drawing.Point(215, 16);
            this.lbl_no_atendidos.Name = "lbl_no_atendidos";
            this.lbl_no_atendidos.Size = new System.Drawing.Size(74, 33);
            this.lbl_no_atendidos.TabIndex = 7;
            this.lbl_no_atendidos.Text = "Camiones no atendidos:";
            this.lbl_no_atendidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_atendidos_b
            // 
            this.txt_atendidos_b.Enabled = false;
            this.txt_atendidos_b.Location = new System.Drawing.Point(122, 77);
            this.txt_atendidos_b.Name = "txt_atendidos_b";
            this.txt_atendidos_b.Size = new System.Drawing.Size(64, 20);
            this.txt_atendidos_b.TabIndex = 6;
            // 
            // txt_atendidos_a
            // 
            this.txt_atendidos_a.Enabled = false;
            this.txt_atendidos_a.Location = new System.Drawing.Point(122, 52);
            this.txt_atendidos_a.Name = "txt_atendidos_a";
            this.txt_atendidos_a.Size = new System.Drawing.Size(64, 20);
            this.txt_atendidos_a.TabIndex = 5;
            // 
            // lbl_atendidos
            // 
            this.lbl_atendidos.Location = new System.Drawing.Point(119, 16);
            this.lbl_atendidos.Name = "lbl_atendidos";
            this.lbl_atendidos.Size = new System.Drawing.Size(67, 33);
            this.lbl_atendidos.TabIndex = 4;
            this.lbl_atendidos.Text = "Camiones atendidos:";
            this.lbl_atendidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rb_estrategia_b
            // 
            this.rb_estrategia_b.AutoSize = true;
            this.rb_estrategia_b.Location = new System.Drawing.Point(25, 79);
            this.rb_estrategia_b.Name = "rb_estrategia_b";
            this.rb_estrategia_b.Size = new System.Drawing.Size(14, 13);
            this.rb_estrategia_b.TabIndex = 3;
            this.rb_estrategia_b.TabStop = true;
            this.rb_estrategia_b.UseVisualStyleBackColor = true;
            this.rb_estrategia_b.CheckedChanged += new System.EventHandler(this.rb_estrategia_b_CheckedChanged);
            // 
            // rb_estrategia_a
            // 
            this.rb_estrategia_a.AutoSize = true;
            this.rb_estrategia_a.Location = new System.Drawing.Point(25, 55);
            this.rb_estrategia_a.Name = "rb_estrategia_a";
            this.rb_estrategia_a.Size = new System.Drawing.Size(14, 13);
            this.rb_estrategia_a.TabIndex = 2;
            this.rb_estrategia_a.TabStop = true;
            this.rb_estrategia_a.UseVisualStyleBackColor = true;
            this.rb_estrategia_a.CheckedChanged += new System.EventHandler(this.rb_estrategia_a_CheckedChanged);
            // 
            // lk_estrategia_b
            // 
            this.lk_estrategia_b.AutoSize = true;
            this.lk_estrategia_b.Location = new System.Drawing.Point(45, 79);
            this.lk_estrategia_b.Name = "lk_estrategia_b";
            this.lk_estrategia_b.Size = new System.Drawing.Size(64, 13);
            this.lk_estrategia_b.TabIndex = 1;
            this.lk_estrategia_b.TabStop = true;
            this.lk_estrategia_b.Text = "Estrategia B";
            this.lk_estrategia_b.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_estrategia_b_LinkClicked);
            // 
            // lk_estrategia_a
            // 
            this.lk_estrategia_a.AutoSize = true;
            this.lk_estrategia_a.Location = new System.Drawing.Point(45, 55);
            this.lk_estrategia_a.Name = "lk_estrategia_a";
            this.lk_estrategia_a.Size = new System.Drawing.Size(64, 13);
            this.lk_estrategia_a.TabIndex = 0;
            this.lk_estrategia_a.TabStop = true;
            this.lk_estrategia_a.Text = "Estrategia A";
            this.lk_estrategia_a.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lk_estrategia_a_LinkClicked);
            // 
            // gb_cantidades
            // 
            this.gb_cantidades.Controls.Add(this.txt_hasta);
            this.gb_cantidades.Controls.Add(this.txt_desde);
            this.gb_cantidades.Controls.Add(this.txt_dias);
            this.gb_cantidades.Controls.Add(this.lbl_dias);
            this.gb_cantidades.Controls.Add(this.lbl_hasta);
            this.gb_cantidades.Controls.Add(this.lbl_desde);
            this.gb_cantidades.Location = new System.Drawing.Point(12, 12);
            this.gb_cantidades.Name = "gb_cantidades";
            this.gb_cantidades.Size = new System.Drawing.Size(179, 114);
            this.gb_cantidades.TabIndex = 8;
            this.gb_cantidades.TabStop = false;
            this.gb_cantidades.Text = "Cantidades:";
            // 
            // txt_hasta
            // 
            this.txt_hasta.Location = new System.Drawing.Point(124, 77);
            this.txt_hasta.Name = "txt_hasta";
            this.txt_hasta.Size = new System.Drawing.Size(37, 20);
            this.txt_hasta.TabIndex = 5;
            this.txt_hasta.Text = "100";
            // 
            // txt_desde
            // 
            this.txt_desde.Location = new System.Drawing.Point(124, 52);
            this.txt_desde.Name = "txt_desde";
            this.txt_desde.Size = new System.Drawing.Size(37, 20);
            this.txt_desde.TabIndex = 4;
            this.txt_desde.Text = "1";
            // 
            // txt_dias
            // 
            this.txt_dias.Location = new System.Drawing.Point(124, 27);
            this.txt_dias.Name = "txt_dias";
            this.txt_dias.Size = new System.Drawing.Size(37, 20);
            this.txt_dias.TabIndex = 3;
            this.txt_dias.Text = "30";
            // 
            // lbl_dias
            // 
            this.lbl_dias.AutoSize = true;
            this.lbl_dias.Location = new System.Drawing.Point(21, 30);
            this.lbl_dias.Name = "lbl_dias";
            this.lbl_dias.Size = new System.Drawing.Size(33, 13);
            this.lbl_dias.TabIndex = 2;
            this.lbl_dias.Text = "Días:";
            // 
            // lbl_hasta
            // 
            this.lbl_hasta.AutoSize = true;
            this.lbl_hasta.Location = new System.Drawing.Point(21, 79);
            this.lbl_hasta.Name = "lbl_hasta";
            this.lbl_hasta.Size = new System.Drawing.Size(74, 13);
            this.lbl_hasta.TabIndex = 1;
            this.lbl_hasta.Text = "Mostrar hasta:";
            // 
            // lbl_desde
            // 
            this.lbl_desde.AutoSize = true;
            this.lbl_desde.Location = new System.Drawing.Point(21, 55);
            this.lbl_desde.Name = "lbl_desde";
            this.lbl_desde.Size = new System.Drawing.Size(77, 13);
            this.lbl_desde.TabIndex = 0;
            this.lbl_desde.Text = "Mostrar desde:";
            // 
            // btn_simular
            // 
            this.btn_simular.Enabled = false;
            this.btn_simular.Location = new System.Drawing.Point(596, 103);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(75, 23);
            this.btn_simular.TabIndex = 9;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // btn_comparar
            // 
            this.btn_comparar.Enabled = false;
            this.btn_comparar.Location = new System.Drawing.Point(677, 103);
            this.btn_comparar.Name = "btn_comparar";
            this.btn_comparar.Size = new System.Drawing.Size(75, 23);
            this.btn_comparar.TabIndex = 10;
            this.btn_comparar.Text = "Comparar";
            this.btn_comparar.UseVisualStyleBackColor = true;
            this.btn_comparar.Click += new System.EventHandler(this.btn_comparar_Click);
            // 
            // dg_simulaciones
            // 
            this.dg_simulaciones.AllowUserToAddRows = false;
            this.dg_simulaciones.AllowUserToDeleteRows = false;
            this.dg_simulaciones.AllowUserToResizeColumns = false;
            this.dg_simulaciones.AllowUserToResizeRows = false;
            this.dg_simulaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_simulaciones.CausesValidation = false;
            this.dg_simulaciones.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_simulaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_simulaciones.ColumnHeadersHeight = 41;
            this.dg_simulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_simulaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reloj,
            this.evento,
            this.proxima_llegada,
            this.cola_recepcion,
            this.estado_recepcion,
            this.proximo_fin_recepcion,
            this.cola_balanza,
            this.estado_balanza,
            this.proximo_fin_balanza,
            this.cola_darsenas,
            this.estado_darsena_1,
            this.proximo_fin_darsena_1,
            this.atendidos_darsena_1,
            this.estado_darsena_2,
            this.proximo_fin_darsena_2,
            this.atendidos_darsena_2,
            this.total_atendidos,
            this.sin_atender,
            this.permanencia});
            this.dg_simulaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dg_simulaciones.EnableHeadersVisualStyles = false;
            this.dg_simulaciones.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dg_simulaciones.Location = new System.Drawing.Point(143, 132);
            this.dg_simulaciones.Name = "dg_simulaciones";
            this.dg_simulaciones.ReadOnly = true;
            this.dg_simulaciones.RowHeadersVisible = false;
            this.dg_simulaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_simulaciones.RowTemplate.ReadOnly = true;
            this.dg_simulaciones.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_simulaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_simulaciones.ShowCellErrors = false;
            this.dg_simulaciones.ShowCellToolTips = false;
            this.dg_simulaciones.ShowEditingIcon = false;
            this.dg_simulaciones.ShowRowErrors = false;
            this.dg_simulaciones.Size = new System.Drawing.Size(735, 421);
            this.dg_simulaciones.TabIndex = 11;
            // 
            // reloj
            // 
            this.reloj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.reloj.FillWeight = 1F;
            this.reloj.Frozen = true;
            this.reloj.HeaderText = "Reloj";
            this.reloj.Name = "reloj";
            this.reloj.ReadOnly = true;
            this.reloj.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.reloj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.reloj.Width = 55;
            // 
            // evento
            // 
            this.evento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.evento.FillWeight = 1F;
            this.evento.Frozen = true;
            this.evento.HeaderText = "Evento";
            this.evento.Name = "evento";
            this.evento.ReadOnly = true;
            this.evento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.evento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.evento.Width = 80;
            // 
            // proxima_llegada
            // 
            this.proxima_llegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.proxima_llegada.FillWeight = 1F;
            this.proxima_llegada.HeaderText = "Próxima Llegada";
            this.proxima_llegada.Name = "proxima_llegada";
            this.proxima_llegada.ReadOnly = true;
            this.proxima_llegada.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.proxima_llegada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.proxima_llegada.Width = 60;
            // 
            // cola_recepcion
            // 
            this.cola_recepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cola_recepcion.FillWeight = 1F;
            this.cola_recepcion.HeaderText = "Cola Recepción";
            this.cola_recepcion.Name = "cola_recepcion";
            this.cola_recepcion.ReadOnly = true;
            this.cola_recepcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cola_recepcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cola_recepcion.Width = 70;
            // 
            // estado_recepcion
            // 
            this.estado_recepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estado_recepcion.FillWeight = 1F;
            this.estado_recepcion.HeaderText = "Estado Recepción";
            this.estado_recepcion.Name = "estado_recepcion";
            this.estado_recepcion.ReadOnly = true;
            this.estado_recepcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.estado_recepcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.estado_recepcion.Width = 140;
            // 
            // proximo_fin_recepcion
            // 
            this.proximo_fin_recepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.proximo_fin_recepcion.FillWeight = 1F;
            this.proximo_fin_recepcion.HeaderText = "Próximo Fin Recepción";
            this.proximo_fin_recepcion.Name = "proximo_fin_recepcion";
            this.proximo_fin_recepcion.ReadOnly = true;
            this.proximo_fin_recepcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.proximo_fin_recepcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.proximo_fin_recepcion.Width = 85;
            // 
            // cola_balanza
            // 
            this.cola_balanza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cola_balanza.FillWeight = 1F;
            this.cola_balanza.HeaderText = "Cola Balanza";
            this.cola_balanza.Name = "cola_balanza";
            this.cola_balanza.ReadOnly = true;
            this.cola_balanza.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cola_balanza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cola_balanza.Width = 60;
            // 
            // estado_balanza
            // 
            this.estado_balanza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estado_balanza.FillWeight = 1F;
            this.estado_balanza.HeaderText = "Estado Balanza";
            this.estado_balanza.Name = "estado_balanza";
            this.estado_balanza.ReadOnly = true;
            this.estado_balanza.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.estado_balanza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.estado_balanza.Width = 140;
            // 
            // proximo_fin_balanza
            // 
            this.proximo_fin_balanza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.proximo_fin_balanza.FillWeight = 1F;
            this.proximo_fin_balanza.HeaderText = "Próximo Fin Balanza";
            this.proximo_fin_balanza.Name = "proximo_fin_balanza";
            this.proximo_fin_balanza.ReadOnly = true;
            this.proximo_fin_balanza.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.proximo_fin_balanza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.proximo_fin_balanza.Width = 85;
            // 
            // cola_darsenas
            // 
            this.cola_darsenas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cola_darsenas.FillWeight = 1F;
            this.cola_darsenas.HeaderText = "Cola Dársenas";
            this.cola_darsenas.Name = "cola_darsenas";
            this.cola_darsenas.ReadOnly = true;
            this.cola_darsenas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cola_darsenas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cola_darsenas.Width = 70;
            // 
            // estado_darsena_1
            // 
            this.estado_darsena_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estado_darsena_1.FillWeight = 1F;
            this.estado_darsena_1.HeaderText = "Estado Dársena 1";
            this.estado_darsena_1.Name = "estado_darsena_1";
            this.estado_darsena_1.ReadOnly = true;
            this.estado_darsena_1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.estado_darsena_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.estado_darsena_1.Width = 140;
            // 
            // proximo_fin_darsena_1
            // 
            this.proximo_fin_darsena_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.proximo_fin_darsena_1.FillWeight = 1F;
            this.proximo_fin_darsena_1.HeaderText = "Próximo Fin Dársena 1";
            this.proximo_fin_darsena_1.Name = "proximo_fin_darsena_1";
            this.proximo_fin_darsena_1.ReadOnly = true;
            this.proximo_fin_darsena_1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.proximo_fin_darsena_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.proximo_fin_darsena_1.Width = 85;
            // 
            // atendidos_darsena_1
            // 
            this.atendidos_darsena_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.atendidos_darsena_1.FillWeight = 1F;
            this.atendidos_darsena_1.HeaderText = "Atendidos Dársena 1";
            this.atendidos_darsena_1.Name = "atendidos_darsena_1";
            this.atendidos_darsena_1.ReadOnly = true;
            this.atendidos_darsena_1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.atendidos_darsena_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.atendidos_darsena_1.Width = 80;
            // 
            // estado_darsena_2
            // 
            this.estado_darsena_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estado_darsena_2.FillWeight = 1F;
            this.estado_darsena_2.HeaderText = "Estado Dársena 2";
            this.estado_darsena_2.Name = "estado_darsena_2";
            this.estado_darsena_2.ReadOnly = true;
            this.estado_darsena_2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.estado_darsena_2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.estado_darsena_2.Width = 140;
            // 
            // proximo_fin_darsena_2
            // 
            this.proximo_fin_darsena_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.proximo_fin_darsena_2.FillWeight = 1F;
            this.proximo_fin_darsena_2.HeaderText = "Próximo Fin Dársena 2";
            this.proximo_fin_darsena_2.Name = "proximo_fin_darsena_2";
            this.proximo_fin_darsena_2.ReadOnly = true;
            this.proximo_fin_darsena_2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.proximo_fin_darsena_2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.proximo_fin_darsena_2.Width = 85;
            // 
            // atendidos_darsena_2
            // 
            this.atendidos_darsena_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.atendidos_darsena_2.FillWeight = 1F;
            this.atendidos_darsena_2.HeaderText = "Atendidos Dársena 2";
            this.atendidos_darsena_2.Name = "atendidos_darsena_2";
            this.atendidos_darsena_2.ReadOnly = true;
            this.atendidos_darsena_2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.atendidos_darsena_2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.atendidos_darsena_2.Width = 80;
            // 
            // total_atendidos
            // 
            this.total_atendidos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.total_atendidos.FillWeight = 1F;
            this.total_atendidos.HeaderText = "Total Atendidos";
            this.total_atendidos.Name = "total_atendidos";
            this.total_atendidos.ReadOnly = true;
            this.total_atendidos.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.total_atendidos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.total_atendidos.Width = 70;
            // 
            // sin_atender
            // 
            this.sin_atender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sin_atender.FillWeight = 1F;
            this.sin_atender.HeaderText = "Total Sin Atender";
            this.sin_atender.Name = "sin_atender";
            this.sin_atender.ReadOnly = true;
            this.sin_atender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sin_atender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sin_atender.Width = 70;
            // 
            // permanencia
            // 
            this.permanencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.permanencia.FillWeight = 1F;
            this.permanencia.HeaderText = "Permanencia Promedio";
            this.permanencia.Name = "permanencia";
            this.permanencia.ReadOnly = true;
            this.permanencia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.permanencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.permanencia.Width = 90;
            // 
            // btn_detener
            // 
            this.btn_detener.Enabled = false;
            this.btn_detener.Location = new System.Drawing.Point(758, 103);
            this.btn_detener.Name = "btn_detener";
            this.btn_detener.Size = new System.Drawing.Size(75, 23);
            this.btn_detener.TabIndex = 12;
            this.btn_detener.Text = "Detener";
            this.btn_detener.UseVisualStyleBackColor = true;
            this.btn_detener.Click += new System.EventHandler(this.btn_detener_Click);
            // 
            // Tp4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 575);
            this.Controls.Add(this.btn_detener);
            this.Controls.Add(this.dg_simulaciones);
            this.Controls.Add(this.btn_comparar);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.gb_cantidades);
            this.Controls.Add(this.gb_estrategias);
            this.Controls.Add(this.gb_recalibracion);
            this.Controls.Add(this.gb_darsenas);
            this.Controls.Add(this.gb_balanza);
            this.Controls.Add(this.gb_recepcion);
            this.Controls.Add(this.gb_llegadas);
            this.DoubleBuffered = true;
            this.Name = "Tp4";
            this.Text = "Colas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gb_llegadas.ResumeLayout(false);
            this.gb_llegadas.PerformLayout();
            this.gb_recepcion.ResumeLayout(false);
            this.gb_recepcion.PerformLayout();
            this.gb_balanza.ResumeLayout(false);
            this.gb_balanza.PerformLayout();
            this.gb_darsenas.ResumeLayout(false);
            this.gb_darsenas.PerformLayout();
            this.gb_recalibracion.ResumeLayout(false);
            this.gb_recalibracion.PerformLayout();
            this.gb_estrategias.ResumeLayout(false);
            this.gb_estrategias.PerformLayout();
            this.gb_cantidades.ResumeLayout(false);
            this.gb_cantidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_simulaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_llegadas;
        private System.Windows.Forms.TextBox txt_llegadas_lambda;
        private System.Windows.Forms.Label lbl_llegadas_lambda;
        private System.Windows.Forms.TextBox txt_recepcion_a;
        private System.Windows.Forms.Label lbl_recepcion_a;
        private System.Windows.Forms.GroupBox gb_recepcion;
        private System.Windows.Forms.TextBox txt_recepcion_b;
        private System.Windows.Forms.Label lbl_recepcion_b;
        private System.Windows.Forms.GroupBox gb_balanza;
        private System.Windows.Forms.TextBox txt_balanza_b;
        private System.Windows.Forms.Label lbl_balanza_b;
        private System.Windows.Forms.TextBox txt_balanza_a;
        private System.Windows.Forms.Label lbl_balanza_a;
        private System.Windows.Forms.GroupBox gb_darsenas;
        private System.Windows.Forms.TextBox txt_darsenas_b;
        private System.Windows.Forms.Label lbl_darsenas_b;
        private System.Windows.Forms.TextBox txt_darsenas_a;
        private System.Windows.Forms.Label lbl_darsenas_a;
        private System.Windows.Forms.GroupBox gb_recalibracion;
        private System.Windows.Forms.TextBox txt_recalibracion_varianza;
        private System.Windows.Forms.Label lbl_recalibracion_varianza;
        private System.Windows.Forms.TextBox txt_recalibracion_media;
        private System.Windows.Forms.Label lbl_recalibracion_media;
        private System.Windows.Forms.GroupBox gb_estrategias;
        private System.Windows.Forms.TextBox txt_atendidos_a;
        private System.Windows.Forms.Label lbl_atendidos;
        private System.Windows.Forms.RadioButton rb_estrategia_b;
        private System.Windows.Forms.RadioButton rb_estrategia_a;
        private System.Windows.Forms.LinkLabel lk_estrategia_b;
        private System.Windows.Forms.LinkLabel lk_estrategia_a;
        private System.Windows.Forms.TextBox txt_permanencia_b;
        private System.Windows.Forms.TextBox txt_permanencia_a;
        private System.Windows.Forms.Label lbl_permanencia;
        private System.Windows.Forms.TextBox txt_no_atendidos_b;
        private System.Windows.Forms.TextBox txt_no_atendidos_a;
        private System.Windows.Forms.Label lbl_no_atendidos;
        private System.Windows.Forms.TextBox txt_atendidos_b;
        private System.Windows.Forms.GroupBox gb_cantidades;
        private System.Windows.Forms.TextBox txt_hasta;
        private System.Windows.Forms.TextBox txt_desde;
        private System.Windows.Forms.TextBox txt_dias;
        private System.Windows.Forms.Label lbl_dias;
        private System.Windows.Forms.Label lbl_hasta;
        private System.Windows.Forms.Label lbl_desde;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.Button btn_comparar;
        private System.Windows.Forms.DataGridView dg_simulaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn reloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn proxima_llegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cola_recepcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_recepcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximo_fin_recepcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cola_balanza;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_balanza;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximo_fin_balanza;
        private System.Windows.Forms.DataGridViewTextBoxColumn cola_darsenas;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_darsena_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximo_fin_darsena_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn atendidos_darsena_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_darsena_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximo_fin_darsena_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn atendidos_darsena_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_atendidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn sin_atender;
        private System.Windows.Forms.DataGridViewTextBoxColumn permanencia;
        private System.Windows.Forms.Button btn_detener;
    }
}

