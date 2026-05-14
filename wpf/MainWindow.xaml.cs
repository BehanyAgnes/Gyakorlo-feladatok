using System.Windows;
using System.Windows.Controls;

namespace KeszletManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseHelper.AdatbazisLetrehozasa();
            TablaFrissitese();
        }

        private void TablaFrissitese()
        {
            TermekTabla.ItemsSource = DatabaseHelper.OsszeTermekLekerese();
        }

        private void Hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TermekDialog();
            dialog.Owner = this;

            if (dialog.ShowDialog() == true)
            {
                DatabaseHelper.TermekHozzaadasa(dialog.Termek);
                TablaFrissitese();
            }
        }

        private void Szerkesztes_Click(object sender, RoutedEventArgs e)
        {
            if (TermekTabla.SelectedItem is not Termek kivalasztott)
            {
                MessageBox.Show("Kérlek válassz ki egy terméket a szerkesztéshez!",
                    "Nincs kijelölés", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialog = new TermekDialog(kivalasztott);
            dialog.Owner = this;

            if (dialog.ShowDialog() == true)
            {
                DatabaseHelper.TermekFrissitese(dialog.Termek);
                TablaFrissitese();
            }
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (TermekTabla.SelectedItem is not Termek kivalasztott)
            {
                MessageBox.Show("Kérlek válassz ki egy terméket a törléshez!",
                    "Nincs kijelölés", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var eredmeny = MessageBox.Show(
                $"Biztosan törlöd ezt a terméket?\n\n{kivalasztott.Nev}",
                "Törlés megerősítése",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (eredmeny == MessageBoxResult.Yes)
            {
                DatabaseHelper.TermekTorlese(kivalasztott.Id);
                TablaFrissitese();
            }
        }
    }
}
