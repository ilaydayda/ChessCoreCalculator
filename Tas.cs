using System;
using System.Collections.Generic;

public class Tas
{
    public char Tur { get; set; }
    public char Renk { get; set; }
    public int Satir { get; set; }
    public int Sutun { get; set; }

    public Tas(char tur, char renk, int satir, int sutun)
    {
        Tur = tur;
        Renk = renk;
        Satir = satir;
        Sutun = sutun;
    }

    public int Puan()
    {
        switch(Tur)
        {
            case 'p': return 1;
            case 'a': return 3;
            case 'f': return 3;
            case 'k': return 5;
            case 'v': return 9;
            case 's': return 100;
            default: return 0;
        };
    }

    public List<(int, int)> GetirTehditliKareler()
    {
        List<(int, int)> kareler = new();

        switch (Tur)
        {
            case 'p':
                int ileri = (Renk == 'b') ? -1 : 1;
                if (Satir + ileri >= 0 && Satir + ileri < 8)
                {
                    if (Sutun - 1 >= 0)
                        kareler.Add((Satir + ileri, Sutun - 1));
                    if (Sutun + 1 < 8)
                        kareler.Add((Satir + ileri, Sutun + 1));
                }
                break;

            case 'a':
                int[,] hamleAt = { { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }, { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 } };
                for (int i = 0; i < 8; i++)
                {
                    int x = Satir + hamleAt[i, 0];
                    int y = Sutun + hamleAt[i, 1];
                    if (x >= 0 && x < 8 && y >= 0 && y < 8)
                        kareler.Add((x, y));
                }
                break;

            case 'f':
                EkleDogrusal(kareler, -1, -1);
                EkleDogrusal(kareler, -1, 1);
                EkleDogrusal(kareler, 1, -1);
                EkleDogrusal(kareler, 1, 1);
                break;

            case 'k':
                EkleDogrusal(kareler, 1, 0);
                EkleDogrusal(kareler, -1, 0);
                EkleDogrusal(kareler, 0, 1);
                EkleDogrusal(kareler, 0, -1);
                break;

            case 'v':
                for (int dx = -1; dx <= 1; dx++)
                    for (int dy = -1; dy <= 1; dy++)
                        if (!(dx == 0 && dy == 0))
                            EkleDogrusal(kareler, dx, dy);
                break;

            case 's':
                for (int dx = -1; dx <= 1; dx++)
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0) continue;
                        int x = Satir + dx;
                        int y = Sutun + dy;
                        if (x >= 0 && x < 8 && y >= 0 && y < 8)
                            kareler.Add((x, y));
                    }
                break;
        }

        return kareler;
    }

    private void EkleDogrusal(List<(int, int)> kareler, int dx, int dy)
    {
        int x = Satir + dx;
        int y = Sutun + dy;

        while (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            kareler.Add((x, y));
            x += dx;
            y += dy;
        }
    }
     public override bool Equals(object? obj)
     {
        
        if (obj is not Tas other)
            return false;

        return Tur == other.Tur &&
               Renk == other.Renk &&
               Satir == other.Satir &&
               Sutun == other.Sutun;
     }

     public override int GetHashCode()
     {
        return HashCode.Combine(Tur, Renk, Satir, Sutun);
     }

}
