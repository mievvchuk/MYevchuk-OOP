using System;
namespace LR1_3
{
    /// <summary>
    /// 1) Власний делегат-стратегія для розрахунку вартості подорожі.
    /// Дозволяє «підміняти» формулу без зміни класів подорожей.
    /// </summary>
    public delegate double CostStrategy(Podorozh trip);

    /// <summary>
    /// 2) Делегат для логування. Демонструємо мультикаст (ланцюжок викликів).
    /// </summary>
    public delegate void TripLogger(string message);

    public static class TripDelegates
    {
        // Готові стратегії (через method group і лямбда-вираз):
        public static readonly CostStrategy BaseCost = t => t.RozrakhVartist();
        public static readonly CostStrategy WithAccommodation = t => t.TotalCostWithAccommodation();
        public static readonly CostStrategy BusinessMarkup = t => t.RozrakhVartist() + 500;
    }
}
