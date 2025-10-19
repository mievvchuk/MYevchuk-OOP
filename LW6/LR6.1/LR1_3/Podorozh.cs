//Podorozh.cs
using LR1_3;
using System;
using static LR1_3.TravelAgency;
public class Podorozh : IPodorozh
{
    public string Misto { get; set; }
    public double Vidstan { get; set; }
    public int Dni { get; set; }
    public string Transport { get; set; }
    private readonly Itinerary itinerary = new Itinerary();
    public Itinerary Itinerary => itinerary;
    
    /*3) Подія на стандартному делегаті Action<T> — «додали житло».
    На неї зручно підписатися з форми лямбдою.*/
    public event Action<Accommodation> AccommodationAdded;

    // Помічник для додавання житла
    public void AddAccommodation(string hotelName, int nights, double pricePerNight)
    {
        var acc = new Accommodation(hotelName, nights, pricePerNight);
        itinerary.AddAccommodation(acc);

        // підняти подію
        AccommodationAdded?.Invoke(acc);
    }
    public virtual string Info()
    {
        return $"Місто: {Misto}, Відстань: {Vidstan} км, Дні: {Dni}, Транспорт: {Transport}, Вартість: {RozrakhVartist():0.##} грн";
    }
    public Podorozh(string misto, double vidstan, int dni, string transport)
    {
        Misto = misto;
        Vidstan = vidstan;
        Dni = dni;
        Transport = transport;
    }

    public double RozrakhVartist()
    {
        double tsinaZaKm = 5;
        double tsinaZaDen = 200;
        double v = (Vidstan * tsinaZaKm) + (Dni * tsinaZaDen);
        return v;
    }

    public double SerednyaTsinaKm()
    {
        double s = RozrakhVartist() / Vidstan;
        return s;
    }

    public double TotalCostWithAccommodation()
    {
        double baseCost = 0;
        try
        {
            var m = this.GetType().GetMethod("RozrakhVartistPodorozh") ?? this.GetType().GetMethod("RozrakhVartist");
            if (m != null) baseCost = Convert.ToDouble(m.Invoke(this, null));
        }
        catch { /* ignore */ }

        double accom = itinerary.TotalAccommodationCost();
        double total = baseCost + accom;
        AppLog.Msg($"[Розрахунок] Разом (з житлом) '{Misto}': база {baseCost:0.##} + житло {accom:0.##} = {total:0.##} грн");
        return total;
    }

    // Оператори:
    public static Podorozh operator +(Podorozh a, Podorozh b)
    {
        var res = new Podorozh(
            a.Misto + "-" + b.Misto,
            a.Vidstan + b.Vidstan,
            a.Dni + b.Dni,
            a.Transport
        );
        AppLog.Msg($"[Оператор '+'] Об'єднання '{a.Misto}' + '{b.Misto}' → '{res.Misto}' ({res.Vidstan} км, {res.Dni} дн.)");
        return res;
    }

    public static bool operator >(Podorozh a, Podorozh b)
    {
        bool r = a.RozrakhVartist() > b.RozrakhVartist();
        AppLog.Msg($"[Оператор '>'] '{a.Misto}' {(r ? ">" : "<=")} '{b.Misto}' за вартістю");
        return r;
    }
    public static bool operator <(Podorozh a, Podorozh b)
    {
        bool r = a.RozrakhVartist() < b.RozrakhVartist();
        AppLog.Msg($"[Оператор '<'] '{a.Misto}' {(r ? "<" : ">=")} '{b.Misto}' за вартістю");
        return r;
    }

    public static bool operator ==(Podorozh a, Podorozh b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) { AppLog.Msg("[Оператор '=='] null == null → true"); return true; }
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) { AppLog.Msg("[Оператор '=='] один null → false"); return false; }

        bool eq = a.Misto == b.Misto && a.Transport == b.Transport;
        AppLog.Msg($"[Оператор '=='] '{a.Misto}/{a.Transport}' {(eq ? "==" : "!=")} '{b.Misto}/{b.Transport}'");
        return eq;
    }
    public static bool operator !=(Podorozh a, Podorozh b)
    {
        bool ne = !(a == b);
        // тут лог уже зроблено в '=='
        return ne;
    }

    public static Podorozh operator ++(Podorozh a)
    {
        if (a == null) return a;
        a.Dni += 1;
        AppLog.Msg($"[Оператор '++'] '{a.Misto}': дні → {a.Dni}");
        return a;
    }

    public static Podorozh operator --(Podorozh a)
    {
        if (a == null) return a;
        int old = a.Dni;
        a.Dni = a.Dni > 1 ? a.Dni - 1 : 1;
        AppLog.Msg($"[Оператор '--'] '{a.Misto}': дні {old} → {a.Dni}");
        return a;
    }
    public override int GetHashCode()
    {
        return (Misto + Transport).GetHashCode();
    }
}
