#pragma once
#include "B1.h"
#include "B2.h"

class D1 : public B2, protected B1 {
protected:
    string nameD1;
public:
    D1();
    ~D1();
    void input();
    void show();
};
