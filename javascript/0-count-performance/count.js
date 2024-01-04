function main(){
  let count = 0;
  const start = Date.now();
  for(let i = 0; i < 1000000000; i++){
    count += 1;
  }
  const end = Date.now();
  const elapsedTime = (end - start) / 1000.0;
  console.log(`Count is ${count}`);
  console.log(`Execution time ${elapsedTime} seconds`);
}

main();