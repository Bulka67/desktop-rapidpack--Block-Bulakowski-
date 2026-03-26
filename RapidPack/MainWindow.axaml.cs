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
        // === Block ===
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
        TekstBledu.Text      = $"⚠️ {wiadomosc}";
        PanelBledu.IsVisible = true;
    }
}