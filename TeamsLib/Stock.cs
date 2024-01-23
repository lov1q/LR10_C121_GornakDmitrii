using LR10_C121_GornakDmitrii;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LR10_C121_GornakDmitrii
{
    public class Stock : List<Teams>
    {
        public void Word_Click()
        {
            // Создаем экземпляр приложения Word
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;

            // Создаем новый документ Word
            var document = wordApp.Documents.Add();

            // Добавляем параграф с заголовком
            var headerParagraph = document.Content.Paragraphs.Add();
            headerParagraph.Range.Text = "Соревнования";
            headerParagraph.Range.Font.Size = 16;
            headerParagraph.Range.Font.Bold = 1;
            headerParagraph.Range.InsertParagraphAfter();

            // Добавляем таблицу с данными матчей
            var table = document.Tables.Add(document.Content, this.Count + 1, 8);
            table.Borders.Enable = 1;

            // Заполняем заголовки столбцов
            table.Cell(1, 1).Range.Text = "Название 1 команды";
            table.Cell(1, 2).Range.Text = "Название 2 команды";
            table.Cell(1, 3).Range.Text = "Дата матча";
            table.Cell(1, 4).Range.Text = "Тип матча";
            table.Cell(1, 5).Range.Text = "Стадион";
            table.Cell(1, 6).Range.Text = "Тип стадиона";
            table.Cell(1, 7).Range.Text = "Очки 1 команды";
            table.Cell(1, 8).Range.Text = "Очки 2 команды";

            // Заполняем данные из списка матчей
            for (int row = 2; row <= this.Count + 1; row++)
            {
                table.Cell(row, 1).Range.Text = this[row - 2].Teamfirst;
                table.Cell(row, 2).Range.Text = this[row - 2].Teamsecond;
                table.Cell(row, 3).Range.Text = this[row - 2].DateMatch.ToString();
                table.Cell(row, 4).Range.Text = this[row - 2].TypeMatch;
                table.Cell(row, 5).Range.Text = this[row - 2].Stadion.ToString();
                table.Cell(row, 6).Range.Text = this[row - 2].TypeStadion.ToString();
                table.Cell(row, 7).Range.Text = this[row - 2].TeamfirstPoints.ToString();
                table.Cell(row, 8).Range.Text = this[row - 2].TeamsecondPoints.ToString();
            }
        }
        public void STJ(string filename)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            File.WriteAllText(filename, JsonSerializer.Serialize(this, options));
        }
        public Stock OFJ(string filename)
        {
            return JsonSerializer.Deserialize<Stock>(File.ReadAllText(filename));
        }

        public void Excel()
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            // Создаем новую книгу Excel
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

            // Добавляем заголовки столбцов

            worksheet.Cells[1, 1] = "Supplier";
            worksheet.Cells[1, 2] = "Buyer";
            worksheet.Cells[1, 3] = "Product";
            worksheet.Cells[1, 4] = "Delivery Method";
            worksheet.Cells[1, 5] = "Quantity";
            worksheet.Cells[1, 6] = "Price";
            worksheet.Cells[1, 7] = "Total Cost";

            // Заполняем данные из списка заказов
            for (int i = 0; i < this.Count; i++)
            {
                int row = i + 2;
                worksheet.Cells[row, 1] = this[i].Teamfirst;
                worksheet.Cells[row, 2] = this[i].Teamsecond;
                worksheet.Cells[row, 3] = this[i].DateMatch.ToString();
                worksheet.Cells[row, 4] = this[i].TypeMatch;
                worksheet.Cells[row, 5] = this[i].Stadion.ToString();
                worksheet.Cells[row, 6] = this[i].TypeStadion.ToString();
                worksheet.Cells[row, 7] = this[i].TeamfirstPoints.ToString();
                worksheet.Cells[row, 8] = this[i].TeamsecondPoints.ToString();
            }
        }
    }

}