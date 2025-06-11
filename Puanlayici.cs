using System;
using System.Collections.Generic;
using System.Globalization;

public class Puanlayici
{
    private Tahta tahta;
    private Dictionary<Tas, bool> tehditDurumlari;

    public Puanlayici(Tahta tahta, Dictionary<Tas, bool> tehditDurumlari)
    {
        this.tahta = tahta;
        this.tehditDurumlari = tehditDurumlari;
    }

    public (double beyaz, double siyah) PuanlariGetir()
    {
        double beyazPuan = 0;
        double siyahPuan = 0;

        foreach (Tas tas in tahta.Taslar)
        {
            double puan = tas.Puan();

            if (tehditDurumlari.TryGetValue(tas, out bool tehditte) && tehditte)
                puan /= 2.0;

            if (tas.Renk == 'b')
                beyazPuan += puan;
            else
                siyahPuan += puan;
        }

        return (beyazPuan, siyahPuan);
    }

    public void PuanlariYazdir(string dosyaAdi)
    {
        var (beyaz, siyah) = PuanlariGetir();
        Console.WriteLine($"{dosyaAdi}\t\tSiyah:{siyah.ToString(CultureInfo.InvariantCulture)}   Beyaz:{beyaz.ToString(CultureInfo.InvariantCulture)}");
    }
}
