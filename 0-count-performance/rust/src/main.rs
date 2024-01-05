extern crate stopwatch;
use stopwatch::{Stopwatch};

fn main(){
  let mut count = 0;
  let mut stopwatch = Stopwatch::start_new();
  for _i in 0..1_000_000_000{
    count += 1;
  }
  stopwatch.stop();
  let elapsed_time = stopwatch.elapsed_ms() as f64 / 1_000.0;
  println!("Count is {}", count);
  println!("Execution time {} seconds", elapsed_time);
}