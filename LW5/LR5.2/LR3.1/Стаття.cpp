#include "Стаття.h"

Stattia::Stattia(string n, Avtor* a, Zhanr z, string zh, int num, int r)
    : Vydannya(n, a, z), zhurnal(zh), nomer(num), rik(r) {
}

void Stattia::vyvestyInfo() const {
    cout << left<< setw(20) << "Стаття"<< setw(30) << nazva<< setw(35) << (zhurnal + ", №" + to_string(nomer) + ", " + to_string(rik))<< setw(20) << zhanr.getNazvu()<< setw(20) << avtor->getPrizvyshche() << endl;
}