#include<iostream>

using namespace std;

const int number = 1001;

int main()
{
    int result, cur = 1, sum = 1;
    
    for (int i = 2; i < number; i += 2)
        for (int j = 0; j < 4; j++) {
            cur += i;
            sum += cur;
        }
    result = sum;
    
    cout << result << endl;
    
    return 0;
}
