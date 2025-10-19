#include "D1.h"
#include <iostream>
using namespace std;

D1::D1() {
    cout << "Class D1, predok public B2, protected B1\n";
}

D1::~D1() {
    cout << "Destructor D1\n";
}

void D1::input() {
    B1::input();
    B2::input();
    cout << "Enter name for D1: ";
    cin >> nameD1;
}

void D1::show() {
    B1::show();
    B2::show();
    cout << "Class D1, name = " << nameD1 << endl;
}
