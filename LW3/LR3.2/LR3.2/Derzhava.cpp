#include "Derzhava.h"

Derzhava::Derzhava(string n, string c, int p) : name(n), capital(c), population(p) {}

void Derzhava::printInfo() const {
    cout << "�������: " << name << ", �������: " << capital
        << ", ���������: " << population << " ���" << endl;
}
