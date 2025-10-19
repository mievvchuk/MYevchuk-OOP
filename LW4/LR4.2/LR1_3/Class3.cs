using LR1_3;

public class BusinessPodorozh : Podorozh, IBusinessPodorozh
{
    public string CompanyName { get; set; }
    public string PurposeOfTrip { get; set; }

    public BusinessPodorozh(string misto, double vidstan, int dni, string transport, string companyName, string purposeOfTrip)
        : base(misto, vidstan, dni, transport)
    {
        CompanyName = companyName;
        PurposeOfTrip = purposeOfTrip;
    }

    public double RozrakhVartistPodorozh()
    {
        double businessCosts = 500; // Фіксовані витрати для бізнес-подорожей
        return RozrakhVartist() + businessCosts;
    }

    public override string Info()
    {
        return $"{base.Info()}, Компанія: {CompanyName}, Мета поїздки: {PurposeOfTrip}, Загальна вартість: {RozrakhVartistPodorozh()} грн";
    }

    // Метод для зміни типу туру
    public void ZminytyTypTuru(string newType)
    {
        // Додайте логіку для зміни типу туру, якщо це потрібно
    }
}
