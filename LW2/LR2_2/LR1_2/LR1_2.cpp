#include "Rectangle.h"
#include <iostream>
#include <iomanip>
using namespace std;
int main() {
    setlocale(0, "ukr");
    // 1. Створення прямокутників
    Rectangle r1;                  // За замовчуванням
    Rectangle r2(10, 10);          // З параметрами
    Rectangle r3 = r2;             // Копіювання
    // 2. Оператори
    Rectangle r4 = r1; r4++;       // Постфіксний ++
    Rectangle r5 = r1; ++r5;       // Префіксний ++
    Rectangle r6 = r2 * 3;         // Множення на скаляр
    Rectangle r7 = r2; r7--;       // Постфіксний --
    Rectangle r8 = r2; --r8;       // Префіксний --
    // 3. Ввід користувача
    Rectangle rUser;
    cin >> rUser;
    // 4. Вивід у таблицю
    cout << "\nТаблиця прямокутникiв:\n";
    cout << "№   " << left << setw(12) << "Сторони"<< setw(10) << "Периметр"<< setw(10) << "Площа"<< "Тип" << endl;
    cout << "---------------------------------------------------\n";
    cout << 1 << "   " << r1 << "  (r1)\n";
    cout << 2 << "   " << r2 << "  (r2)\n";
    cout << 3 << "   " << r3 << "  (r3 = r2)\n";
    cout << 4 << "   " << r4 << "  (r1++)\n";
    cout << 5 << "   " << r5 << "  (++r1)\n";
    cout << 6 << "   " << r6 << "  (r2 * 3)\n";
    cout << 7 << "   " << r7 << "  (r2--)\n";
    cout << 8 << "   " << r8 << "  (--r2)\n";
    cout << 9 << "   " << rUser << "  (ввід користувача)\n";
    return 0;
}