#include "Respublika.h"

Respublika::Respublika(string n, string c, int p, string pres)
    : Derzhava(n, c, p), president(pres) {
}

void Respublika::printInfo() const {
    cout << "–еспубл≥ка: " << name << ", столиц€: " << capital
        << ", населенн€: " << population << " млн"
        << ", президент: " << president << endl;
}
