#pragma once
#include "�������.h"

class ElektronnyResurs : public Vydannya {
    string posylannya;
    string anotatsiya;
public:
    ElektronnyResurs(string n, Avtor* a, Zhanr z, string p, string an);
    void vyvestyInfo() const override;
};