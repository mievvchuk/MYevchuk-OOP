#include "Respublika.h"

Respublika::Respublika(string n, string c, int p, Uryad* g, Terytoriya t, string pres)
    : Derzhava(n, c, p, g, t), president(pres) {
}

void Respublika::printInfo() const {
    cout << left << setw(30) << (name + ", " + capital)<< setw(30) << ("Президент: " + president)<< setw(25) << territory.getInfo()<< setw(30) << government->getType() << endl;
}