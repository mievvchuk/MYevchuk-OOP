#include "B1.h"
#include <iostream>
using namespace std;

B1::B1() {
    cout << "Class B1, predkiv nema\n";
}

B1::~B1() {
    cout << "Destructor B1\n";
}

void B1::input() {
    cout << "Enter name for B1: ";
    cin >> nameB1;
}

void B1::show() {
    cout << "Class B1, name = " << nameB1 << endl;
}
