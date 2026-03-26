using Xunit;
using RapidPack;

namespace RapidPack.Tests;

public class MainWindowTests
{
    
    private const double NormalnaWaga  = 10;
    private const double MalyWymiar   = 30;

    [Fact]
    public void ZaduzoKilogramow_RzucaBlad()
    {
        double zaduzoKg = 35;

        Assert.Throws<ArgumentException>(() =>
            KalkulatorPrzesylek.ObliczCene(zaduzoKg, MalyWymiar, MalyWymiar, MalyWymiar, false, "Standardowa")
        );
    }

    [Fact]
    public void DuzeWymiary_DoliczonaOplataGabarytowa()
    {
        double cena = KalkulatorPrzesylek.ObliczCene(10, 50, 50, 60, false, "Standardowa");

        Assert.Equal(45, cena);
    }

    [Fact]
    public void Paleta_StałaCena100Zl()
    {
        double cena = KalkulatorPrzesylek.ObliczCene(NormalnaWaga, MalyWymiar, MalyWymiar, MalyWymiar, false, "Paleta");

        Assert.Equal(100, cena);
    }

    [Fact]
    public void Ekspres_Dodaje15Zl()
    {
        double bezEkspresu = KalkulatorPrzesylek.ObliczCene(NormalnaWaga, MalyWymiar, MalyWymiar, MalyWymiar, false, "Standardowa");
        double zEkspresem  = KalkulatorPrzesylek.ObliczCene(NormalnaWaga, MalyWymiar, MalyWymiar, MalyWymiar, true,  "Standardowa");

        Assert.Equal(15, zEkspresem - bezEkspresu);
    }

    [Fact]
    public void Ostrozniie_Dodaje10Zl()
    {
        double standardowa = KalkulatorPrzesylek.ObliczCene(NormalnaWaga, MalyWymiar, MalyWymiar, MalyWymiar, false, "Standardowa");
        double szklo       = KalkulatorPrzesylek.ObliczCene(NormalnaWaga, MalyWymiar, MalyWymiar, MalyWymiar, false, "Ostrożnie");

        Assert.Equal(10, szklo - standardowa);
    }

    [Fact]
    public void PaletaZaHeavy_NadalRzucaBlad()
    {
        Assert.Throws<ArgumentException>(() =>
            KalkulatorPrzesylek.ObliczCene(35, MalyWymiar, MalyWymiar, MalyWymiar, false, "Paleta")
        );
    }

    [Fact]
    public void PodstawowaCena_JestPoprawna()
    {
        double cena = KalkulatorPrzesylek.ObliczCene(5, MalyWymiar, MalyWymiar, MalyWymiar, false, "Standardowa");

        Assert.Equal(20, cena);
    }
}