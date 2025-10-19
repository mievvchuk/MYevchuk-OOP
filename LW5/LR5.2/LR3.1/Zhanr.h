#pragma once
#include <string>
using namespace std;
class Zhanr {
    string nazva_zhanru;
public:
    Zhanr(string n) : nazva_zhanru(n) {}
    string getNazvu() const {
        return nazva_zhanru;
    }
};