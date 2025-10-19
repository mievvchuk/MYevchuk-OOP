//������.cpp
#include "������.h"
#include <iostream>
using namespace std;

Stattia::Stattia(string n, string a, string z, int num, int r)
    : Vydannya(n, a), zhurnal(z), nomer(num), rik(r) {
}

void Stattia::vyvestyInfo() const {
    cout << "������\n�����: " << nazva<< "\n�����: " << avtor<< "\n������: " << zhurnal<< "\n�����: " << nomer<< "\nг�: " << rik << endl;
}

bool Stattia::isAuthor(const string& a) const {
    return avtor == a;
}
