#include "D3.h"
#include <iostream>
using namespace std;

D3::D3() {
    cout << "Class D3, predok public D2\n";
}

D3::~D3() {
    cout << "Destructor D3\n";
}

void D3::input() {
    cout << "Enter name for D3: ";
    cin >> nameD3;
    D2::input();
}

void D3::show() {
    D2::show();
    cout << "Class D3, name = " << nameD3 << endl;
}
