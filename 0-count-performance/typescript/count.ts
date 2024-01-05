let count = 0;
const start = new Date().getTime();
for (let i = 0; i < 1000000000; i++){
  count += 1;
}
const end = new Date().getTime();
const elapsedTime = (end - start) / 1000.0;
console.log(`Count is ${count}`);
console.log(`Execution time ${elapsedTime} seconds`);