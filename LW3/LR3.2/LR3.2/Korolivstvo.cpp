#include "Korolivstvo.h"

Korolivstvo::Korolivstvo(string n, string c, int p, string k)
    : Monarhiya(n, c, p, k) {
}
void Korolivstvo::printInfo() const {
    cout << "����������: " << name << ", �������: " << capital<< ", ���������: " << population << " ���"<< ", ������: " << monarkh << endl;
}
