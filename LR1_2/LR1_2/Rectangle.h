#pragma once
#include <iostream>
using namespace std;
class Rectangle
{
private:
    int a, b;
public:
    // ����������� �� �������������
    Rectangle();
    // ����������� � �����������
    Rectangle(int s1, int s2);
    // ����������� ���������
    Rectangle(const Rectangle& c);
    // ����������
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
};