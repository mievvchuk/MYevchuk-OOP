#define _CRT_SECURE_NO_WARNINGS
#include "Country.h"
#include <cstring>
// Конструктор без параметрів
Country::Country() : name(nullptr), government_form(nullptr), area(0) {
    cout << "Викликано конструктор без параметрiв: " << this << endl;
}
// Конструктор з параметрами
Country::Country(const char* n, const char* g, float a) : area(a) {
    name = new char[strlen(n) + 1];
    strcpy(name, n);
    government_form = new char[strlen(g) + 1];
    strcpy(government_form, g);
    cout << "Викликано конструктор з параметрами: " << this << endl;
}
// Конструктор копіювання
Country::Country(const Country& other) : area(other.area) {
    name = new char[strlen(other.name) + 1];
    strcpy(name, other.name);
    government_form = new char[strlen(other.government_form) + 1];
    strcpy(government_form, other.government_form);
    cout << "Викликано конструктор копiювання: " << this << endl;
}
// Деструктор
Country::~Country() {
    delete[] name;
    delete[] government_form;
    cout << "Викликано деструктор: " << this << endl;
}
// --- Методи доступу ---
char* Country::getName() const { 
    return name; 
}
char* Country::getGovernmentForm() const { 
    return government_form; 
}
float Country::getArea() const { 
    return area; 
}
void Country::setName(const char* n) {
    delete[] name;
    name = new char[strlen(n) + 1];
    strcpy(name, n);
}
void Country::setGovernmentForm(const char* g) {
    delete[] government_form;
    government_form = new char[strlen(g) + 1];
    strcpy(government_form, g);
}
void Country::setArea(float a) { 
    area = a; 
}
void Country::setCountry(const char* n, const char* g, float a) {
    setName(n);
    setGovernmentForm(g);
    setArea(a);
    cout << "Задано країну: " << name << ", " << government_form << ", площа: " << area << endl;
}
void Country::printCountry() const {
    cout << "Назва: " << name<< "\t Форма правлiння: " << government_form<< "\t Площа: " << area << " км^2" << endl;
}