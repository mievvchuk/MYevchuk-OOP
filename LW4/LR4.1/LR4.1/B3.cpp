#include "B3.h"
#include <iostream>
using namespace std;

B3::B3() {
    cout << "Class B3, predkiv nema\n";
}

B3::~B3() {
    cout << "Destructor B3\n";
}

void B3::input() {
    cout << "Enter name for B3: ";
    cin >> nameB3;
}

void B3::show() {
    cout << "Class B3, name = " << nameB3 << endl;
}
