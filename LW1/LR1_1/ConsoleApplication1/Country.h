#pragma once
#include <iostream>
using namespace std;
class Country {
private:
    char* name;              // ім'я країни
    char* government_form;   // форма правління  
    float area;              // площа
public:
    // Конструктори
    Country();
    Country(const char* n, const char* g, float a);
    Country(const Country& other);
    // Деструктор
    ~Country();
    // Методи доступу
    char* getName() const;
    char* getGovernmentForm() const;
    float getArea() const;
    void setCountry(const char* n, const char* g, float a);
    void setName(const char* n);
    void setGovernmentForm(const char* g);
    void setArea(float a);
    void printCountry() const;
};