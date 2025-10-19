#pragma once
#include "Видання.h"

class Knyga : public Vydannya {
    int rik;
    string vydavnytstvo;
public:
    Knyga(string n, Avtor* a, Zhanr z, int r, string v);
    void vyvestyInfo() const override;
};