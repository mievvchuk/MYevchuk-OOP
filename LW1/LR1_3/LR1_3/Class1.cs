//class1.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_3
{
    public class Podorozh
    {
        public string Misto { get; set; }
        public double Vidstan { get; set; }
        public int Dni { get; set; }
        public string Transport { get; set; } // нове поле

        public Podorozh()
        {
            Misto = "Львів";
            Vidstan = 150;
            Dni = 1;
            Transport = "Автобус"; // за замовчуванням
        }

        public Podorozh(string misto, double vidstan, int dni, string transport)
        {
            Misto = misto;
            Vidstan = vidstan;
            Dni = dni;
            Transport = transport;
        }

        public double RozrakhVartist()
        {
            double tsinaZaKm = 5;
            double tsinaZaDen = 200;
            return (Vidstan * tsinaZaKm) + (Dni * tsinaZaDen);
        }

        public double SerednyaTsinaKm()
        {
            return RozrakhVartist() / Vidstan;
        }

        public string Info()
        {
            return $"Місто: {Misto}, Відстань: {Vidstan} км, Днів: {Dni}, Транспорт: {Transport}, Вартість: {RozrakhVartist()} грн";
        }
    }

}
