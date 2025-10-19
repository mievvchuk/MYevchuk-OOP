#include "Korolivstvo.h"

Korolivstvo::Korolivstvo(string n, string c, int p, Uryad* g, Terytoriya t, string k)
    : Monarhiya(n, c, p, g, t, k) {
}

void Korolivstvo::printInfo() const {
    cout << left<< setw(30) << (name + ", " + capital)<< setw(30) << ("Король: " + monarkh)<< setw(25) << territory.getInfo()<< setw(30) << government->getType() << endl;
}