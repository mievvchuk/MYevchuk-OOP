using System;

namespace LR1_3
{
    public class Accommodation
    {
        public string Name { get; private set; }
        public int Nights { get; private set; }
        public double PricePerNight { get; private set; }

        public Accommodation(string name, int nights, double pricePerNight)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
            if (nights < 1) throw new ArgumentOutOfRangeException(nameof(nights));
            if (pricePerNight < 0) throw new ArgumentOutOfRangeException(nameof(pricePerNight));

            Name = name;
            Nights = nights;
            PricePerNight = pricePerNight;
        }

        public double TotalPrice() => Nights * PricePerNight;

        public override string ToString()
        {
            return $"{Name} — {Nights} night(s), {TotalPrice():0.##} грн ({PricePerNight:0.##}/night)";
        }
    }
}
