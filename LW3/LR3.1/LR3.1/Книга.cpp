//книга.cpp
#include "Книга.h"
#include <iostream>
using namespace std;

Knyga::Knyga(string n, string a, int r, string v)
    : Vydannya(n, a), rik(r), vydavnytstvo(v) {
}

void Knyga::vyvestyInfo() const {
    cout << "Книга\nНазва: " << nazva<< "\nАвтор: " << avtor<< "\nРік: " << rik<< "\nВидавництво: " << vydavnytstvo << endl;
}

bool Knyga::isAuthor(const string& a) const {
    return avtor == a;
}
