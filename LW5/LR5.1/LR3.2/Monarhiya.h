#pragma once
#include "Derzhava.h"

class Monarhiya : public Derzhava {
protected:
    string monarkh;
public:
    Monarhiya(string n, string c, int p, Uryad* g, Terytoriya t, string m);
    void printInfo() const override;
};