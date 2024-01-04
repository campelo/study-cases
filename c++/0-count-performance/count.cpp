#include <iostream>
#include <chrono>
using namespace std;

int main(){
  auto startTime = chrono::high_resolution_clock::now();
  int count = 0;
  for (int i = 0; i < 1000000000; i++){
    count += 1;
  }
  auto endTime = chrono::high_resolution_clock::now();

  auto elapsedTime = chrono::duration_cast<chrono::milliseconds>(endTime - startTime);
  cout << "Count is " << count << endl;
  cout << "Execution time " << elapsedTime.count() << " milliseconds.";
  return 0;
}