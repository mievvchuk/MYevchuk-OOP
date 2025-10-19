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
            // Додаємо колонки
            dataGridView1.Columns.Add("Misto", "Місто");
            dataGridView1.Columns.Add("Vidstan", "Відстань (км)");
            dataGridView1.Columns.Add("Dni", "Днів");
            dataGridView1.Columns.Add("Transport", "Транспорт"); // нова колонка
            dataGridView1.Columns.Add("Vartist", "Вартість");
            dataGridView1.Columns.Add("Serednya", "Середня ціна/км");

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Add("Misto", "Місто");
            dataGridView2.Columns.Add("Vidstan", "Відстань (км)");
            dataGridView2.Columns.Add("Dni", "Днів");
            dataGridView2.Columns.Add("Transport", "Транспорт");
            dataGridView2.Columns.Add("Vartist", "Вартість");
            dataGridView2.Columns.Add("Serednya", "Середня ціна/км");

            // Заповнюємо ComboBox транспортом
            comboBox1.Items.AddRange(new string[] { "Автобус", "Поїзд", "Літак", "Авто" });
            comboBox1.SelectedIndex = 0; // за замовчуванням "Автобус"
            textBox1.KeyPress += TextBox1_KeyPress;
            textBox2.KeyPress += TextBox2_KeyPress;
            textBox3.KeyPress += TextBox3_KeyPress;
        }
        // Місто — лише літери та пробіл
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // забороняємо введення
                MessageBox.Show("Тільки літери та пробіли дозволені!");
            }
        }

        // Відстань — лише цифри і крапка
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Тільки цифри та крапка дозволені!");
            }
            // Не більше однієї крапки
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // Дні — тільки цифри
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
                string transport = comboBox1.SelectedItem.ToString(); // додаємо транспорт

                Podorozh p = new Podorozh(misto, vidstan, dni, transport); // 4 аргументи
                podorozhi.Add(p);

                dataGridView1.Rows.Add(
                    p.Misto,
                    p.Vidstan,
                    p.Dni,
                    p.Transport, // нова колонка
                    p.RozrakhVartist(),
                    p.SerednyaTsinaKm().ToString("F2")
                );

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

    }
}