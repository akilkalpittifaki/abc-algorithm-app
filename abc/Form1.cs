// Gerekli using direktifleri
using System;
using System.Collections.Generic; // List<T> için
using System.Text;                // StringBuilder için
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Chart kontrolü için
using System.IO;                  // Dosya işlemleri için

namespace abc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Form tasarımındaki kontrolleri yükler (ÇOK ÖNEMLİ!)
            GrafikAyarlariniYap();    // Yakınsama grafiği için başlangıç ayarları
        }

        /// <summary>
        /// Form yüklendiğinde çalışacak kod
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // abc_algoritma.txt dosyasını oku ve içeriğini RichTextBox'a yükle
                string algoritmaYolu = Path.Combine(Application.StartupPath, "abc_algoritma.txt");
                if (File.Exists(algoritmaYolu))
                {
                    string algoritmaIcerik = File.ReadAllText(algoritmaYolu);
                    rtbAlgoritmaAciklama.Text = algoritmaIcerik;
                }
                else
                {
                    rtbAlgoritmaAciklama.Text = "Algoritma açıklama dosyası (abc_algoritma.txt) bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                rtbAlgoritmaAciklama.Text = $"Algoritma açıklama dosyası yüklenirken hata oluştu: {ex.Message}";
            }
        }

        /// <summary>
        /// Yakınsama grafiği için temel ayarları yapar.
        /// </summary>
        private void GrafikAyarlariniYap()
        {
            // chartYakinlama kontrol ayarları
            chartYakinlama.Series.Clear();
            Series seriesYakinlama = new Series("Yakınsama")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = System.Drawing.Color.CornflowerBlue,
                XValueType = ChartValueType.Int32,
                YValueType = ChartValueType.Double
            };
            chartYakinlama.Series.Add(seriesYakinlama);

            chartYakinlama.ChartAreas[0].AxisX.Title = "İterasyon";
            chartYakinlama.ChartAreas[0].AxisY.Title = "En İyi Amaç Fonksiyonu Değeri";
            chartYakinlama.ChartAreas[0].AxisX.Minimum = 0;
            chartYakinlama.ChartAreas[0].RecalculateAxesScale();
        }

        /// <summary>
        /// "Algoritmayı Başlat" butonuna tıklandığında çalışacak olay yöneticisi.
        /// </summary>
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                // Önce bit hesaplama sorusunu çözelim
                BitHesaplamasorusuCoz();

                // 1. Kullanıcıdan girdileri al ve doğrula
                if (!int.TryParse(txtCS.Text, out int koloniSayisiCS) || koloniSayisiCS <= 0 || koloniSayisiCS % 2 != 0)
                {
                    MessageBox.Show("Lütfen geçerli ve çift bir Koloni Büyüklüğü (CS) girin (örn: 6, 20).", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtD.Text, out int problemBoyutuD) || problemBoyutuD <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir Problem Boyutu (D) girin (örn: 2).", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtLimit.Text, out int limitL) || limitL < 0)
                {
                    MessageBox.Show("Lütfen geçerli bir Limit (L) değeri girin (örn: (CS*D)/2).", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtMaxIterasyon.Text, out int maxIterasyon) || maxIterasyon <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir Maksimum İterasyon sayısı girin (örn: 100).", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtAltSinir.Text, out double altSinir))
                {
                    MessageBox.Show("Lütfen geçerli bir Değişken Alt Sınır değeri girin (örn: -5).", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtUstSinir.Text, out double ustSinir) || ustSinir <= altSinir)
                {
                    MessageBox.Show("Lütfen geçerli bir Değişken Üst Sınır değeri girin (üst sınır, alt sınırdan büyük olmalıdır; örn: 5).", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. ABC Algoritmasını oluştur ve çalıştır
                ABCAlgoritmasi abcAlgoritmasi = new ABCAlgoritmasi(koloniSayisiCS, problemBoyutuD, limitL, maxIterasyon, altSinir, ustSinir);
                YiyecekKaynagi? enIyiSonuc = abcAlgoritmasi.Calistir();

                // 3. Sonuçları kullanıcı arayüzünde göster
                if (enIyiSonuc != null)
                {
                    // Amaç fonksiyonu değerini göster
                    txtEnIyiSonuc.Text = enIyiSonuc.Deger.ToString("F6");

                    // Karar değişkenlerinin değerlerini göster
                    if (problemBoyutuD >= 1)
                    {
                        txtEnIyiX1.Text = enIyiSonuc.Pozisyon[0].ToString("F4");
                    }
                    
                    if (problemBoyutuD >= 2)
                    {
                        txtEnIyiX2.Text = enIyiSonuc.Pozisyon[1].ToString("F4");
                    }

                    // 4. Yakınsama grafiğini çizdir
                    chartYakinlama.Series["Yakınsama"].Points.Clear();
                    if (abcAlgoritmasi.EnIyiDegerGecmisiListesi != null)
                    {
                        for (int i = 0; i < abcAlgoritmasi.EnIyiDegerGecmisiListesi.Count; i++)
                        {
                            chartYakinlama.Series["Yakınsama"].Points.AddXY(i + 1, abcAlgoritmasi.EnIyiDegerGecmisiListesi[i]);
                        }
                        chartYakinlama.ChartAreas[0].RecalculateAxesScale();
                    }
                }
                else
                {
                    MessageBox.Show("Algoritma bir sonuç üretemedi.", "Sonuç Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEnIyiSonuc.Text = "N/A";
                    txtEnIyiX1.Text = "N/A";
                    txtEnIyiX2.Text = "N/A";
                    chartYakinlama.Series["Yakınsama"].Points.Clear();
                }
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show($"Lütfen tüm parametreleri sayısal olarak doğru formatta giriniz.\nDetay: {formatEx.Message}", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception genelHata)
            {
                MessageBox.Show($"Algoritma çalıştırılırken beklenmedik bir hata oluştu:\n{genelHata.Message}\n\nDetay:\n{genelHata.StackTrace}", "Çalışma Zamanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bit hesaplama sorusunu çözen metod
        /// </summary>
        private void BitHesaplamasorusuCoz()
        {
            // Sorudaki değerleri tanımla
            double altSinir = -1.0;
            double ustSinir = 3.0;
            int virguldenSonraHassasiyet = 2;

            try
            {
                // Gerekli toplam adım sayısını hesapla
                double aralikGenisligi = ustSinir - altSinir;
                double hassasiyet = Math.Pow(10, -virguldenSonraHassasiyet);
                double adimSayisi = aralikGenisligi / hassasiyet;

                // Temsil edilmesi gereken toplam değer sayısı (adım sayısı + 1)
                double toplamDegerSayisi = adimSayisi + 1;

                // Gerekli bit sayısını bul (2^m >= toplamDegerSayisi)
                int bitSayisi = 0;
                for (int m = 1; m < 32; m++) // 32 bitlik integer sınırı için güvenli döngü
                {
                    if (Math.Pow(2, m) >= toplamDegerSayisi)
                    {
                        bitSayisi = m;
                        break; // Yeterli bit sayısını bulduk, döngüden çık
                    }
                }

                // Sonucu kullanıcıya göster
                if (bitSayisi > 0)
                {
                    MessageBox.Show(
                        $"🔢 BİT HESAPLAMA SORUSU ÇÖZÜMÜ 🔢\n\n" +
                        $"📋 Problem: [-1, 3] aralığında 2 ondalık hassasiyetle minimum bit sayısı\n\n" +
                        $"📊 Çözüm Adımları:\n" +
                        $"• Aralık genişliği: {ustSinir} - ({altSinir}) = {aralikGenisligi}\n" +
                        $"• Hassasiyet: 10^(-{virguldenSonraHassasiyet}) = {hassasiyet}\n" +
                        $"• Adım sayısı: {aralikGenisligi} / {hassasiyet} = {adimSayisi}\n" +
                        $"• Toplam değer sayısı: {adimSayisi} + 1 = {toplamDegerSayisi}\n\n" +
                        $"💡 Bit hesaplama: 2^m >= {toplamDegerSayisi}\n" +
                        $"✅ Sonuç: m = {bitSayisi} bit (2^{bitSayisi})\n\n" +
                        $"🎯 CEVAP: {bitSayisi} bit gereklidir!",
                        "🧮 Bit Hesaplama Sorusu Çözümü",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hesaplama yapılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hesaplama sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bit hesaplama butonu için soruyu çözen metod
        /// </summary>
        private void btnHesaplaBit_Click(object sender, EventArgs e)
        {
            BitHesaplamasorusuCoz();
        }
    }
}