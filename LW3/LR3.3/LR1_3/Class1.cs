public class Podorozh
{
    public string Misto { get; set; }
    public double Vidstan { get; set; }
    public int Dni { get; set; }
    public string Transport { get; set; }

    public Podorozh()
    {
        Misto = "Львів";
        Vidstan = 150;
        Dni = 1;
        Transport = "Автобус";
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
        return (Vidstan * tsinaZaKm) + (Dni * tsinaZaDen);
    }

    public double SerednyaTsinaKm()
    {
        return RozrakhVartist() / Vidstan;
    }

    // Тепер метод Info позначений як virtual
    public virtual string Info()
    {
        return $"Місто: {Misto}, Відстань: {Vidstan} км, Днів: {Dni}, Транспорт: {Transport}, Вартість: {RozrakhVartist()} грн";
    }

    // Перевантаження операторів
    public static Podorozh operator +(Podorozh a, Podorozh b)
    {
        return new Podorozh(
            a.Misto + "-" + b.Misto,         // нова назва (об’єднані міста)
            a.Vidstan + b.Vidstan,           // сумарна відстань
            a.Dni + b.Dni,                   // сумарні дні
            a.Transport                      // лишаємо транспорт від першої (можна інакше)
        );
    }

    public static bool operator >(Podorozh a, Podorozh b)
    {
        return a.RozrakhVartist() > b.RozrakhVartist();
    }

    public static bool operator <(Podorozh a, Podorozh b)
    {
        return a.RozrakhVartist() < b.RozrakhVartist();
    }

    public static bool operator ==(Podorozh a, Podorozh b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Misto == b.Misto && a.Transport == b.Transport;
    }

    public static bool operator !=(Podorozh a, Podorozh b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Podorozh other)
            return this == other;
        return false;
    }

    public static Podorozh operator ++(Podorozh a)
    {
        if (a == null) return a;
        a.Dni += 1;
        return a;
    }

    public static Podorozh operator --(Podorozh a)
    {
        if (a == null) return a;
        a.Dni = a.Dni > 1 ? a.Dni - 1 : 1;
        return a;
    }

    public override int GetHashCode()
    {
        return (Misto + Transport).GetHashCode();
    }
}
