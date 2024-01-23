using LR10_C121_GornakDmitrii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Matches.MainWindow;

namespace Matches
{
    /// <summary>
    /// Логика взаимодействия для EditWPF.xaml
    /// </summary>
    public partial class EditWPF : Window
    {
        public EditWPF(Teams team)
        {

            InitializeComponent();
            TypeMatch.ItemsSource = new Item[]
            {
                new Item {Name="Финал" },
                new Item {Name="Полуфинал" },
                new Item {Name="Четверть финал" },
            };
            Stadion.ItemsSource = new Item[]
            {
                new Item {Name="Камп Ноу" },
                new Item {Name="Соккер Сити" },
                new Item {Name="Олимпийский" },
            };
            TypeStadion.ItemsSource = new Item[]
            {
                new Item {Name="Открытый" },
                new Item {Name="Закрытый" },
            };
            Result.ItemsSource = new Item[]
            {
                new Item {Name="Победа" },
                new Item {Name="Поражение" },
                new Item {Name="Ничья" },
            };
            this.teams = team;
            DataContext = teams;
        }
        private Teams teams { get; set; }
        public class Item
        {
            public string Name { get; set; }
            public override string ToString() => $"{Name}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
