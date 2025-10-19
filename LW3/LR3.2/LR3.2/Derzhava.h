#pragma once
#include <iostream>
#include <string>
using namespace std;

class Derzhava {
protected:
    string name;
    string capital;
    int population;

public:
    Derzhava(string n, string c, int p);
    virtual ~Derzhava() {}

    virtual void printInfo() const;
};
