#pragma once
#include "Derzhava.h"

class Monarhiya : public Derzhava {
protected:
    string monarkh;
public:
    Monarhiya(string n, string c, int p, string m);
    void printInfo() const override;
};
