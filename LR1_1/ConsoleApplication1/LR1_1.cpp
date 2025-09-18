#include "Country.h"
#include <conio.h>
#include <iostream>
using namespace std;
// Тип для покажчика на компонент-функцію
typedef void (Country::* FuncPointer)() const;
int main() {
    setlocale(0, "ukr");
    // 1. Виклик конструктора без параметрів
    Country c1;
    c1.setCountry("Україна", "Республiка", 603700);
    c1.printCountry();
    // 2. Виклик конструктора з параметрами
    Country c2("Францiя", "Республiка", 643801);
    c2.printCountry();
    // 3. Виклик конструктора копіювання
    Country c3 = c2;
    c3.printCountry();
    // 4. Покажчик на об'єкт
    Country* pCountry = new Country("Нiмеччина", "Федеративна республiка", 357588);
    pCountry->printCountry();
    // 5. Покажчик на метод (компонент-функцію)
    FuncPointer f = &Country::printCountry;
    (pCountry->*f)();   // виклик через покажчик на метод
    // 6. Статичний масив об'єктів
    Country countries[3]; // викличе 3 рази конструктор без параметрів
    countries[0].setCountry("Iталiя", "Республiка", 301340);
    countries[1].setCountry("Iспанiя", "Монархiя", 505990);
    countries[2].setCountry("Польща", "Республiка", 312696);
    cout << "\nВиведення масиву країн:\n";
    for (int i = 0; i < 3; i++) {
        countries[i].printCountry();
    }
    // прибирання
    delete pCountry; // для динамічного одного об'єкта
    return 0;
}