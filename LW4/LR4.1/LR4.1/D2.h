#pragma once
#include "D1.h"
#include "B3.h"

class D2 : public D1, protected B3 {
protected:
    string nameD2;
public:
    D2();
    ~D2();
    void input();
    void show();
};
