using System.Windows;

namespace KeszletManager
{
    public partial class TermekDialog : Window
    {
        public Termek Termek { get; private set; } = new Termek();

        // Hozzáadás mód
        public TermekDialog()
        {
            InitializeComponent();
            Title = "Új termék hozzáadása";
        }

        // Szerkesztés mód – betölti a meglévő adatokat
        public TermekDialog(Termek termek)
        {
            InitializeComponent();
            Title = "Termék szerkesztése";

            Termek = termek;
            NevMezo.Text = termek.Nev;
            ArMezo.Text = termek.Ar.ToString();
            MennyisegMezo.Text = termek.Mennyiseg.ToString();
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            // Validáció
            if (string.IsNullOrWhiteSpace(NevMezo.Text))
            {
                MessageBox.Show("A termék neve nem lehet üres!", "Hiba",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NevMezo.Focus();
                return;
            }

            if (!decimal.TryParse(ArMezo.Text, out decimal ar) || ar < 0)
            {
                MessageBox.Show("Kérlek érvényes árat adj meg (pl. 1990)!", "Hiba",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ArMezo.Focus();
                return;
            }

            if (!int.TryParse(MennyisegMezo.Text, out int mennyiseg) || mennyiseg < 0)
            {
                MessageBox.Show("Kérlek érvényes mennyiséget adj meg (egész szám)!", "Hiba",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                MennyisegMezo.Focus();
                return;
            }

            Termek.Nev = NevMezo.Text.Trim();
            Termek.Ar = ar;
            Termek.Mennyiseg = mennyiseg;

            DialogResult = true;
        }

        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
