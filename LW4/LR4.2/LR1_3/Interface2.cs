using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_3
{
    public interface ITurystychnaPodorozh : IPodorozh
    {
        // Унікальні властивості туристичної подорожі
        string TypTuru { get; set; }
        double VartistProzhyvannya { get; set; }

        // Унікальні методи
        double RozrakhVartistPodorozh();
        void ZminytyTypTuru(string newType);
    }
}
