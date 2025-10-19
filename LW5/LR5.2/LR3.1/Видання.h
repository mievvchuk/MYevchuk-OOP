#pragma once
#include <iostream>
#include <string>
#include <iomanip>
#include "Avtor.h"
#include "Zhanr.h"

class Vydannya {
protected:
    string nazva;
    Avtor* avtor;       // Агрегація
    Zhanr zhanr;        // Композиція

public:
    Vydannya(string n, Avtor* a, Zhanr z);
    virtual ~Vydannya() {}

    virtual void vyvestyInfo() const = 0;
    virtual bool isAuthor(const string& a) const;
};