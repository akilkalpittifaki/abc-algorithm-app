// Bu satır, System isim alanındaki temel sınıfları ve temel türleri kullanabilmemizi sağlar.
using System;

// Projemizin ana isim alanı (namespace). Diğer dosyalarımız da bu isim alanı içinde olacak.
namespace abc
{
    /// <summary>
    /// Yapay Arı Kolonisi algoritmasındaki bir yiyecek kaynağını (potansiyel çözümü) temsil eder.
    /// Her yiyecek kaynağı, bir pozisyona (çözüm vektörü), bir değere (amaç fonksiyonu sonucu),
    /// bir uygunluk değerine ve bir başarısızlık sayacına sahiptir.
    /// </summary>
    public class YiyecekKaynagi
    {
        // --- ALANLAR (Fields) ---
        private static Random randomGenerator = new Random(); // Tüm kaynaklar için tek bir Random nesnesi
        private int problemBoyutuD;         // Problemin boyutu (D)
        private double altSinirParam;       // Karar değişkenleri için alt sınır
        private double ustSinirParam;       // Karar değişkenleri için üst sınır

        // --- ÖZELLİKLER (Properties) ---

        /// <summary>
        /// Yiyecek kaynağının pozisyonu. Karar değişkenlerinin değerlerini tutan bir dizidir.
        /// Örneğin, f(x1, x2) = x1^2 + x2^2 fonksiyonu için Pozisyon = [x1, x2] olacaktır.
        /// Boyutu (D), problemin boyutuna eşittir.
        /// </summary>
        public double[] Pozisyon { get; set; }

        /// <summary>
        /// Yiyecek kaynağının (çözümün) amaç fonksiyonu tarafından hesaplanan değeri.
        /// Minimizasyon probleminde bu değerin küçük olması istenir.
        /// </summary>
        public double Deger { get; private set; } // Sadece içeriden hesaplanarak set edilsin

        /// <summary>
        /// Yiyecek kaynağının (çözümün) uygunluk değeri (fitness).
        /// Minimizasyon probleminde genellikle 1/(1+Değer) veya benzeri bir formülle hesaplanır.
        /// Uygunluk değeri ne kadar yüksekse, çözüm o kadar iyidir.
        /// </summary>
        public double Uygunluk { get; private set; } // Sadece içeriden hesaplanarak set edilsin

        /// <summary>
        /// Kaynağın başarısızlık sayacı (failure counter).
        /// Eğer bir kaynak belirli bir sayıda iterasyon boyunca iyileştirilemezse,
        /// bu sayaç artar. Belirli bir limite ulaştığında kaynak terk edilebilir.
        /// </summary>
        public int BasarisizlikSayaci { get; set; }

        // --- YAPICI METOT (Constructor) ---

        /// <summary>
        /// Yeni bir YiyecekKaynagi nesnesi oluşturur.
        /// Belirtilen problem boyutu, alt ve üst sınırlar dahilinde rastgele bir pozisyon atar.
        /// Başlangıç değerini, uygunluğunu hesaplar ve başarısızlık sayacını sıfırlar.
        /// </summary>
        /// <param name="boyutD">Problemin boyutu (karar değişkeni sayısı).</param>
        /// <param name="altSinir">Karar değişkenlerinin alabileceği minimum değer.</param>
        /// <param name="ustSinir">Karar değişkenlerinin alabileceği maksimum değer.</param>
        public YiyecekKaynagi(int boyutD, double altSinir, double ustSinir)
        {
            this.problemBoyutuD = boyutD;
            this.altSinirParam = altSinir;
            this.ustSinirParam = ustSinir;

            this.Pozisyon = new double[this.problemBoyutuD];
            for (int i = 0; i < this.problemBoyutuD; i++)
            {
                // Pozisyonları alt ve üst sınırlar arasında rastgele ata
                this.Pozisyon[i] = randomGenerator.NextDouble() * (this.ustSinirParam - this.altSinirParam) + this.altSinirParam;
            }

            this.DegerHesapla();        // Başlangıç amaç fonksiyonu değerini hesapla
            this.UygunlukHesapla();     // Başlangıç uygunluk değerini hesapla
            this.BasarisizlikSayaci = 0; // Başarısızlık sayacını sıfırla
        }

        // --- METOTLAR ---

        /// <summary>
        /// Yiyecek kaynağının mevcut pozisyonu için amaç fonksiyonunun değerini hesaplar.
        /// Bu metot, probleminize özel amaç fonksiyonunu içermelidir.
        /// Örnek: f(x1,x2) = x1^2 + x2^2
        /// </summary>
        public void DegerHesapla()
        {
            // Hocanın verdiği örnekteki amaç fonksiyonu: f(x) = x1^2 + x2^2
            // Bu fonksiyon, problemBoyutuD (D) kadar değişken için genelleştirilebilir: Σ xi^2
            double toplamKare = 0;
            for (int i = 0; i < this.problemBoyutuD; i++)
            {
                toplamKare += Math.Pow(this.Pozisyon[i], 2);
            }
            this.Deger = toplamKare;
        }

        /// <summary>
        /// Yiyecek kaynağının hesaplanmış 'Deger'ine göre uygunluk (fitness) değerini hesaplar.
        /// Minimizasyon problemi için yaygın bir formül:
        /// Eğer f(x) >= 0 ise, uygunluk = 1 / (1 + f(x))
        /// Eğer f(x) < 0 ise, uygunluk = 1 + abs(f(x))
        /// Amaç fonksiyonumuz (x1^2 + x2^2) her zaman >= 0 sonuç vereceği için sadece ilk durumu kullanabiliriz.
        /// </summary>
        public void UygunlukHesapla()
        {
            if (this.Deger >= 0)
            {
                this.Uygunluk = 1.0 / (1.0 + this.Deger);
            }
            else
            {
                // Bu kısım, f(x) = Σ xi^2 fonksiyonu için aslında hiç çalışmayacak
                // çünkü bu fonksiyon negatif sonuç vermez. Genel bir yapı için bırakılmıştır.
                this.Uygunluk = 1.0 + Math.Abs(this.Deger);
            }
        }

        /// <summary>
        /// Yiyecek kaynağının pozisyonundaki her bir karar değişkeninin,
        /// tanımlanan alt ve üst sınırlar içinde kalmasını sağlar.
        /// Eğer bir değişken sınırların dışına çıkmışsa, en yakın sınıra çekilir (clamping).
        /// Bu, yeni çözümler üretilirken (Eşitlik 3.2) sınırlar aşıldığında önemlidir.
        /// </summary>
        public void SinirlariKontrolEt()
        {
            for (int i = 0; i < this.problemBoyutuD; i++)
            {
                if (this.Pozisyon[i] < this.altSinirParam)
                {
                    this.Pozisyon[i] = this.altSinirParam;
                }
                else if (this.Pozisyon[i] > this.ustSinirParam)
                {
                    this.Pozisyon[i] = this.ustSinirParam;
                }
            }
        }
    }
}