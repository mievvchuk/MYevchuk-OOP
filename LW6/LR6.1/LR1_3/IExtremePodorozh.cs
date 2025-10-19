//IExtremePodorozh.cs
namespace LR1_3
{
    public interface IExtremePodorozh : IPodorozh
    {
        // Унікальна властивість
        string DangerLevel { get; set; }

        // Унікальні методи
        double RozrakhVartistPodorozh();
        void ZminytyTypTuru(string newType);
    }
}
