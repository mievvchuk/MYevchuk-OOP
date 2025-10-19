#pragma once
#include <iostream>
using namespace std;
class Rectangle
{
private:
    int a, b;
public:
    // Конструктор за замовчуванням
    Rectangle();
    // Конструктор з параметрами
    Rectangle(int s1, int s2);
    // Конструктор копіювання
    Rectangle(const Rectangle& c);
    // Деструктор
    ~Rectangle();
    // Методи
    void printSides();
    int calculatePerimeter();
    int calculateArea();
    // Властивості
    int getA();
    int getB();
    void setA(int s);
    void setB(int s);
    bool isSquare();
};