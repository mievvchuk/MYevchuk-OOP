//����������� ������.cpp
#include "�����������������.h"
#include <iostream>
using namespace std;

ElektronnyResurs::ElektronnyResurs(string n, string a, string p, string an)
    : Vydannya(n, a), posylannya(p), anotatsiya(an) {
}

void ElektronnyResurs::vyvestyInfo() const {
    cout << "����������� ������\n�����: " << nazva<< "\n�����: " << avtor<< "\n���������: " << posylannya<< "\n��������: " << anotatsiya << endl;
}

bool ElektronnyResurs::isAuthor(const string& a) const {
    return avtor == a;
}
