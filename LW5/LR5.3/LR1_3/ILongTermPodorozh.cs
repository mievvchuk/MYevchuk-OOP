//ILongTermPodorozh.cs
namespace LR1_3
{
    public interface ILongTermPodorozh : IPodorozh
    {
        // Унікальна властивість
        int Months { get; set; }

        // Унікальні методи
        double RozrakhVartistPodorozh();
        void ZminytyTypTuru(string newType);
    }
}
