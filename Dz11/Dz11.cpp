#include <algorithm> 
#include <cmath> 
#include <cstdio>
#include <string>
#include <fstream>
#include <iostream>
#include <vector>
#include <Windows.h>
using namespace std;
static ofstream fileOut, supFileOut;
vector<char> baseMoh = { 'a','b','c','d','e','f' };
int p = 7, q = 10; // количество вершин и рёбер(по заданию)
long long rebr, count1;
int maxNum;

void printGbit(long long mask) // вывод графа, записанного в битовой маске, в виде матрицы смежности
{
    for (int i = 1; i <= p; i++)
    {
        int lvl = ((i - 2) * (i - 1)) / 2;
        for (int j = 1; j < i; j++)
        {
            fileOut << ((mask & (1 << lvl + j - 1)) != 0) << ' ';  // проходимся до главной диагонали
        }
        fileOut << 0 << ' ';  // главная диагональ
        for (int j = i; j < p; j++)
        {

            lvl = ((j - 1) * (j)) / 2;
            fileOut << (0 != (mask & (1 << lvl + i - 1))) << ' '; // проходимся после главной диагонали
        }
        fileOut << endl;
    }
    fileOut << endl;
    count1++;
}

void printG(vector<vector<bool>>& matr) // вывод графа, записанного в матрице
{
    for (int i = 0; i < p; i++)
    {
        for (int j = 0; j < p; j++)
            fileOut << matr[i][j];
        fileOut << endl;
    }
    fileOut << endl;
    count1++;
}

void destroyOneNoOrient(vector<vector<bool>> matr, int i, int j, int numOfReb)
{
    if (i == p) // невозможный случай
        return;
    if (j == p - 1)
        destroyOneNoOrient(matr, i + 1, 0, numOfReb);
    else
        destroyOneNoOrient(matr, i, j + 1, numOfReb);

    if (i != j)
    {
        matr[i][j] = false;
        numOfReb--;

        if (numOfReb == q || q == -1)
            printG(matr);  // записываем его

        if (j == p - 1)
            return destroyOneNoOrient(matr, i + 1, 0, numOfReb);
        else
            return destroyOneNoOrient(matr, i, j + 1, numOfReb);
    }
}

int main()
{
    SetConsoleCP(1251); SetConsoleOutputCP(1251);  // Подключаем вывод русских букв
    vector<vector<bool>>matr;

    fileOut.open(("Otvet.txt"));
    cout << "Введите порядок графа: " << endl;
    cin >> p;
    cout << "Введите количество рёбер: " <<  endl;
    cin >> q;

    count1 = 0;

    for (int i = 0; i < p; i++)
    {
        matr.push_back(*(new vector<bool>));
        for (int j = 0; j < p; j++)
            if (i != j)
                matr[i].push_back(true);
            else
                matr[i].push_back(false);
    }

    if (q == p * p - p)
        printGbit(rebr);
    destroyOneNoOrient(matr, 0, 0, p * p - p);
    cout << "Графы выведены в файл." << endl;

    system("pause");
}