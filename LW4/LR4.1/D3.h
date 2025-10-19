#pragma once
#include "D2.h"
#include <iostream>
using namespace std;

class D3 : public virtual D2, public virtual D1 {  // Використовуємо virtual для уникнення конфліктів
public:
    int b3;

    D3();
    ~D3();

    void init();
    void print();
    void set_b3(int _b3);
    int get_b3();
    void show();
    void showHierarchy();
};
