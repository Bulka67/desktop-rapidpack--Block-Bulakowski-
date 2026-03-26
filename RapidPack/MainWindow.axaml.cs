using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RapidPack;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void PrzyciskWycen_Kliknieto(object nadawca, RoutedEventArgs zdarzenie)
    {
        PanelWyniku.IsVisible = false;
        PanelBledu.IsVisible  = false;

        string tekstWagi      = PoleTekstoweWaga.Text      ?? "";
        string tekstWysokosci = PoleTekstoweWysokosc.Text  ?? "";
        string tekstSzerokosci = PoleTekstoweStawanosc.Text ?? "";
        string tekstGlebokosci = PoleTekstoweGleBokosc.Text ?? "";

        if (!double.TryParse(tekstWagi.Replace(',', '.'),       out double waga)      ||
            !double.TryParse(tekstWysokosci.Replace(',', '.'),  out double wysokosc)  ||
            !double.TryParse(tekstSzerokosci.Replace(',', '.'), out double szerokosc) ||
            !double.TryParse(tekstGlebokosci.Replace(',', '.'), out double gleBokosc))
        {
            PokazBlad("Wprowadź poprawne liczby we wszystkich polach.");
            return;
        }

        bool   czyEkspres   = CheckboxEkspres.IsChecked == true;
        string typPrzesylki = (ListaTypowPrzesylki.SelectedItem as ComboBoxItem)?.Content?.ToString()
                              ?? "Standardowa";

        try
        {
            double cena = KalkulatorPrzesylek.ObliczCene(waga, wysokosc, szerokosc, gleBokosc, czyEkspres, typPrzesylki);
            PokazWynik(waga, wysokosc, szerokosc, gleBokosc, czyEkspres, typPrzesylki, cena);
        }
        catch (ArgumentException blad)
        {
            PokazBlad(blad.Message);
        }
    }

    private void PokazWynik(double waga, double wysokosc, double szerokosc, double gleBokosc,
                            bool czyEkspres, string typPrzesylki, double cena)
    {
        TekstWyniku.Text =
            $"✅ WYCENA\n" +
            $"─────────────────\n" +
            $"Waga:      {waga} kg\n" +
            $"Wymiary:   {wysokosc}×{szerokosc}×{gleBokosc} cm\n" +
            $"Typ:       {typPrzesylki}\n" +
            $"Ekspres:   {(czyEkspres ? "Tak" : "Nie")}\n" +
            $"─────────────────\n" +
            $"CENA: {cena:F2} zł";

        PanelWyniku.IsVisible = true;
    }

    private void PokazBlad(string wiadomosc)
    {
        TekstBledu.Text       = $"⚠️ {wiadomosc}";
        PanelBledu.IsVisible  = true;
    }
}