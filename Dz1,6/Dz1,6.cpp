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
vector<char> alf = { 'a','b','c','d','e','f' };

pair<char, vector<pair<char, int>>> NextComObj(vector<char>& alphabet)

{
    vector<pair<char, int>> nextElt(255);
    int number = 1;
    for (int i = 0; i < alphabet.size() - 1; i++)
    {
        nextElt[alphabet[i]] = make_pair(alphabet[i + 1], number);
        number++;
    }
    nextElt[alphabet[alphabet.size() - 1]] = make_pair(alphabet[0], number); // в конце зацикливаем созданный массив
                                                                              // после последнего элемента идёт первый
    return make_pair(alphabet[0], nextElt);
}
pair<char, vector<pair<char, int>>> deactivateElt(pair<char, vector<pair<char, int>>>& nextElt, vector<char>& word)
// функция создаёт множество следующих, в котором элементы, находящиеся в word,исключены.
{
    vector<pair<char, int>> newNextElt(255);
    int iter = 0, number = 1;
    char firstChar = nextElt.first;
    char tmp = firstChar, last = tmp;
    char newfirstChar = firstChar;
    do
    {
        if (iter < word.size() && tmp == word[iter] && tmp == newfirstChar)
        {
            newfirstChar = nextElt.second[tmp].first;
            iter++;
            last = nextElt.second[tmp].first;
        }
        else if (iter == word.size() || nextElt.second[tmp].first != word[iter])
        {
            newNextElt[last] = make_pair(nextElt.second[tmp].first, number);
            last = nextElt.second[tmp].first;
            number++;
        }
        else if (iter < word.size() && nextElt.second[tmp].first == word[iter])
        {
            iter++;
        }
        tmp = nextElt.second[tmp].first;
    } while (nextElt.second[tmp].first != firstChar);
    newNextElt[last] = make_pair(newfirstChar, number);

    return make_pair(newfirstChar, newNextElt);
}
char takeNextObj(pair<char, vector<pair<char, int>>>& nextElt, int n)
{
    char c = nextElt.first;
    for (int i = 1; i < n; i++)
    {
        c = nextElt.second[c].first;
    }
    return c;
}

bool takeNextObjLeks(pair<char, vector<pair<char, int>>>& nextElt, vector<char>& moh, int coutOfOn)
// получает на вход первый элемент, множество следующих элементов. Изменяет подмножество на следующее в лексикографическом порядке того же размера.
{
    int top = 0;
    int i = moh.size() - 1;
    char firstElt = nextElt.first;
    moh[i] = nextElt.second[moh[i]].first; // меняем последнюю букву
    if (moh[i] != firstElt) // если не было цикла, всё отлично
        return true;
    while (true)
    {
        top++; // иначе начинаем идти по слову в начало
        if (i - top == -1)
            return false;

        if (coutOfOn - nextElt.second[moh[i - top]].second > top)
            break; // необходимо выбрать такую букву, что при изменении её на следующую, буквы справа от неё можно будет расположить в лексикографическом порядке
    }
    moh[i - top] = nextElt.second[moh[i - top]].first; // нашли такую букву
    while (top > 0)
    {
        top--; // меняем весь хвост слова
        moh[i - top] = nextElt.second[moh[i - top - 1]].first;
    }
}


