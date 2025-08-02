// Gerekli using direktifleri
using System;
using System.Collections.Generic; // List<T> gibi koleksiyonları kullanmak için
using System.Linq; // LINQ sorgularını (örn: Sum, Max, OrderBy) kullanmak için

// Projemizin ana isim alanı
namespace abc
{
    /// <summary>
    /// Yapay Arı Kolonisi (ABC) algoritmasının ana mantığını ve operasyonlarını yöneten sınıftır.
    /// </summary>
    public class ABCAlgoritmasi
    {
        // --- ALGORİTMA PARAMETRELERİ VE ALANLAR ---
        private int koloniBuyukluguCS;     // CS: Kolonideki toplam arı sayısı
        private int problemBoyutuD;        // D: Problemin boyutu (karar değişkeni sayısı)
        private int limitL;                // L: Bir kaynağın terk edilmesi için geliştirilememe sınırı
        private int maksimumIterasyon;     // Algoritmanın maksimum döngü sayısı
        private double altSinirParam;      // Karar değişkenlerinin alt sınırı
        private double ustSinirParam;      // Karar değişkenlerinin üst sınırı

        private List<YiyecekKaynagi> yiyecekKaynaklariListesi; // Popülasyondaki yiyecek kaynakları (SN = CS/2)
        private YiyecekKaynagi? genelEnIyiKaynak;             // Tüm iterasyonlar boyunca bulunan en iyi kaynak

        private static Random randomGenerator = new Random(); // Tek bir Random nesnesi

        /// <summary>
        /// Her iterasyon sonunda bulunan en iyi amaç fonksiyonu değerini saklar (yakınsama grafiği için).
        /// </summary>
        public List<double> EnIyiDegerGecmisiListesi { get; private set; }

        // --- YAPICI METOT (Constructor) ---
        /// <summary>
        /// ABCAlgoritmasi sınıfının bir örneğini başlatır.
        /// </summary>
        /// <param name="cs">Koloni büyüklüğü (arı sayısı).</param>
        /// <param name="d">Problemin boyutu (değişken sayısı).</param>
        /// <param name="limit">Bir kaynağın terk edilme sınırı.</param>
        /// <param name="maxIter">Maksimum iterasyon sayısı.</param>
        /// <param name="altSinir">Değişkenler için alt sınır.</param>
        /// <param name="ustSinir">Değişkenler için üst sınır.</param>
        public ABCAlgoritmasi(int cs, int d, int limit, int maxIter, double altSinir, double ustSinir)
        {
            this.koloniBuyukluguCS = cs;
            this.problemBoyutuD = d;
            this.limitL = limit;
            this.maksimumIterasyon = maxIter;
            this.altSinirParam = altSinir;
            this.ustSinirParam = ustSinir;

            this.yiyecekKaynaklariListesi = new List<YiyecekKaynagi>();
            this.EnIyiDegerGecmisiListesi = new List<double>();
            this.genelEnIyiKaynak = null;
        }

        // --- ANA ALGORİTMA ADIMLARI ---

        /// <summary>
        /// 1. Adım (Başlangıç): Yiyecek kaynaklarını (popülasyonu) rastgele oluşturur.
        /// </summary>
        private void BaslangicPopulasyonunuOlustur()
        {
            this.yiyecekKaynaklariListesi.Clear(); // Önceki çalıştırmadan kalıntı varsa temizle
            int kaynakSayisiSN = this.koloniBuyukluguCS / 2; // Kaynak sayısı = Görevli arı sayısı = Koloni Boyutu / 2

            for (int i = 0; i < kaynakSayisiSN; i++)
            {
                this.yiyecekKaynaklariListesi.Add(new YiyecekKaynagi(this.problemBoyutuD, this.altSinirParam, this.ustSinirParam));
            }
            // Başlangıçtaki en iyi kaynağı belirle ve kaydet
            GenelEnIyiKaynagiGuncelle();
        }

