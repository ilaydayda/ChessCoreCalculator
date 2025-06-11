using System;
using System.Collections.Generic;
using System.IO;

public class Tahta
{
    public List<Tas> Taslar { get; set; }

    public Tahta()
    {
        Taslar = new List<Tas>();
    }

    public void TahtayiYukle(string dosya)
    {
        string[] satirlar = File.ReadAllLines(dosya);

        for (int satir = 0; satir < 8; satir++)
        {
            string[] hucreler = satirlar[satir].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (hucreler.Length != 8)
            {
                Console.WriteLine($"HATA: {satir + 1}. satırda 8 hücre bekleniyordu, ama {hucreler.Length} bulundu.");
                continue;
            }

            for (int sutun = 0; sutun < 8; sutun++)
            {
                string hucre = hucreler[sutun];
                if (hucre != "--")
                {
                    char tur = hucre[0];
                    char renk = hucre[1];
                    Tas tas = new Tas(tur, renk, satir, sutun);
                    Taslar.Add(tas);
                }
            }
        }
    }
}
