#include "Rectangle.h"
// ����������� �� �������������
Rectangle::Rectangle() : a(0), b(0) {
    cout << "�������� ����������� �� �������������: " << a << " x " << b << " ("<<this<<")" << endl;
}
// ����������� � �����������
Rectangle::Rectangle(int s1, int s2) : a(s1), b(s2) {
    cout << "�������� �����������: " << a << " x " << b << " (" << this << ")" << endl;
}
// ����������� ���������
Rectangle::Rectangle(const Rectangle& c) : a(c.a), b(c.b) {
    cout << "��������� ����������� ���i������: " << a << " x " << b << " (" << this << ")" << endl;
}
// ����������
Rectangle::~Rectangle() {
    cout << "��������� ���������� ��� ������������: " << a << " x " << b<< " (" << this << ")" << endl;
}
// ������
void Rectangle::printSides() {
    cout << "������� ������������: a = " << a << ", b = " << b << " (" << this << ")" << endl;
}
int Rectangle::calculatePerimeter() {
    return 2 * (a + b);
}
int Rectangle::calculateArea() {
    return a * b;
}
// ����������
int Rectangle::getA() { return a; }
int Rectangle::getB() { return b; }
void Rectangle::setA(int s) { a = s; }
void Rectangle::setB(int s) { b = s; }
bool Rectangle::isSquare() { return a == b; }