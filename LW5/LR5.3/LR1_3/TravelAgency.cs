using System;
using System.Collections.Generic;
using System.Linq;

namespace LR1_3
{
    // Аггрегація: агентство зберігає список подорожей, але подорож може існувати поза агентством.
    public class TravelAgency
    {
        private readonly List<Podorozh> trips = new List<Podorozh>();

        public string Name { get; set; }

        public TravelAgency(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Agency" : name;
        }

        public IReadOnlyList<Podorozh> Trips => trips.AsReadOnly();

        public void AddTrip(Podorozh trip)
        {
            if (trip == null) throw new ArgumentNullException(nameof(trip));
            if (!trips.Contains(trip))
                trips.Add(trip);
        }

        public bool RemoveTrip(Podorozh trip) => trips.Remove(trip);

        public IEnumerable<Podorozh> GetTripsByCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) return Enumerable.Empty<Podorozh>();
            return trips.Where(t => t.Misto?.IndexOf(city, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public double TotalAgencyRevenueEstimate()
        {
            // Оцінка: сумарна вартість усіх подорожей (якщо класи Podorozh мають метод розрахунку вартості)
            double sum = 0;
            foreach (var t in trips)
            {
                try
                {
                    // Ми робимо best-effort — якщо у Podorozh є RozrakhVartistPodorozh або RozrakhVartist — використовуємо
                    var method = t.GetType().GetMethod("RozrakhVartistPodorozh");
                    if (method != null)
                    {
                        sum += Convert.ToDouble(method.Invoke(t, null));
                        continue;
                    }
                    method = t.GetType().GetMethod("RozrakhVartist");
                    if (method != null)
                        sum += Convert.ToDouble(method.Invoke(t, null));
                }
                catch
                {
                    // мовчимо про помилки — не зупиняємо виконання
                }
            }
            return sum;
        }
    }
}
