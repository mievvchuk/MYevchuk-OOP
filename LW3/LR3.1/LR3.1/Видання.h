//видання.h
#pragma once
#include <iostream>
#include <string>
using namespace std;

class Vydannya {
protected:
    string nazva;
    string avtor;
    Vydannya* next; // вказівник на наступний елемент

    static Vydannya* head; // початок списку

public:
    Vydannya(string n, string a);
    virtual ~Vydannya();

    virtual void vyvestyInfo() const = 0;
    virtual bool isAuthor(const string& a) const = 0;

    static void perehlyad();
    static void poshukAvtora(const string& a);
};
