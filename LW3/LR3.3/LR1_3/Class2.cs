public class TurystychnaPodorozh : Podorozh
{
    public string TypTuru { get; set; }
    public double VartistProzhyvannya { get; set; }

    public TurystychnaPodorozh(string misto, double vidstan, int dni, string transport, string typTuru, double vartistProzhyvannya)
        : base(misto, vidstan, dni, transport)
    {
        TypTuru = typTuru;
        VartistProzhyvannya = vartistProzhyvannya;
    }

    public double RozrakhVartistPodorozh()
    {
        return RozrakhVartist() + VartistProzhyvannya;
    }

    public override string Info()
    {
        return $"{base.Info()}, Тип туру: {TypTuru}, Вартість проживання: {VartistProzhyvannya} грн, Загальна вартість: {RozrakhVartistPodorozh()} грн";
    }

    // Метод для зміни типу туру
    public void ZminytyTypTuru(string newType)
    {
        TypTuru = newType;
    }
}
