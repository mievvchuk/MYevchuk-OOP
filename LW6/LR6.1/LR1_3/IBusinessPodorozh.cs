//IBusinessPodorozh.cs
namespace LR1_3
{
    public interface IBusinessPodorozh : IPodorozh
    {
        // Унікальні властивості
        string CompanyName { get; set; }
        string PurposeOfTrip { get; set; }

        // Унікальні методи
        double RozrakhVartistPodorozh();
        void ZminytyTypTuru(string newType);
    }
}
