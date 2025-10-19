#include "Derzhava.h"

Derzhava::Derzhava(string n, string c, int p, Uryad* g, Terytoriya t)
    : name(n), capital(c), population(p), government(g), territory(t) {
}

void Derzhava::printInfo() const {
    cout << left<< setw(30) << (name + ", " + capital)<< setw(30) << ("Населення: " + to_string(population) + " млн")<< setw(25) << territory.getInfo()<< setw(30) << government->getType() << endl;
}