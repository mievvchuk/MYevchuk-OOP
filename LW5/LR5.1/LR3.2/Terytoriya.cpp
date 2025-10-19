#include "Terytoriya.h"

Terytoriya::Terytoriya(int p) : ploshcha(p) {}

string Terytoriya::getInfo() const {
    return to_string(ploshcha) + " км²";
}