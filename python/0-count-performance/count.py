import time

def main():
  start = time.time()
  count = 0
  for i in range(0,1000000000):
    count += 1
  end = time.time()
  elapsedTime = end-start
  print(f'Count is {count}.')
  print(f'Execution time {elapsedTime} seconds.')

if __name__ == '__main__':
  main()