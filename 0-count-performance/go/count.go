package main

import (
	"fmt"
	"time"
	// "github.com/bradhe/stopwatch"
)

func main() {
	count := 0
	start := time.Now()
	for i := 0; i < 1000000000; i++ {
		count += 1
	}
	stop := time.Now()
	elapsedTime := stop.Sub(start)
	fmt.Printf("Count is %v\n", count)
	fmt.Printf("Execution time %v seconds", elapsedTime.Seconds())
}
