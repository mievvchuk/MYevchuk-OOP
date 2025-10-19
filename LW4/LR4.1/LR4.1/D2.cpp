#include "D2.h"
#include <iostream>
using namespace std;

D2::D2() {
    cout << "Class D2, predok public D1, protected B3\n";
}

D2::~D2() {
    cout << "Destructor D2\n";
}

void D2::input() {
    cout << "Enter name for D2: ";
    cin >> nameD2;
    D1::input();
    B3::input();
}

void D2::show() {
    D1::show();
    B3::show();
    cout << "Class D2, name = " << nameD2 << endl;
}
