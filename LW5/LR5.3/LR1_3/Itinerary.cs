// Itinerary.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace LR1_3
{
    // Це об'єкт, який належить конкретній подорожі.
    public class Itinerary
    {
        // Список житла — повна власність Itinerary (composition)
        private readonly List<Accommodation> accommodations = new List<Accommodation>();

        public IReadOnlyList<Accommodation> Accommodations => accommodations.AsReadOnly();

        public void AddAccommodation(Accommodation acc)
        {
            if (acc == null) throw new ArgumentNullException(nameof(acc));
            accommodations.Add(acc);
        }
        public bool RemoveAccommodation(Accommodation acc) => accommodations.Remove(acc);

        public double TotalAccommodationCost() => accommodations.Sum(a => a.TotalPrice());

        public override string ToString()
        {
            if (!accommodations.Any()) return "No accommodations.";
            return string.Join(Environment.NewLine, accommodations.Select(a => a.ToString()));
        }
    }
}
