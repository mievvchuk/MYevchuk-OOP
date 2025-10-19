#include "≈лектронний–есурс.h"

ElektronnyResurs::ElektronnyResurs(string n, Avtor* a, Zhanr z, string p, string an)
    : Vydannya(n, a, z), posylannya(p), anotatsiya(an) {
}
void ElektronnyResurs::vyvestyInfo() const {
    cout << left<< setw(20) << "≈лектронний ресурс"<< setw(30) << nazva<< setw(35) << posylannya<< setw(20) << zhanr.getNazvu()<< setw(20) << avtor->getPrizvyshche() << endl;
}