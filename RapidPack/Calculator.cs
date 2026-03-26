using System;

namespace RapidPack;

public class KalkulatorPrzesylek
{
    private const double MaksymalnaWagaKg = 30;
    private const double CenaBazowa = 10;
    private const double CenaZaKilogram = 2;
    private const double DoplatkaEkspres = 15;
    private const double DoplatkaOstroznieSzklo = 10;
    private const double CenaPalety = 100;
    private const double WspolczynnikGabaryt = 0.50;
    private const double LimitGabarytu = 150;
    
    public static double ObliczCene(
        double wagaKg,
        double wysokoscCm,
        double szerokoscCm,
        double glębokoscCm,
        bool   czyEkspres,
        string typPrzesylki
        )
    {
        if (wagaKg > MaksymalnaWagaKg)
            throw new ArgumentException($"Paczka za ciężka! Maksymalna waga to {MaksymalnaWagaKg} kg.");
 
        if (wagaKg <= 0)
            throw new ArgumentException("Waga musi być większa od zera.");
 
        if (typPrzesylki == "Paleta")
        {
            double cenaPalety = CenaPalety;
            if (czyEkspres) cenaPalety += DoplatkaEkspres;
            return cenaPalety;
        }
 
        double cena = CenaBazowa + (wagaKg * CenaZaKilogram);
 
        double sumaWymiarow = wysokoscCm + szerokoscCm + glębokoscCm;
        if (sumaWymiarow > LimitGabarytu)
            cena *= (1 + WspolczynnikGabaryt);
 
        if (typPrzesylki == "Ostrożnie")
            cena += DoplatkaOstroznieSzklo;
 
        if (czyEkspres)
            cena += DoplatkaEkspres;
 
        return cena;
    }
}
