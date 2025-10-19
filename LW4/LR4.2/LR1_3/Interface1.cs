using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_3
{
    public interface IPodorozh
    {
        string Misto { get; set; }
        double Vidstan { get; set; }
        int Dni { get; set; }
        string Transport { get; set; }

        string Info(); //Метод для отримання інформації про подорож
        double RozrakhVartist(); //Метод для розрахунку вартості подорожі
        double SerednyaTsinaKm(); //Метод для розрахунку середньої ціни за км
    }
}