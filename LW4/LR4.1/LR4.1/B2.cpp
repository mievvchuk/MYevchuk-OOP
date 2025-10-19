#include "B2.h"
#include <iostream>
using namespace std;

B2::B2() {
    cout << "Class B2, predkiv nema\n";
}

B2::~B2() {
    cout << "Destructor B2\n";
}

void B2::input() {
    cout << "Enter name for B2: ";
    cin >> nameB2;
}

void B2::show() {
    cout << "Class B2, name = " << nameB2 << endl;
}
