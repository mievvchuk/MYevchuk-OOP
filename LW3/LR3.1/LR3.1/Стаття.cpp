//стаття.cpp
#include "Стаття.h"
#include <iostream>
using namespace std;

Stattia::Stattia(string n, string a, string z, int num, int r)
    : Vydannya(n, a), zhurnal(z), nomer(num), rik(r) {
}

void Stattia::vyvestyInfo() const {
    cout << "Стаття\nНазва: " << nazva<< "\nАвтор: " << avtor<< "\nЖурнал: " << zhurnal<< "\nНомер: " << nomer<< "\nРік: " << rik << endl;
}

bool Stattia::isAuthor(const string& a) const {
    return avtor == a;
}
