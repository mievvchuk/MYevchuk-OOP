#include "Respublika.h"

Respublika::Respublika(string n, string c, int p, string pres)
    : Derzhava(n, c, p), president(pres) {
}

void Respublika::printInfo() const {
    cout << "���������: " << name << ", �������: " << capital
        << ", ���������: " << population << " ���"
        << ", ���������: " << president << endl;
}
