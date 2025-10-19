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
            {
                trips.Add(trip);
                AppLog.Msg($"[Агрегація] Агенція '{Name}' отримала подорож: {trip.Misto} ({trip.Dni} дн., {trip.Transport})");
            }
        }

        public bool RemoveTrip(Podorozh trip)
        {
            bool ok = trips.Remove(trip);
            if (ok) AppLog.Msg($"[Агрегація] З агенції '{Name}' прибрано подорож: {trip?.Misto}");
            return ok;
        }

        public double TotalAgencyRevenueEstimate(CostStrategy overrideStrategy = null)
        {
            var strategy = overrideStrategy ?? RevenueStrategy ?? TripDelegates.BaseCost;
            double sum = 0;
            foreach (var t in trips)
            {
                try { sum += strategy(t); }
                catch
                {
                    try
                    {
                        var m = t.GetType().GetMethod("RozrakhVartistPodorozh") ?? t.GetType().GetMethod("RozrakhVartist");
                        if (m != null) sum += Convert.ToDouble(m.Invoke(t, null));
                    }
                    catch { }
                }
            }
            AppLog.Msg($"[Агрегація] Оцінка доходу агенції '{Name}': {sum:0.##} грн (за стратегією: {strategy.Method.Name})");
            return sum;
        }


        public IEnumerable<Podorozh> GetTripsByCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) return Enumerable.Empty<Podorozh>();
            return trips.Where(t => t.Misto?.IndexOf(city, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public CostStrategy RevenueStrategy { get; set; } = TripDelegates.BaseCost;

        
        public static class AppLog
        {
            public static System.Action<string> Write;

            public static void Msg(string message)
                => Write?.Invoke(message);
        }
    }
}
