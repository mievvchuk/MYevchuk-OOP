#pragma once
#include "Видання.h"

class Stattia : public Vydannya {
    string zhurnal;
    int nomer;
    int rik;
public:
    Stattia(string n, Avtor* a, Zhanr z, string zh, int num, int r);
    void vyvestyInfo() const override;
};