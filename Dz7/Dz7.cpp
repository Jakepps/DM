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
long long rebr2, count1, count2; 
int maxNum;

void printG(long long mask) // вывод графа, записанного в битовой маске, в виде матрицы смежности
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

void destroyOneNoOrient(long mask, int num, int& maxNum, int numOfReb)
{
    if (mask < 0 || num >= maxNum) // невозможный случай
        return;
    destroyOneNoOrient(mask, num + 1, maxNum, numOfReb); // вызываем функцию для такого графа, в котором ребро с номером num существует

    long nMask = mask - (1 << maxNum - num - 1);
    if (nMask >= 0) // если граф после удаления ребра num существует и является связным
    {
        if (numOfReb - 1 == q || q == -1)
            printG(nMask);  // записываем его

        return destroyOneNoOrient(nMask, num + 1, maxNum, numOfReb - 1); // вызываем функцию для него, но удаляем следующее ребро
    }
}

int main()
{
    SetConsoleCP(1251); SetConsoleOutputCP(1251);  // Подключаем вывод русских букв

    fileOut.open("Otvet.txt");
    cout << "Введите порядок графа: "<<endl;
    cin >> p;
    cout << "Введите количество рёбер: "<<endl;
    cin >> q;

    count1 = 0;
    maxNum = ((p - 1) * (p)) / 2;
    rebr2 = (1 << maxNum) - 1;
    if (q == maxNum)
        printG(rebr2);
    destroyOneNoOrient(rebr2, 0, maxNum, maxNum);
    cout << "Количество графов данного порядка с данными рёбрами: " << endl << count1;
    q = -1; count1 = 0;

    printG(rebr2);
    destroyOneNoOrient(rebr2, 0, maxNum, maxNum);
    cout << endl << "Количество графов данного порядка: " << endl << count1;
}
