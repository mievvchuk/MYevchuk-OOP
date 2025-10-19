#include "Monarhiya.h"

Monarhiya::Monarhiya(string n, string c, int p, Uryad* g, Terytoriya t, string m)
    : Derzhava(n, c, p, g, t), monarkh(m) {
}

void Monarhiya::printInfo() const {
    cout << left<< setw(30) << (name + ", " + capital)<< setw(30) << ("Монарх: " + monarkh)<< setw(25) << territory.getInfo()<< setw(30) << government->getType() << endl;
}