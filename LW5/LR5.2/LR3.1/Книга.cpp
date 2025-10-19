#include "Книга.h"
Knyga::Knyga(string n, Avtor* a, Zhanr z, int r, string v)
    : Vydannya(n, a, z), rik(r), vydavnytstvo(v) {
}
void Knyga::vyvestyInfo() const {
    cout << left<< setw(20) << "Книга"<< setw(30) << nazva<< setw(35) << (to_string(rik) + ", " + vydavnytstvo)<< setw(20) << zhanr.getNazvu()<< setw(20) << avtor->getPrizvyshche() << endl;
}