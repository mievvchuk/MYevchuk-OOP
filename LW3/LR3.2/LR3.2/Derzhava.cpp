#include "Derzhava.h"

Derzhava::Derzhava(string n, string c, int p) : name(n), capital(c), population(p) {}

void Derzhava::printInfo() const {
    cout << "Держава: " << name << ", столиця: " << capital
        << ", населення: " << population << " млн" << endl;
}
