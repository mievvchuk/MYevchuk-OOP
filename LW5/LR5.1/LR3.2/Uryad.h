#pragma once
#include <string>
using namespace std;
class Uryad {
    string type;
public:
    Uryad(string t = "Невідомий");
    string getType() const;
};