        /// <summary>
        /// 2. Adım (Görevli Arı Fazı): Her görevli arı, kendi kaynağı etrafında yeni bir çözüm arar.
        /// Eşitlik 3.2'yi kullanarak yeni bir kaynak (vi) üretir ve açgözlü seçim yapar.
        /// </summary>
        private void GorevliArilariGonder()
        {
            int kaynakSayisiSN = this.yiyecekKaynaklariListesi.Count; // = CS / 2
            for (int i = 0; i < kaynakSayisiSN; i++)
            {
                YiyecekKaynagi mevcutKaynakXi = this.yiyecekKaynaklariListesi[i];

                // Eşitlik 3.2: vi,j = xi,j + φi,j * (xi,j - xk,j)
                // Yeni bir aday çözüm (vi) üret
                YiyecekKaynagi adayKaynakVi = YeniAdayCozumUret(mevcutKaynakXi, i);

                // Açgözlü seleksiyon (daha iyi olanı seç)
                if (adayKaynakVi.Uygunluk > mevcutKaynakXi.Uygunluk)
                {
                    // Yeni çözüm daha iyiyse, eski çözümü güncelle ve başarısızlık sayacını sıfırla
                    this.yiyecekKaynaklariListesi[i] = adayKaynakVi; // Referansı güncelle
                }
                else
                {
                    // Yeni çözüm daha iyi değilse, başarısızlık sayacını artır
                    this.yiyecekKaynaklariListesi[i].BasarisizlikSayaci++;
                }
            }
        }

        /// <summary>
        /// Görevli veya Gözcü arı için yeni bir aday çözüm (vi) üretir.
        /// Eşitlik 3.2: vi,j = xi,j + φi,j * (xi,j - xk,j)
        /// </summary>
        /// <param name="mevcutKaynakXi">Mevcut kaynak (xi).</param>
        /// <param name="mevcutKaynakIndexi">Mevcut kaynağın listedeki indeksi (i).</param>
        /// <returns>Yeni üretilen aday kaynak (vi).</returns>
        private YiyecekKaynagi YeniAdayCozumUret(YiyecekKaynagi mevcutKaynakXi, int mevcutKaynakIndexi)
        {
            YiyecekKaynagi adayKaynakVi = new YiyecekKaynagi(this.problemBoyutuD, this.altSinirParam, this.ustSinirParam);
            // Pozisyonunu mevcut kaynaktan kopyala, sonra bir boyutunu değiştir.
            Array.Copy(mevcutKaynakXi.Pozisyon, adayKaynakVi.Pozisyon, this.problemBoyutuD);

            // Rastgele bir boyut (j) seç (0 ile D-1 arasında)
            int degistirilecekBoyutJ = randomGenerator.Next(this.problemBoyutuD);

            // Rastgele bir komşu kaynak (xk) seç (k != i olmalı)
            int komsuKaynakIndexK;
            do
            {
                komsuKaynakIndexK = randomGenerator.Next(this.yiyecekKaynaklariListesi.Count);
            } while (komsuKaynakIndexK == mevcutKaynakIndexi); // k, i'den farklı olmalı

            YiyecekKaynagi komsuKaynakXk = this.yiyecekKaynaklariListesi[komsuKaynakIndexK];

            // φi,j: [-1, 1] aralığında rastgele bir sayı üret
            double phi = (randomGenerator.NextDouble() * 2.0) - 1.0;

            // Eşitlik 3.2'ye göre seçilen boyuttaki yeni pozisyonu hesapla:
            // vi,j = xi,j + φi,j * (xi,j - xk,j)
            adayKaynakVi.Pozisyon[degistirilecekBoyutJ] = mevcutKaynakXi.Pozisyon[degistirilecekBoyutJ] +
                                                       phi * (mevcutKaynakXi.Pozisyon[degistirilecekBoyutJ] - komsuKaynakXk.Pozisyon[degistirilecekBoyutJ]);

            // Yeni pozisyonun sınırlar içinde olduğundan emin ol
            adayKaynakVi.SinirlariKontrolEt();
            // Yeni pozisyonun değerini ve uygunluğunu hesapla
            adayKaynakVi.DegerHesapla();
            adayKaynakVi.UygunlukHesapla();

            return adayKaynakVi;
        }

