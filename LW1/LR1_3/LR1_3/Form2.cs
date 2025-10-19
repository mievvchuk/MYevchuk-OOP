//form2search
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LR1_3
{
    public partial class Form2 : Form
    {
        private List<Podorozh> _list;
        public List<Podorozh> SearchResults { get; private set; }

        public Form2(List<Podorozh> list)
        {
            InitializeComponent();
            _list = list;

            // Заповнення combobox1 критеріями пошуку
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Місто");
            comboBox1.Items.Add("Транспорт");
            comboBox1.Items.Add("Дні");
            comboBox1.Items.Add("Місто + Транспорт + Дні"); // для комбінованого пошуку
            comboBox1.SelectedIndex = 0; // за замовчуванням перший елемент

            // Заповнення combobox2 транспортом
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Будь-який"); // для всіх
            foreach (var t in _list.Select(p => p.Transport).Distinct())
            {
                comboBox2.Items.Add(t);
            }
            comboBox2.SelectedIndex = 0; // за замовчуванням “Будь-який”
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string crit = comboBox1.SelectedItem?.ToString(); // критерій пошуку
            string mistoText = textBox1.Text.Trim();
            string transportText = comboBox2.SelectedItem?.ToString();
            string dniText = textBox2.Text.Trim();

            var results = _list.AsEnumerable();

            if (!string.IsNullOrEmpty(crit))
            {
                switch (crit)
                {
                    case "Місто":
                        if (string.IsNullOrEmpty(mistoText))
                        {
                            MessageBox.Show("Будь ласка, введіть місто для пошуку!");
                            return;
                        }
                        results = results.Where(p => p.Misto.IndexOf(mistoText, StringComparison.OrdinalIgnoreCase) >= 0);
                        break;

                    case "Транспорт":
                        if (string.IsNullOrEmpty(mistoText))
                        {
                            MessageBox.Show("Будь ласка, введіть транспорт для пошуку!");
                            return;
                        }
                        results = results.Where(p => p.Transport.IndexOf(mistoText, StringComparison.OrdinalIgnoreCase) >= 0);
                        break;

                    case "Дні":
                        if (string.IsNullOrEmpty(dniText))
                        {
                            MessageBox.Show("Будь ласка, введіть кількість днів для пошуку!");
                            return;
                        }
                        if (!int.TryParse(dniText, out int dni))
                        {
                            MessageBox.Show("Кількість днів повинна бути числом!");
                            return;
                        }
                        results = results.Where(p => p.Dni == dni);
                        break;

                    case "Місто + Транспорт + Дні":
                        if (string.IsNullOrEmpty(mistoText) || string.IsNullOrEmpty(transportText) || string.IsNullOrEmpty(dniText))
                        {
                            MessageBox.Show("Будь ласка, заповніть усі поля для комбінованого пошуку!");
                            return;
                        }
                        if (!int.TryParse(dniText, out int dniCombined))
                        {
                            MessageBox.Show("Кількість днів повинна бути числом!");
                            return;
                        }
                        results = results.Where(p =>
                            p.Misto.IndexOf(mistoText, StringComparison.OrdinalIgnoreCase) >= 0 &&
                            p.Transport.Equals(transportText, StringComparison.OrdinalIgnoreCase) &&
                            p.Dni == dniCombined);
                        break;
                }
            }

            var finalResults = results.ToList();

            if (finalResults.Count == 0)
            {
                MessageBox.Show("Нічого не знайдено!");
                return;
            }

            double totalCost = finalResults.Sum(p => p.RozrakhVartist());
            double avgDays = finalResults.Average(p => p.Dni);
            double minDistance = finalResults.Min(p => p.Vidstan);
            double maxDistance = finalResults.Max(p => p.Vidstan);

            MessageBox.Show(
                $"Знайдено {finalResults.Count} подорожей\n" +
                $"Сумарна вартість: {totalCost}\n" +
                $"Середня кількість днів: {avgDays:F1}\n" +
                $"Відстань: від {minDistance} до {maxDistance} км"
            );

            SearchResults = finalResults;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
