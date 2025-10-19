#pragma once
#include <iostream>
using namespace std;
class Country {
private:
    char* name;              // ��'� �����
    char* government_form;   // ����� ��������  
    float area;              // �����
public:
    // ������������
    Country();
    Country(const char* n, const char* g, float a);
    Country(const Country& other);
    // ����������
    ~Country();
    // ������ �������
    char* getName() const;
    char* getGovernmentForm() const;
    float getArea() const;
    void setCountry(const char* n, const char* g, float a);
    void setName(const char* n);
    void setGovernmentForm(const char* g);
    void setArea(float a);
    void printCountry() const;
};