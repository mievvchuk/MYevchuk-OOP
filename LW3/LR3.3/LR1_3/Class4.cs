public class ExtremePodorozh : Podorozh
{
    public string DangerLevel { get; set; }

    public ExtremePodorozh(string misto, double vidstan, int dni, string transport, string dangerLevel)
        : base(misto, vidstan, dni, transport)
    {
        DangerLevel = dangerLevel;
    }

    public double RozrakhVartistPodorozh()
    {
        double dangerSurcharge = 1000; // Додаткові витрати на екстремальність подорожі
        return RozrakhVartist() + dangerSurcharge;
    }

    public override string Info()
    {
        return $"{base.Info()}, Рівень небезпеки: {DangerLevel}, Загальна вартість: {RozrakhVartistPodorozh()} грн";
    }

    // Метод для зміни типу туру
    public void ZminytyTypTuru(string newType)
    {
        // Додайте логіку для зміни типу туру, якщо це потрібно
    }
}
