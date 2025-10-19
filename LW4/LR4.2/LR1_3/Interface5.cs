using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
