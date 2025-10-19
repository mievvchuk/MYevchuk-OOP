#include "Rectangle.h"
// Конструктор за замовчуванням
Rectangle::Rectangle() : a(0), b(0) {
    cout << "Створено прямокутник за замовчуванням: " << a << " x " << b << " ("<<this<<")" << endl;
}
// Конструктор з параметрами
Rectangle::Rectangle(int s1, int s2) : a(s1), b(s2) {
    cout << "Створено прямокутник: " << a << " x " << b << " (" << this << ")" << endl;
}
// Конструктор копіювання
Rectangle::Rectangle(const Rectangle& c) : a(c.a), b(c.b) {
    cout << "Викликано конструктор копiювання: " << a << " x " << b << " (" << this << ")" << endl;
}
// Деструктор
Rectangle::~Rectangle() {
    cout << "Викликано деструктор для прямокутника: " << a << " x " << b<< " (" << this << ")" << endl;
}
// Методи
void Rectangle::printSides() {
    cout << "Сторони прямокутника: a = " << a << ", b = " << b << " (" << this << ")" << endl;
}
int Rectangle::calculatePerimeter() {
    return 2 * (a + b);
}
int Rectangle::calculateArea() {
    return a * b;
}
// Властивості
int Rectangle::getA() { return a; }
int Rectangle::getB() { return b; }
void Rectangle::setA(int s) { a = s; }
void Rectangle::setB(int s) { b = s; }
bool Rectangle::isSquare() { return a == b; }