//стаття.h
#pragma once
#include "Видання.h"

class Stattia : public Vydannya {
    string zhurnal;
    int nomer;
    int rik;
public:
    Stattia(string n, string a, string z, int num, int r);
    void vyvestyInfo() const override;
    bool isAuthor(const string& a) const override;
};
