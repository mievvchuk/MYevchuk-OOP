#pragma once
#include "Monarhiya.h"

class Korolivstvo : public Monarhiya {
public:
    Korolivstvo(string n, string c, int p, Uryad* g, Terytoriya t, string k);
    void printInfo() const override;
};