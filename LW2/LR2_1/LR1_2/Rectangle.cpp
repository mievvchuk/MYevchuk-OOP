#define _CRT_SECURE_NO_WARNINGS
#include "Rectangle.h"
// Конструктор за замовчуванням
Rectangle::Rectangle() : a(0), b(0) {
    cout << "Створено прямокутник за замовчуванням: " << a << " x " << b << " (" << this << ")" << endl;
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
    cout << "Викликано деструктор для прямокутника: " << a << " x " << b << " (" << this << ")" << endl;
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

// ++ префіксний
Rectangle& Rectangle::operator++() {
    ++a; ++b;
    return *this;
}
// ++ постфіксний
Rectangle Rectangle::operator++(int) {
    Rectangle temp(*this);
    ++(*this);
    return temp;
}

// -- префіксний
Rectangle& Rectangle::operator--() {
    --a; --b;
    return *this;
}
// -- постфіксний
Rectangle Rectangle::operator--(int) {
    Rectangle temp(*this);
    --(*this);
    return temp;
}
// "true" / "false"
Rectangle::operator bool() const {
    return a == b;
}
// множення на скаляр
Rectangle Rectangle::operator*(int scalar) const {
    return Rectangle(a * scalar, b * scalar);
}
// перетворення в string
Rectangle::operator string() const {
    return "Прямокутник: " + to_string(a) + " x " + to_string(b);
}
// перетворення зі string (літерал)
Rectangle operator"" _rect(const char* str, size_t) {
    int s1 = 0, s2 = 0;
    // підтримка "7 4"
    if (sscanf(str, "%d %d", &s1, &s2) == 2) {
        return Rectangle(s1, s2);
    }
    // підтримка "7x4"
    if (sscanf(str, "%dx%d", &s1, &s2) == 2) {
        return Rectangle(s1, s2);
    }
    // підтримка "7,4"
    if (sscanf(str, "%d,%d", &s1, &s2) == 2) {
        return Rectangle(s1, s2);
    }
    // одне число -> квадрат
    if (sscanf(str, "%d", &s1) == 1) {
        return Rectangle(s1, s1);
    }
    return Rectangle();
}
