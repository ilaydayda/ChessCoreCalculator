using System;
using System.Collections.Generic;

public class TehditHesaplayici
{
    private Tahta tahta;

    public TehditHesaplayici(Tahta tahta)
    {
        this.tahta = tahta;
    }

    public Dictionary<Tas, bool> TehditDurumlariniHesapla()
    {
        Dictionary<Tas, bool> tehditDurumlari = new();

        foreach (Tas hedefTas in tahta.Taslar)
        {
            bool tehditAltinda = false;

            foreach (Tas kontrolTas in tahta.Taslar)
            {
                if (kontrolTas.Renk == hedefTas.Renk)
                    continue;

                List<(int, int)> tehditEttigi = kontrolTas.GetirTehditliKareler();

                foreach ((int x, int y) in tehditEttigi)
                {
                    if (x == hedefTas.Satir && y == hedefTas.Sutun)
                    {
                        tehditAltinda = true;
                        break;
                    }
                }

                if (tehditAltinda)
                    break;
            }

            tehditDurumlari[hedefTas] = tehditAltinda;
        }

        return tehditDurumlari;
    }
}
