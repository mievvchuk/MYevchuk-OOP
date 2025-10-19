//книга.h
#pragma once
#include "Видання.h"

class Knyga : public Vydannya {
    int rik;
    string vydavnytstvo;
public:
    Knyga(string n, string a, int r, string v);
    void vyvestyInfo() const override;
    bool isAuthor(const string& a) const override;
};
