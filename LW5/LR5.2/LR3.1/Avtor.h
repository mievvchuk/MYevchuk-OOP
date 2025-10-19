#pragma once
#include <string>
using namespace std;
class Avtor {
    string prizvyshche;
public:
    Avtor(string p) : prizvyshche(p) {}
    string getPrizvyshche() const {
        return prizvyshche;
    }
};