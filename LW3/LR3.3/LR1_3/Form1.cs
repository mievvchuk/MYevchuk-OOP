//form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1_3
{
    public partial class Form1 : Form
    {
        private List<Podorozh> podorozhi = new List<Podorozh>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Misto", "Місто");
            dataGridView1.Columns.Add("Vidstan", "Відстань (км)");
            dataGridView1.Columns.Add("Dni", "Днів");
            dataGridView1.Columns.Add("Transport", "Транспорт"); // нова колонка
            dataGridView1.Columns.Add("Vartist", "Вартість");
            dataGridView1.Columns.Add("Serednya", "Середня ціна/км");
            dataGridView1.Columns.Add("TypTuru", "Тип туру");
            dataGridView1.Columns.Add("VartistProzhyvannya", "Вартість проживання");
            dataGridView1.Columns.Add("ZagalnaVartist", "Загальна вартість");

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Add("Misto", "Місто");
            dataGridView2.Columns.Add("Vidstan", "Відстань (км)");
            dataGridView2.Columns.Add("Dni", "Днів");
            dataGridView2.Columns.Add("Transport", "Транспорт");
            dataGridView2.Columns.Add("Vartist", "Вартість");
            dataGridView2.Columns.Add("Serednya", "Середня ціна/км");
            // Додаємо елементи в comboBox1 для вибору транспорту
            comboBox1.Items.AddRange(new string[] { "Автобус", "Поїзд", "Літак", "Авто" });
            comboBox1.SelectedIndex = 0; // за замовчуванням "Автобус"
            // Додаємо елементи в comboBox2 для вибору типу туру
            comboBox2.SelectedIndex = 0; // за замовчуванням "Екскурсія"
            textBox1.KeyPress += TextBox1_KeyPress;
            textBox2.KeyPress += TextBox2_KeyPress;
            textBox3.KeyPress += TextBox3_KeyPress;
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // забороняємо введення
                MessageBox.Show("Тільки літери та пробіли дозволені!");
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Тільки цифри та крапка дозволені!");
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Тільки цифри дозволені!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string misto = textBox1.Text;
                double vidstan = double.Parse(textBox2.Text);
                int dni = int.Parse(textBox3.Text);
                string transport = comboBox1.SelectedItem.ToString(); // вибір транспорту
                string typTuru = comboBox2.SelectedItem.ToString(); // вибір типу подорожі
                double vartistProzhyvannya = 1000; // можна змінити на введення через текстове поле або комбобокс

                // Створюємо відповідний об'єкт в залежності від типу подорожі
                Podorozh p;

                switch (typTuru)
                {
                    case "Туристична":
                        p = new TurystychnaPodorozh(misto, vidstan, dni, transport, typTuru, vartistProzhyvannya);
                        break;

                    case "Бізнес":
                        p = new BusinessPodorozh(misto, vidstan, dni, transport, "ACME Corp", "Переговори");
                        break;

                    case "Екстремальна":
                        p = new ExtremePodorozh(misto, vidstan, dni, transport, "Високий");
                        break;

                    case "Довготривала":
                        p = new LongTermPodorozh(misto, vidstan, dni, transport, 6);
                        break;

                    default:
                        throw new Exception("Невідомий тип подорожі");
                }

                podorozhi.Add(p);

                // Додаємо дані в DataGridView
                if (p is TurystychnaPodorozh turystychnaTrip)
                {
                    dataGridView1.Rows.Add(
                        turystychnaTrip.Misto,
                        turystychnaTrip.Vidstan,
                        turystychnaTrip.Dni,
                        turystychnaTrip.Transport,
                        turystychnaTrip.RozrakhVartist(),
                        turystychnaTrip.SerednyaTsinaKm().ToString("F2"),
                        turystychnaTrip.TypTuru,
                        turystychnaTrip.VartistProzhyvannya,
                        turystychnaTrip.RozrakhVartistPodorozh()
                    );
                }
                else
                {
                    // Для інших типів подорожей, де немає методу RozrakhVartistPodorozh
                    dataGridView1.Rows.Add(
                        p.Misto,
                        p.Vidstan,
                        p.Dni,
                        p.Transport,
                        p.RozrakhVartist(),
                        p.SerednyaTsinaKm().ToString("F2"),
                        typTuru,
                        vartistProzhyvannya,
                        "N/A"
                    );
                }

                // Очищаємо текстові поля після додавання подорожі
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch
            {
                MessageBox.Show("Будь ласка, введіть коректні дані!");
            }
        }
        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            podorozhi.Clear();
            dataGridView1.Rows.Clear();
            MessageBox.Show("Створено новий список подорожей!");
        }
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстові файли|*.txt";
            saveFileDialog.Title = "Збереження даних";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var p in podorozhi)
                    {
                        sw.WriteLine($"{p.Misto};{p.Vidstan};{p.Dni};{p.Transport};{p.RozrakhVartist()};{p.SerednyaTsinaKm():F2}");
                    }
                }
                MessageBox.Show("Дані збережено!");
            }
        }
        private void вивестиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстові файли|*.txt";
            openFileDialog.Title = "Відкрити файл з даними";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                podorozhi.Clear();
                dataGridView1.Rows.Clear();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');

                        // Перевіряємо, що в рядку є хоча б 3 колонки (misto, vidstan, dni)
                        if (parts.Length >= 3)
                        {
                            string misto = parts[0];
                            double vidstan = double.Parse(parts[1]);
                            int dni = int.Parse(parts[2]);

                            // Якщо transport є у файлі, беремо його, інакше дефолт
                            string transport = parts.Length > 3 ? parts[3] : "Не вказано";

                            Podorozh p = new Podorozh(misto, vidstan, dni, transport);
                            podorozhi.Add(p);

                            // Додаємо в DataGridView, не забуваємо колонку Transport
                            dataGridView1.Rows.Add(
                                p.Misto,
                                p.Vidstan,
                                p.Dni,
                                p.Transport,
                                p.RozrakhVartist(),
                                p.SerednyaTsinaKm().ToString("F2")
                            );
                        }
                    }
                }
                MessageBox.Show("Дані завантажено!");
            }
        }
        private void пошукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 formSearch = new Form2(podorozhi);

            if (formSearch.ShowDialog() == DialogResult.OK)
            {
                dataGridView2.Rows.Clear();

                foreach (var p in formSearch.SearchResults)
                {
                    dataGridView2.Rows.Add(
                        p.Misto,
                        p.Vidstan,
                        p.Dni,
                        p.Transport,            
                        p.RozrakhVartist(),
                        p.SerednyaTsinaKm().ToString("F2")
                    );
                }
            }
        }
        private void RefreshRow(int index)
        {
            if (index < 0 || index >= podorozhi.Count) return;

            Podorozh p = podorozhi[index];
            dataGridView1.Rows[index].Cells[0].Value = p.Misto;
            dataGridView1.Rows[index].Cells[1].Value = p.Vidstan;
            dataGridView1.Rows[index].Cells[2].Value = p.Dni;
            dataGridView1.Rows[index].Cells[3].Value = p.Transport;
            dataGridView1.Rows[index].Cells[4].Value = p.RozrakhVartist();
            dataGridView1.Rows[index].Cells[5].Value = p.SerednyaTsinaKm().ToString("F2");
        }

        private void обєднатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 2)
            {
                // Беремо 2 вибрані рядки
                int index1 = dataGridView1.SelectedRows[0].Index;
                int index2 = dataGridView1.SelectedRows[1].Index;

                Podorozh p1 = podorozhi[index1];
                Podorozh p2 = podorozhi[index2];

                // Використовуємо оператор +
                Podorozh combined = p1 + p2;

                // Додаємо нову подорож у список і таблицю
                podorozhi.Add(combined);
                dataGridView1.Rows.Add(
                    combined.Misto,
                    combined.Vidstan,
                    combined.Dni,
                    combined.Transport,
                    combined.RozrakhVartist(),
                    combined.SerednyaTsinaKm().ToString("F2")
                );

                MessageBox.Show("Подорожі успішно об’єднано!");
            }
            else
            {
                MessageBox.Show("Виберіть рівно 2 подорожі для об’єднання!");
            }
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 2)
            {
                int index1 = dataGridView1.SelectedRows[0].Index;
                int index2 = dataGridView1.SelectedRows[1].Index;

                Podorozh p1 = podorozhi[index1];
                Podorozh p2 = podorozhi[index2];

                // Використовуємо оператори > і <
                if (p1 > p2)
                    MessageBox.Show($"{p1.Misto} дорожча за {p2.Misto}");
                else if (p1 < p2)
                    MessageBox.Show($"{p2.Misto} дорожча за {p1.Misto}");
                else
                    MessageBox.Show("Подорожі мають однакову вартість!");
            }
            else
            {
                MessageBox.Show("Виберіть рівно 2 подорожі для порівняння!");
            }
        }
        private void перевіритиРівністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 2)
            {
                int index1 = dataGridView1.SelectedRows[0].Index;
                int index2 = dataGridView1.SelectedRows[1].Index;

                Podorozh p1 = podorozhi[index1];
                Podorozh p2 = podorozhi[index2];

                // Використовуємо оператор == і !=
                if (p1 == p2)
                    MessageBox.Show("Подорожі однакові (місто + транспорт)");
                else
                    MessageBox.Show("Подорожі різні");
            }
            else
            {
                MessageBox.Show("Виберіть рівно 2 подорожі для перевірки!");
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                index = dataGridView1.SelectedRows[0].Index;
            else if (dataGridView1.SelectedCells.Count > 0)
                index = dataGridView1.SelectedCells[0].RowIndex;

            if (index >= 0 && index < podorozhi.Count)
            {
                podorozhi[index]++; // мутуємо об’єкт
                RefreshRow(index);   // оновлюємо таблицю
            }
            else
            {
                MessageBox.Show("Виберіть одну подорож!");
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                index = dataGridView1.SelectedRows[0].Index;
            else if (dataGridView1.SelectedCells.Count > 0)
                index = dataGridView1.SelectedCells[0].RowIndex;

            if (index >= 0 && index < podorozhi.Count)
            {
                podorozhi[index]--; // мутуємо об’єкт
                RefreshRow(index);   // оновлюємо таблицю
            }
            else
            {
                MessageBox.Show("Виберіть одну подорож!");
            }
        }
        private void buttonChangeType_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;

                // Отримуємо поточну подорож
                Podorozh selectedTrip = podorozhi[index];  // Замість TurystychnaPodorozh використовуємо Podorozh для всіх типів

                if (selectedTrip != null)
                {
                    // Перевіряємо, чи вибрано значення у comboBox2
                    if (comboBox2.SelectedItem != null)
                    {
                        string newType = comboBox2.SelectedItem.ToString(); // Вибране значення з комбобокса

                        // Зміна типу туру залежно від того, який тип подорожі
                        if (selectedTrip is TurystychnaPodorozh turystychnaTrip)
                        {
                            turystychnaTrip.ZminytyTypTuru(newType);
                        }
                        else if (selectedTrip is BusinessPodorozh businessTrip)
                        {
                            businessTrip.ZminytyTypTuru(newType);  // Якщо є відповідний метод в класі BusinessPodorozh
                        }
                        else if (selectedTrip is ExtremePodorozh extremeTrip)
                        {
                            extremeTrip.ZminytyTypTuru(newType);  // Якщо є відповідний метод в класі ExtremePodorozh
                        }
                        else if (selectedTrip is LongTermPodorozh longTermTrip)
                        {
                            longTermTrip.ZminytyTypTuru(newType);  // Якщо є відповідний метод в класі LongTermPodorozh
                        }

                        // Оновлюємо таблицю після зміни типу
                        dataGridView1.Rows[index].Cells["TypTuru"].Value = newType;
                        MessageBox.Show("Тип туру змінено!");
                    }
                    else
                    {
                        MessageBox.Show("Будь ласка, виберіть тип туру!");
                    }
                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть подорож для зміни типу!");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть одну подорож для зміни типу!");
            }
        }
    }
}