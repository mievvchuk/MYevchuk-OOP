#pragma once
#include <iostream>
#include <string>
#include <iomanip>
#include "Uryad.h"
#include "Terytoriya.h"
using namespace std;
class Derzhava {
protected:
    string name;
    string capital;
    int population;
    Uryad* government;      // Агрегація (вказівник)
    Terytoriya territory;   // Композиція (вбудований об'єкт)

public:
    Derzhava(string n, string c, int p, Uryad* g, Terytoriya t);
    virtual ~Derzhava() {}
    virtual void printInfo() const;
};