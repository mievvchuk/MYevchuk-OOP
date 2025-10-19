public class LongTermPodorozh : Podorozh
{
    public int Months { get; set; }

    public LongTermPodorozh(string misto, double vidstan, int dni, string transport, int months)
        : base(misto, vidstan, dni, transport)
    {
        Months = months;
    }

    public double RozrakhVartistPodorozh()
    {
        double longTermSurcharge = 3000; // Додаткові витрати на довготривалі подорожі
        return RozrakhVartist() + longTermSurcharge;
    }

    public override string Info()
    {
        return $"{base.Info()}, Тривалість: {Months} місяців, Загальна вартість: {RozrakhVartistPodorozh()} грн";
    }

    // Метод для зміни типу туру
    public void ZminytyTypTuru(string newType)
    {
        // Додайте логіку для зміни типу туру, якщо це потрібно
    }
}