        /// <summary>
        /// 3. Adım (Gözcü Arı Fazı): Gözcü arılar, kaynakların uygunluklarına göre olasılıksal seçim yapar.
        /// Seçtikleri kaynaklar etrafında yeni çözümler ararlar (Görevli Arı Fazı'ndaki gibi).
        /// Eşitlik 3.5 ile olasılıklar (pi) hesaplanır.
        /// </summary>
        private void GozcuArilariGonder()
        {
            double toplamUygunluk = this.yiyecekKaynaklariListesi.Sum(kaynak => kaynak.Uygunluk);
            if (toplamUygunluk == 0) return; // Tüm uygunluklar sıfırsa (çok nadir), devam etme.

            // Olasılıkları hesapla (Eşitlik 3.5: pi = fitness_i / Σ fitness_n)
            List<double> olasiklarPi = new List<double>();
            foreach (YiyecekKaynagi kaynak in this.yiyecekKaynaklariListesi)
            {
                olasiklarPi.Add(kaynak.Uygunluk / toplamUygunluk);
            }

            // Gözcü arı sayısı da kaynak sayısına eşittir (CS/2)
            // Her gözcü arı için bir kaynak seçimi ve geliştirme denemesi
            int gozcuAriSayisi = this.koloniBuyukluguCS / 2;
            for (int n = 0; n < gozcuAriSayisi; n++) // n: mevcut gözcü arı
            {
                // Rulet tekerleği ile kaynak seçimi
                double rastgeleSayi = randomGenerator.NextDouble();
                double kumulatifOlasilik = 0;
                int secilenKaynakIndexi = -1;

                for (int i = 0; i < this.yiyecekKaynaklariListesi.Count; i++)
                {
                    kumulatifOlasilik += olasiklarPi[i];
                    if (rastgeleSayi <= kumulatifOlasilik)
                    {
                        secilenKaynakIndexi = i;
                        break;
                    }
                }

                // Eğer bir sebepten ötürü (çok küçük olasılıklar, yuvarlama hataları)
                // bir kaynak seçilemezse, sonuncuyu veya rastgele birini seçebiliriz.
                if (secilenKaynakIndexi == -1 && this.yiyecekKaynaklariListesi.Any())
                {
                    secilenKaynakIndexi = this.yiyecekKaynaklariListesi.Count - 1;
                }

                if (secilenKaynakIndexi != -1)
                {
                    YiyecekKaynagi secilenKaynakXi = this.yiyecekKaynaklariListesi[secilenKaynakIndexi];

                    // Seçilen kaynak etrafında yeni bir aday çözüm üret (Görevli arı fazındaki gibi)
                    YiyecekKaynagi adayKaynakVi = YeniAdayCozumUret(secilenKaynakXi, secilenKaynakIndexi);

                    // Açgözlü seleksiyon
                    if (adayKaynakVi.Uygunluk > secilenKaynakXi.Uygunluk)
                    {
                        this.yiyecekKaynaklariListesi[secilenKaynakIndexi] = adayKaynakVi;
                    }
                    else
                    {
                        this.yiyecekKaynaklariListesi[secilenKaynakIndexi].BasarisizlikSayaci++;
                    }
                }
            }
        }

