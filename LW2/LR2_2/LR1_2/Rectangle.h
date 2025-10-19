#pragma once
#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

class Rectangle {
private:
    int a, b;
public:
    // ������������
    Rectangle();
    Rectangle(int s1, int s2);
    Rectangle(const Rectangle& c);
    ~Rectangle();

    // ������
    void printSides();
    int calculatePerimeter() const;
    int calculateArea() const;

    // ����������
    int getA() const;
    int getB() const;
    void setA(int s);
    void setB(int s);
    bool isSquare() const;

    // ���������
    Rectangle& operator=(const Rectangle& other);  // �������� ���������
    Rectangle& operator++();
    Rectangle operator++(int);
    Rectangle& operator--();
    Rectangle operator--(int);

    explicit operator bool() const;
    Rectangle operator*(int scalar) const;
    operator string() const;

    // ����
    friend ostream& operator<<(ostream& os, const Rectangle& r);
    friend istream& operator>>(istream& is, Rectangle& r);
};
Rectangle operator"" _rect(const char* str, size_t);
