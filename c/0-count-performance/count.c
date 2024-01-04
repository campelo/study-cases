#include <stdio.h>
#include <time.h>

int main(){
  clock_t startTime = clock();

  int count = 0;
  for(int i = 0; i < 1000000000; i++){
    count += 1;
  }

  clock_t endTime = clock();
  double elapsedTime = ((double)(endTime - startTime)) / CLOCKS_PER_SEC;
  printf("Count is %d\n", count);
  printf("Execution time: %f seconds", elapsedTime);
  return 0;
}