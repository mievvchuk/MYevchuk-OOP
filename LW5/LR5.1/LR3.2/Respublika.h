#pragma once
#include "Derzhava.h"

class Respublika : public Derzhava {
    string president;
public:
    Respublika(string n, string c, int p, Uryad* g, Terytoriya t, string pres);
    void printInfo() const override;
};