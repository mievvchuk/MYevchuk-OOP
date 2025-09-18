#include "Rectangle.h"
#include <iostream>
using namespace std;

int main() {
    setlocale(0, "ukr");
    // 1. Конструктор за замовчуванням
    Rectangle r1;
    r1.printSides();
    // 2. Конструктор з параметрами
    Rectangle r2(10, 10);
    r2.printSides();
    // 3. Конструктор копіювання
    Rectangle r3 = r2;
    r3.printSides();
    Rectangle rectArr[3] = {
        Rectangle(),
        Rectangle(8, 2),
        Rectangle(r2) };


    for (int i = 0; i < 3; i++) {
        cout << "\nПрямокутник " << i + 1 << ":\n";
        rectArr[i].printSides();
        cout << "Периметр = " << rectArr[i].calculatePerimeter() << endl;
        cout << "Площа = " << rectArr[i].calculateArea() << endl;
        cout << (rectArr[i].isSquare() ? "Це квадрат" : "Не квадрат") << endl;
    }
    // 5. Покажчик на компонент-функцію
    typedef void (Rectangle::* FuncPointer)();
    FuncPointer fp = &Rectangle::printSides;
    // 6. Покажчик на об'єкт
    Rectangle* pRect = &r2;
    // 8. Виклик методу через обидва покажчики
    (pRect->*fp)();

    cout << "\nТест операторів:\n";

    cout << "До ++: "; r1.printSides();
    ++r1;
    cout << "Пiсля ++: "; r1.printSides();

    cout << "До --: "; r1.printSides();
    r1--;
    cout << "Пiсля --: "; r1.printSides();

    cout << (r2 ? "r2 - квадрат\n" : "r2 - не квадрат\n");

    Rectangle r4 = r2 * 3;
    cout << "Множення r2*3: "; r4.printSides();

    string s = (string)r4;
    cout << "У string: " << s << endl;

    Rectangle r5 = "7 4"_rect;
    cout << "З string-лiтералу: "; r5.printSides();

    return 0;
}
