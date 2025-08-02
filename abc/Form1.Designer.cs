// Form1.Designer.cs dosyasının İÇİNDE olması gerekenler:
// (namespace abc { partial class Form1 { ... private void InitializeComponent() { ... BURADAN İTİBAREN ... } ... private System.Windows.Forms.TextBox txtCS; ... VB. } } )

// İDEAL InitializeComponent() İÇERİĞİ (KONTROL ET VE GÜNCELLE)
namespace abc
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelCS = new System.Windows.Forms.Label();
            this.txtCS = new System.Windows.Forms.TextBox();
            this.labelD = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.labelLimit = new System.Windows.Forms.Label();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.labelMaxIter = new System.Windows.Forms.Label();
            this.txtMaxIterasyon = new System.Windows.Forms.TextBox();
            this.labelAltSinir = new System.Windows.Forms.Label();
            this.txtAltSinir = new System.Windows.Forms.TextBox();
            this.labelUstSinir = new System.Windows.Forms.Label();
            this.txtUstSinir = new System.Windows.Forms.TextBox();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.btnHesaplaBit = new System.Windows.Forms.Button();
            this.labelEnIyiSonuc = new System.Windows.Forms.Label();
            this.txtEnIyiSonuc = new System.Windows.Forms.TextBox();
            this.labelEnIyiX1 = new System.Windows.Forms.Label();
            this.txtEnIyiX1 = new System.Windows.Forms.TextBox();
            this.labelEnIyiX2 = new System.Windows.Forms.Label();
            this.txtEnIyiX2 = new System.Windows.Forms.TextBox();
            this.chartYakinlama = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelAlgoritma = new System.Windows.Forms.Label();
            this.rtbAlgoritmaAciklama = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartYakinlama)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCS
            // 
            this.labelCS.AutoSize = true;
            this.labelCS.Location = new System.Drawing.Point(12, 15);
            this.labelCS.Name = "labelCS";
            this.labelCS.Size = new System.Drawing.Size(136, 16);
            this.labelCS.TabIndex = 0;
            this.labelCS.Text = "Koloni Büyüklüğü (CS):";
            // 
            // txtCS
            // 
            this.txtCS.Location = new System.Drawing.Point(160, 12);
            this.txtCS.Name = "txtCS";
            this.txtCS.Size = new System.Drawing.Size(100, 22);
            this.txtCS.TabIndex = 1;
            this.txtCS.Text = "6";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Location = new System.Drawing.Point(12, 43);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(117, 16);
            this.labelD.TabIndex = 2;
            this.labelD.Text = "Problem Boyutu (D):";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(160, 40);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(100, 22);
            this.txtD.TabIndex = 3;
            this.txtD.Text = "2";
            // 
            // labelLimit
            // 
            this.labelLimit.AutoSize = true;
            this.labelLimit.Location = new System.Drawing.Point(12, 71);
            this.labelLimit.Name = "labelLimit";
            this.labelLimit.Size = new System.Drawing.Size(56, 16);
            this.labelLimit.TabIndex = 4;
            this.labelLimit.Text = "Limit (L):";
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(160, 68);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(100, 22);
            this.txtLimit.TabIndex = 5;
            this.txtLimit.Text = "6";
            // 
            // labelMaxIter
            // 
            this.labelMaxIter.AutoSize = true;
            this.labelMaxIter.Location = new System.Drawing.Point(12, 99);
            this.labelMaxIter.Name = "labelMaxIter";
            this.labelMaxIter.Size = new System.Drawing.Size(100, 16);
            this.labelMaxIter.TabIndex = 6;
            this.labelMaxIter.Text = "Maks. İterasyon:";
            // 
            // txtMaxIterasyon
            // 
            this.txtMaxIterasyon.Location = new System.Drawing.Point(160, 96);
            this.txtMaxIterasyon.Name = "txtMaxIterasyon";
            this.txtMaxIterasyon.Size = new System.Drawing.Size(100, 22);
            this.txtMaxIterasyon.TabIndex = 7;
            this.txtMaxIterasyon.Text = "100";
            // 
            // labelAltSinir
            // 
            this.labelAltSinir.AutoSize = true;
            this.labelAltSinir.Location = new System.Drawing.Point(12, 127);
            this.labelAltSinir.Name = "labelAltSinir";
            this.labelAltSinir.Size = new System.Drawing.Size(120, 16);
            this.labelAltSinir.TabIndex = 8;
            this.labelAltSinir.Text = "Değişken Alt Sınır:";
            // 
            // txtAltSinir
            // 
            this.txtAltSinir.Location = new System.Drawing.Point(160, 124);
            this.txtAltSinir.Name = "txtAltSinir";
            this.txtAltSinir.Size = new System.Drawing.Size(100, 22);
            this.txtAltSinir.TabIndex = 9;
            this.txtAltSinir.Text = "-5";
            // 
            // labelUstSinir
            // 
            this.labelUstSinir.AutoSize = true;
            this.labelUstSinir.Location = new System.Drawing.Point(12, 155);
            this.labelUstSinir.Name = "labelUstSinir";
            this.labelUstSinir.Size = new System.Drawing.Size(124, 16);
            this.labelUstSinir.TabIndex = 10;
            this.labelUstSinir.Text = "Değişken Üst Sınır:";
            // 
            // txtUstSinir
            // 
            this.txtUstSinir.Location = new System.Drawing.Point(160, 152);
            this.txtUstSinir.Name = "txtUstSinir";
            this.txtUstSinir.Size = new System.Drawing.Size(100, 22);
            this.txtUstSinir.TabIndex = 11;
            this.txtUstSinir.Text = "5";
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(15, 190);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(245, 30);
            this.btnBaslat.TabIndex = 12;
            this.btnBaslat.Text = "Algoritmayı Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // btnHesaplaBit
            // 
            this.btnHesaplaBit.Location = new System.Drawing.Point(15, 230);
            this.btnHesaplaBit.Name = "btnHesaplaBit";
            this.btnHesaplaBit.Size = new System.Drawing.Size(245, 30);
            this.btnHesaplaBit.TabIndex = 22;
            this.btnHesaplaBit.Text = "Bit Hesaplama Sorusu Çöz";
            this.btnHesaplaBit.UseVisualStyleBackColor = true;
            this.btnHesaplaBit.Click += new System.EventHandler(this.btnHesaplaBit_Click);
            // 
            // labelEnIyiSonuc
            // 
            this.labelEnIyiSonuc.AutoSize = true;
            this.labelEnIyiSonuc.Location = new System.Drawing.Point(12, 275);
            this.labelEnIyiSonuc.Name = "labelEnIyiSonuc";
            this.labelEnIyiSonuc.Size = new System.Drawing.Size(114, 16);
            this.labelEnIyiSonuc.TabIndex = 13;
            this.labelEnIyiSonuc.Text = "En İyi Sonuç (f(x)):";
            // 
            // txtEnIyiSonuc
            // 
            this.txtEnIyiSonuc.Location = new System.Drawing.Point(160, 272);
            this.txtEnIyiSonuc.Name = "txtEnIyiSonuc";
            this.txtEnIyiSonuc.ReadOnly = true;
            this.txtEnIyiSonuc.Size = new System.Drawing.Size(100, 22);
            this.txtEnIyiSonuc.TabIndex = 14;
            // 
            // labelEnIyiX1
            // 
            this.labelEnIyiX1.AutoSize = true;
            this.labelEnIyiX1.Location = new System.Drawing.Point(12, 303);
            this.labelEnIyiX1.Name = "labelEnIyiX1";
            this.labelEnIyiX1.Size = new System.Drawing.Size(102, 16);
            this.labelEnIyiX1.TabIndex = 15;
            this.labelEnIyiX1.Text = "En İyi X1 Değeri:";
            // 
            // txtEnIyiX1
            // 
            this.txtEnIyiX1.Location = new System.Drawing.Point(160, 300);
            this.txtEnIyiX1.Name = "txtEnIyiX1";
            this.txtEnIyiX1.ReadOnly = true;
            this.txtEnIyiX1.Size = new System.Drawing.Size(100, 22);
            this.txtEnIyiX1.TabIndex = 16;
            // 
            // labelEnIyiX2
            // 
            this.labelEnIyiX2.AutoSize = true;
            this.labelEnIyiX2.Location = new System.Drawing.Point(12, 331);
            this.labelEnIyiX2.Name = "labelEnIyiX2";
            this.labelEnIyiX2.Size = new System.Drawing.Size(102, 16);
            this.labelEnIyiX2.TabIndex = 17;
            this.labelEnIyiX2.Text = "En İyi X2 Değeri:";
            // 
            // txtEnIyiX2
            // 
            this.txtEnIyiX2.Location = new System.Drawing.Point(160, 328);
            this.txtEnIyiX2.Name = "txtEnIyiX2";
            this.txtEnIyiX2.ReadOnly = true;
            this.txtEnIyiX2.Size = new System.Drawing.Size(100, 22);
            this.txtEnIyiX2.TabIndex = 18;
            // 
            // chartYakinlama
            // 
            chartArea1.Name = "ChartArea1";
            this.chartYakinlama.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartYakinlama.Legends.Add(legend1);
            this.chartYakinlama.Location = new System.Drawing.Point(280, 12);
            this.chartYakinlama.Name = "chartYakinlama";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Yakınsama";
            this.chartYakinlama.Series.Add(series1);
            this.chartYakinlama.Size = new System.Drawing.Size(508, 300);
            this.chartYakinlama.TabIndex = 19;
            this.chartYakinlama.Text = "Yakınsama Grafiği";
            // 
            // labelAlgoritma
            // 
            this.labelAlgoritma.AutoSize = true;
            this.labelAlgoritma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAlgoritma.Location = new System.Drawing.Point(800, 12);
            this.labelAlgoritma.Name = "labelAlgoritma";
            this.labelAlgoritma.Size = new System.Drawing.Size(266, 20);
            this.labelAlgoritma.TabIndex = 20;
            this.labelAlgoritma.Text = "ABC ALGORİTMASI AÇIKLAMA";
            // 
            // rtbAlgoritmaAciklama
            // 
            this.rtbAlgoritmaAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAlgoritmaAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rtbAlgoritmaAciklama.Location = new System.Drawing.Point(800, 35);
            this.rtbAlgoritmaAciklama.Name = "rtbAlgoritmaAciklama";
            this.rtbAlgoritmaAciklama.ReadOnly = true;
            this.rtbAlgoritmaAciklama.Size = new System.Drawing.Size(400, 403);
            this.rtbAlgoritmaAciklama.TabIndex = 21;
            this.rtbAlgoritmaAciklama.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 500);
            this.Controls.Add(this.rtbAlgoritmaAciklama);
            this.Controls.Add(this.labelAlgoritma);
            this.Controls.Add(this.chartYakinlama);
            this.Controls.Add(this.txtEnIyiX2);
            this.Controls.Add(this.labelEnIyiX2);
            this.Controls.Add(this.txtEnIyiX1);
            this.Controls.Add(this.labelEnIyiX1);
            this.Controls.Add(this.txtEnIyiSonuc);
            this.Controls.Add(this.labelEnIyiSonuc);
            this.Controls.Add(this.btnHesaplaBit);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.txtUstSinir);
            this.Controls.Add(this.labelUstSinir);
            this.Controls.Add(this.txtAltSinir);
            this.Controls.Add(this.labelAltSinir);
            this.Controls.Add(this.txtMaxIterasyon);
            this.Controls.Add(this.labelMaxIter);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.labelLimit);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.txtCS);
            this.Controls.Add(this.labelCS);
            this.Name = "Form1";
            this.Text = "Yapay Arı Kolonisi Algoritması";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartYakinlama)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelCS;
        private System.Windows.Forms.TextBox txtCS;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label labelLimit;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label labelMaxIter;
        private System.Windows.Forms.TextBox txtMaxIterasyon;
        private System.Windows.Forms.Label labelAltSinir;
        private System.Windows.Forms.TextBox txtAltSinir;
        private System.Windows.Forms.Label labelUstSinir;
        private System.Windows.Forms.TextBox txtUstSinir;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Button btnHesaplaBit;
        private System.Windows.Forms.Label labelEnIyiSonuc;
        private System.Windows.Forms.TextBox txtEnIyiSonuc;
        private System.Windows.Forms.Label labelEnIyiX1;
        private System.Windows.Forms.TextBox txtEnIyiX1;
        private System.Windows.Forms.Label labelEnIyiX2;
        private System.Windows.Forms.TextBox txtEnIyiX2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYakinlama;
        private System.Windows.Forms.Label labelAlgoritma;
        private System.Windows.Forms.RichTextBox rtbAlgoritmaAciklama;
    }
}