int main()
{
    SetConsoleCP(1251); SetConsoleOutputCP(1251);  // Подключаем вывод русских букв
    int numOfAsk;
    vector<char> mohOfNum;
    vector<char> c1, c2, c3, c4, c5, c6, a1, a2, a3, a4, a5, a6;
    vector<char> startMoh = { 'a','a','a' };
    pair<char, vector<pair<char, int>>> nextMoh, numNextMoh, nextMoh1, numNextMoh1, nextMoh2, numNextMoh2, nextMoh3, nextMoh4, numNextMoh3, numNextMoh4;
 
    ///////////////////////////////////////////////////////////////////////////////////////////////

    fileOut.open(("Otvet.txt"));
    nextMoh = NextComObj(alf);
    for (int i = 1; i <= 7; i++)
        mohOfNum.push_back(i + 48);
    numNextMoh = NextComObj(mohOfNum);
    // Так как имеется лишь 3 варианта расположения
    //1) 4 1 1 1

    a1 = { 'a' };
    do// выбираем 1 букву из 6
    {
        nextMoh1 = deactivateElt(nextMoh, a1); // деактивируем буквы, пересобираем множество следующих
        c1 = { '1', '2', '3','4' };
        do // выбираем 4 места под 1-ю повторяющуся букву из 7
        {
            numNextMoh1 = deactivateElt(numNextMoh, c1);
            a2 = { takeNextObj(nextMoh1,1), takeNextObj(nextMoh1,2), takeNextObj(nextMoh1,3) };
            do // выбираем 3 символа из 5
            {
                nextMoh2 = deactivateElt(nextMoh1, a2);
                c2 = { takeNextObj(numNextMoh1,1) };
                do // выбираем 1 местo под 2-ю повторяющуся букву
                {
                    numNextMoh2 = deactivateElt(numNextMoh1, c2);
                    c3 = { takeNextObj(numNextMoh2,1) };
                    do // выбираем 1 местo под 3-ю повторяющуся букву
                    {
                        numNextMoh3 = deactivateElt(numNextMoh2, c3);
                        c4 = { takeNextObj(numNextMoh3,1) };
                        do // выбираем 1 местo под 4-ю повторяющуся букву
                        {
                            for (int i = 1; i <= 7; i++)
                            {
                                for (int j = 0; j < 7; j++)
                                {
                                    if (j < c1.size() && c1[j] - 48 == i)
                                    {
                                        fileOut << a1[0];
                                        break;
                                    }
                                    else if (j < c2.size() && c2[j] - 48 == i)
                                    {
                                        fileOut << a2[0];
                                        break;
                                    }
                                    else if (j < c3.size() && c3[j] - 48 == i)
                                    {
                                        fileOut << a2[1];
                                        break;
                                    }
                                    else if (j < c4.size() && c4[j] - 48 == i)
                                    {
                                        fileOut << a2[2];
                                        break;
                                    }
                                }
                            }
                            fileOut << endl;
                        } while (takeNextObjLeks(numNextMoh3, c4, 1));
                    } while (takeNextObjLeks(numNextMoh2, c3, 2));
                } while (takeNextObjLeks(numNextMoh1, c2, 3));
            } while (takeNextObjLeks(nextMoh1, a2, 5));
        } while (takeNextObjLeks(numNextMoh, c1, 7));
    } while (takeNextObjLeks(nextMoh, a1, 6));

    fileOut << endl;
    //2) 3 2 1 1

    a1 = { 'a' };
    do// выбираем 1 букву из 6
    {
        nextMoh1 = deactivateElt(nextMoh, a1); // деактивируем буквы, пересобираем множество следующих
        c1 = { '1', '2', '3' };
        do // выбираем 3 места под 1-ю повторяющуся букву из 7
        {
            numNextMoh1 = deactivateElt(numNextMoh, c1);
            a2 = { takeNextObj(nextMoh1,1) };
            do // выбираем 1 символ из 5
            {
                nextMoh2 = deactivateElt(nextMoh1, a2);
                a3 = { takeNextObj(nextMoh2,1), takeNextObj(nextMoh2,2) };
                do // выбираем 2 символа из 5
                {
                    c2 = { takeNextObj(numNextMoh1,1),takeNextObj(numNextMoh1,2) };
                    do // выбираем 2 местo под 2-ю повторяющуся букву
                    {
                        numNextMoh2 = deactivateElt(numNextMoh1, c2);
                        c3 = { takeNextObj(numNextMoh2,1) };
                        do // выбираем 1 местo под 3-ю повторяющуся букву
                        {
                            numNextMoh3 = deactivateElt(numNextMoh2, c3);
                            c4 = { takeNextObj(numNextMoh3,1) };
                            do // выбираем 1 местo под 4-ю повторяющуся букву
                            {
                                for (int i = 1; i <= 7; i++)
                                {
                                    for (int j = 0; j < 7; j++)
                                    {
                                        if (j < c1.size() && c1[j] - 48 == i)
                                        {
                                            fileOut << a1[0];
                                            break;
                                        }
                                        else if (j < c2.size() && c2[j] - 48 == i)
                                        {
                                            fileOut << a2[0];
                                            break;
                                        }
                                        else if (j < c3.size() && c3[j] - 48 == i)
                                        {
                                            fileOut << a3[0];
                                            break;
                                        }
                                        else if (j < c4.size() && c4[j] - 48 == i)
                                        {
                                            fileOut << a3[1];
                                            break;
                                        }
                                    }
                                }
                                fileOut << endl;
                            } while (takeNextObjLeks(numNextMoh3, c4, 1));
                        } while (takeNextObjLeks(numNextMoh2, c3, 2));
                    } while (takeNextObjLeks(numNextMoh1, c2, 4));
                } while (takeNextObjLeks(nextMoh2, a3, 4));
            } while (takeNextObjLeks(nextMoh1, a2, 5));
        } while (takeNextObjLeks(numNextMoh, c1, 7));
    } while (takeNextObjLeks(nextMoh, a1, 6));

    fileOut << endl;
    //3) 2 2 2 1

    a1 = { 'a', 'b', 'c' };
    do// выбираем 3 букву из 6
    {
        nextMoh1 = deactivateElt(nextMoh, a1); // деактивируем буквы, пересобираем множество следующих
        c1 = { '1', '2' };
        do // выбираем 2 места под 1-ю повторяющуся букву из 7
        {
            numNextMoh1 = deactivateElt(numNextMoh, c1);
            a2 = { takeNextObj(nextMoh1,1) };
            do // выбираем 1 символ из 3
            {
                c2 = { takeNextObj(numNextMoh1,1),takeNextObj(numNextMoh1,2) };
                do // выбираем 2 местo под 2-ю повторяющуся букву
                {
                    numNextMoh2 = deactivateElt(numNextMoh1, c2);
                    c3 = { takeNextObj(numNextMoh2,1), takeNextObj(numNextMoh2,2) };
                    do // выбираем 2 местa под 3-ю повторяющуся букву
                    {
                        numNextMoh3 = deactivateElt(numNextMoh2, c3);
                        c4 = { takeNextObj(numNextMoh3,1) };
                        do // выбираем 1 местo под 4-ю повторяющуся букву
                        {
                            for (int i = 1; i <= 7; i++)
                            {
                                for (int j = 0; j < 7; j++)
                                {
                                    if (j < c1.size() && c1[j] - 48 == i)
                                    {
                                        fileOut << a1[0];
                                        break;
                                    }
                                    else if (j < c2.size() && c2[j] - 48 == i)
                                    {
                                        fileOut << a1[1];
                                        break;
                                    }
                                    else if (j < c3.size() && c3[j] - 48 == i)
                                    {
                                        fileOut << a1[2];
                                        break;
                                    }
                                    else if (j < c4.size() && c4[j] - 48 == i)
                                    {
                                        fileOut << a2[0];
                                        break;
                                    }
                                }
                            }
                            fileOut << endl;
                        } while (takeNextObjLeks(numNextMoh3, c4, 1));
                    } while (takeNextObjLeks(numNextMoh2, c3, 3));
                } while (takeNextObjLeks(numNextMoh1, c2, 5));
            } while (takeNextObjLeks(nextMoh1, a2, 3));
        } while (takeNextObjLeks(numNextMoh, c1, 7));
    } while (takeNextObjLeks(nextMoh, a1, 6));

}