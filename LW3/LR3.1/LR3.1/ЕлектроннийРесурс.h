//����������� ������.h
#pragma once
#include "�������.h"

class ElektronnyResurs : public Vydannya {
    string posylannya;
    string anotatsiya;
public:
    ElektronnyResurs(string n, string a, string p, string an);
    void vyvestyInfo() const override;
    bool isAuthor(const string& a) const override;
};
