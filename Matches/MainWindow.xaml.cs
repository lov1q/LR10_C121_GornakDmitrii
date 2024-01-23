using Microsoft.Win32;
using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;
using LR10_C121_GornakDmitrii;
using System.Linq;
using TeamsLib;

namespace Matches
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Привязка списка заказов к DataGrid

            TeamsDataGrid.ItemsSource = ManagerStock.stock;
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
            SearchCB.ItemsSource = new Item[]
            {
                new Item {Name="Финал" },
                new Item {Name="Полуфинал" },
                new Item {Name="Четверть финал" },
            };
        }
        public class Item
        {
            public string Name { get; set; }
            public override string ToString() => $"{Name}";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void JsonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTeams_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранных значений из элементов управления
            string teamfirst = frsnameTextBox.Text;

            if (string.IsNullOrWhiteSpace(frsnameTextBox.Text))
            {
                MessageBox.Show("Введите название 1 команды!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (frsnameTextBox.Text.Length < 5)
            {
                MessageBox.Show("Название команды должно быть длинее 5 символов!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string teamsecond = secnameTextBox.Text;

            if (string.IsNullOrWhiteSpace(secnameTextBox.Text))
            {
                MessageBox.Show("Введите название 2 команды!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (secnameTextBox.Text.Length < 5)
            {
                MessageBox.Show("Название команды должно быть длинее 5 символов!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime? dateMatch = datematchDP.SelectedDate;  // Проверяем, что дата выбрана


            string typematch = typematchCB.Text;
            if (string.IsNullOrWhiteSpace(typematchCB.Text))
            {
                MessageBox.Show("Введите тип матча!", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string stadion = stadionCB.Text;
            if (string.IsNullOrWhiteSpace(stadionCB.Text))
            {
                MessageBox.Show("Введите какой стадион вы хотите!", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string typeStadion = tipstadionCB.Text;
            if (string.IsNullOrWhiteSpace(tipstadionCB.Text))
            {
                MessageBox.Show("Введите тип стадиона!", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            string resultmatch = resultmatchCB.Text;
            if (string.IsNullOrWhiteSpace(resultmatchCB.Text))
            {
                MessageBox.Show("Введите резульат матча для 1 команды!", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            // Создание нового матча
            var match = new Teams(teamfirst, teamsecond, dateMatch, typematch, stadion, typeStadion, resultmatchCB.Text);

            // Добавление матча в список
            ManagerStock.stock.Add(match);


            // Обновление источника данных для DataGrid
            TeamsDataGrid.ItemsSource = null;
            TeamsDataGrid.ItemsSource = ManagerStock.stock;

            // Очистка полей ввода
            ClearFields();
        }

        private void ClearFields()
        {
            typematchCB.SelectedItem = null;
            stadionCB.SelectedItem = null;
            frsnameTextBox.Clear();
            tipstadionCB.SelectedItem = null;
            secnameTextBox.Clear();
            datematchDP.SelectedDate = null;
            resultmatchCB.SelectedIndex = -1;
        }
        private void ClearFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            typematchCB.SelectedItem = null;
            stadionCB.SelectedItem = null;
            frsnameTextBox.Clear();
            tipstadionCB.SelectedItem = null;
            secnameTextBox.Clear();
            datematchDP.SelectedDate = null;
            resultmatchCB.SelectedIndex = -1;
        }

        private void XMLSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "json-файл (.json)|.json|Текстовые файлы (.txt)|.txt|Все файлы (.)|.";
            fileDialog.FilterIndex = 0;
            fileDialog.DefaultExt = "json";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            fileDialog.Title = "Сохранить в JSON";
            fileDialog.OverwritePrompt = true;

            if (fileDialog.ShowDialog() != true) return;
            ManagerStock.stock.STJ(fileDialog.FileName);
        }

        private void XMLOpen_Click(object sender, RoutedEventArgs e)
        {
            ManagerStock.stock.Clear();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FilterIndex = 0;
            fileDialog.DefaultExt = "json";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            fileDialog.Title = "Открытие JSON";

            if (fileDialog.ShowDialog() != true) return;
            ManagerStock.stock.AddRange(ManagerStock.stock.OFJ(fileDialog.FileName));
            TeamsDataGrid.ItemsSource = null;
            TeamsDataGrid.ItemsSource = ManagerStock.stock;
        }

        private void SearchB_Click(object sender, RoutedEventArgs e)
        {
            string searchCriteria = SearchCB.Text;
            if (string.IsNullOrWhiteSpace(SearchCB.Text))
            {
                MessageBox.Show("Введите значение для поиска!", "Error!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string searchValue = SearchCB.Text;

            // Произведите поиск и фильтрацию данных
            List<Teams> filteredTeams = ManagerStock.stock.Where(teams => teams.TypeMatch.Contains(searchValue)).ToList();

            // Отобразите отфильтрованные данные в DataGrid
            TeamsDataGrid.ItemsSource = filteredTeams;
        }


        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            ManagerStock.stock.Excel();
        }

        private void Word_Click(object sender, RoutedEventArgs e)
        {
            ManagerStock.stock.Word_Click();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Получение выделенного элемента из DataGrid
            var selectedMatch = TeamsDataGrid.SelectedItem as Teams;

            // Удаление элемента из списка заказов
            if (selectedMatch != null)
            {
                MessageBoxResult select = MessageBox.Show("Вы точно хотите удалить элемент?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (select == MessageBoxResult.Yes)
                {
                    ManagerStock.stock.Remove(selectedMatch);
                    TeamsDataGrid.ItemsSource = null; // Очистка ItemsSource
                    TeamsDataGrid.ItemsSource = ManagerStock.stock; // Установка списка заказов в ItemsSource
                }
            }
        }

        private void ViewAllProducts_Click(object sender, RoutedEventArgs e)
        {
            TeamsDataGrid.ItemsSource = ManagerStock.stock;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var edit = TeamsDataGrid.SelectedItem as Teams;
            if (edit != null)
            {
                EditWPF ed = new EditWPF(edit);
                ed.Show();
            }
        }
    }
}