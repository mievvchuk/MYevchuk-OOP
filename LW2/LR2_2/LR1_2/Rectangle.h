#pragma once
#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

class Rectangle {
private:
    int a, b;
public:
    // Конструктори
    Rectangle();
    Rectangle(int s1, int s2);
    Rectangle(const Rectangle& c);
    ~Rectangle();

    // Методи
    void printSides();
    int calculatePerimeter() const;
    int calculateArea() const;

    // Властивості
    int getA() const;
    int getB() const;
    void setA(int s);
    void setB(int s);
    bool isSquare() const;

    // Оператори
    Rectangle& operator=(const Rectangle& other);  // оператор присвоєння
    Rectangle& operator++();
    Rectangle operator++(int);
    Rectangle& operator--();
    Rectangle operator--(int);

    explicit operator bool() const;
    Rectangle operator*(int scalar) const;
    operator string() const;

    // Друзі
    friend ostream& operator<<(ostream& os, const Rectangle& r);
    friend istream& operator>>(istream& is, Rectangle& r);
};
Rectangle operator"" _rect(const char* str, size_t);
