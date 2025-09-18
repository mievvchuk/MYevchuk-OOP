#pragma once
#include <iostream>
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
    int calculatePerimeter();
    int calculateArea();

    // ����������
    int getA();
    int getB();
    void setA(int s);
    void setB(int s);
    bool isSquare();


    // ���������
    Rectangle& operator++();
    Rectangle operator++(int);
    Rectangle& operator--();
    Rectangle operator--(int);

    explicit operator bool() const;
    Rectangle operator*(int scalar) const;
    operator string() const;
};
Rectangle operator"" _rect(const char* str, size_t);