        /// <summary>
        /// 4. Adım (Kaşif Arı Fazı): Başarısızlık sayacı limiti (L) aşan kaynakları terk eder
        /// ve yerlerine rastgele yeni kaynaklar oluşturur.
        /// </summary>
        private void KasifArilariGonder()
        {
            for (int i = 0; i < this.yiyecekKaynaklariListesi.Count; i++)
            {
                if (this.yiyecekKaynaklariListesi[i].BasarisizlikSayaci >= this.limitL)
                {
                    // Kaynak limiti aştıysa, yerine rastgele yeni bir kaynak oluştur
                    this.yiyecekKaynaklariListesi[i] = new YiyecekKaynagi(this.problemBoyutuD, this.altSinirParam, this.ustSinirParam);
                }
            }
        }

        /// <summary>
        /// Mevcut yiyecek kaynakları listesindeki en iyi (en yüksek uygunluğa sahip) kaynağı bulur
        /// ve 'genelEnIyiKaynak' alanını günceller.
        /// </summary>
        private void GenelEnIyiKaynagiGuncelle()
        {
            // Eğer liste boşsa veya hiç eleman yoksa hata vermemesi için kontrol
            if (this.yiyecekKaynaklariListesi == null || !this.yiyecekKaynaklariListesi.Any()) return;

            YiyecekKaynagi mevcutIterasyonunEnIyisi = this.yiyecekKaynaklariListesi.OrderByDescending(k => k.Uygunluk).First();

            if (this.genelEnIyiKaynak == null || mevcutIterasyonunEnIyisi.Uygunluk > this.genelEnIyiKaynak.Uygunluk)
            {
                // Global en iyi çözümü kopyalamak için yeni bir nesne oluşturabiliriz
                this.genelEnIyiKaynak = new YiyecekKaynagi(this.problemBoyutuD, this.altSinirParam, this.ustSinirParam);
                Array.Copy(mevcutIterasyonunEnIyisi.Pozisyon, this.genelEnIyiKaynak.Pozisyon, this.problemBoyutuD);
                this.genelEnIyiKaynak.DegerHesapla();       // Değerini hesapla
                this.genelEnIyiKaynak.UygunlukHesapla();    // Uygunluğunu hesapla
            }
        }

        /// <summary>
        /// Yapay Arı Kolonisi algoritmasını belirtilen iterasyon sayısı kadar çalıştırır.
        /// </summary>
        /// <returns>Algoritma tamamlandığında bulunan en iyi yiyecek kaynağını (çözümü) döndürür.</returns>
        public YiyecekKaynagi? Calistir()
        {
            this.EnIyiDegerGecmisiListesi.Clear(); // Önceki çalıştırmadan kalıntı varsa temizle
            this.genelEnIyiKaynak = null; // Önceki en iyiyi sıfırla

            BaslangicPopulasyonunuOlustur(); // Adım 1

            for (int iter = 0; iter < this.maksimumIterasyon; iter++)
            {
                GorevliArilariGonder();     // Adım 2 (Eşitlik 3.2, Açgözlü Seçim, Sayaçlar)
                GozcuArilariGonder();       // Adım 3 (Eşitlik 3.5, Eşitlik 3.2, Açgözlü Seçim, Sayaçlar)
                GenelEnIyiKaynagiGuncelle(); // Her iterasyonda genel en iyiyi kontrol et ve güncelle
                KasifArilariGonder();       // Adım 4 (Limit kontrolü ve yeni kaynak)

                // Yakınsama grafiği için her iterasyondaki en iyi değeri kaydet
                if (this.genelEnIyiKaynak != null)
                {
                    this.EnIyiDegerGecmisiListesi.Add(this.genelEnIyiKaynak.Deger); // Amaç fonksiyonu değerini kaydet
                }
                else if (this.yiyecekKaynaklariListesi.Any()) // Eğer genel en iyi henüz yoksa ama kaynak varsa, o anki en iyiyi ekle
                {
                    this.EnIyiDegerGecmisiListesi.Add(this.yiyecekKaynaklariListesi.OrderByDescending(k => k.Uygunluk).First().Deger);
                }
            }

            return this.genelEnIyiKaynak; // Algoritma tamamlandığında bulunan en iyi çözümü döndür
        }
    }
}