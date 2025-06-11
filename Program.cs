using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Kullanılacak dosyaların listesi
        string[] dosyalar = { "tahta.txt", "tahta2.txt", "tahta3.txt" };

        Console.WriteLine("Tahta Dosya Adı\t\tSonuçlar");

        foreach (string dosyaAdi in dosyalar)
        {
            //Tahtayı yükle
            Tahta tahta = new Tahta();
            tahta.TahtayiYukle(dosyaAdi);

            //Tehdit durumlarını hesapla
            TehditHesaplayici hesaplayici = new TehditHesaplayici(tahta);
            var tehditDurumlari = hesaplayici.TehditDurumlariniHesapla();

            //Puanları hesapla
            Puanlayici puanlayici = new Puanlayici(tahta, tehditDurumlari);
            var (beyaz, siyah) = puanlayici.PuanlariGetir();

            //Sonuçları yazdır
            Console.WriteLine($"{dosyaAdi}\t\tSiyah:{siyah.ToString(CultureInfo.InvariantCulture)}   Beyaz:{beyaz.ToString(CultureInfo.InvariantCulture)}");
        }

        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
        Console.ReadKey();
    }
}
