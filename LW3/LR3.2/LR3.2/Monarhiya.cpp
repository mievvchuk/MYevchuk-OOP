#include "Monarhiya.h"

Monarhiya::Monarhiya(string n, string c, int p, string m)
    : Derzhava(n, c, p), monarkh(m) {
}

void Monarhiya::printInfo() const {
    cout << "��������: " << name << ", �������: " << capital
        << ", ���������: " << population << " ���"
        << ", ������: " << monarkh << endl;
}
