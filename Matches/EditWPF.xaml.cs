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
        public EditWPF(Teams teams, Stock stock)
        {

            InitializeComponent();
            typematchCB.ItemsSource = new Item[]
            {
                new Item {Name="Финал" },
                new Item {Name="Полуфинал" },
                new Item {Name="Четверть финал" },
            };
            stadionCB.ItemsSource = new Item[]
            {
                new Item {Name="Камп Ноу" },
                new Item {Name="Соккер Сити" },
                new Item {Name="Олимпийский" },
            };
            tipstadionCB.ItemsSource = new Item[]
            {
                new Item {Name="Открытый" },
                new Item {Name="Закрытый" },
            };
            resultmatchCB.ItemsSource = new Item[]
            {
                new Item {Name="Победа" },
                new Item {Name="Поражение" },
                new Item {Name="Ничья" },
            };
        }
        public class Item
        {
            public string Name { get; set; }
            public override string ToString() => $"{Name}";
        }
    }
}
