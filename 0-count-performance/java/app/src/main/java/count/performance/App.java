/*
 * This Java source file was generated by the Gradle 'init' task.
 */
package count.performance;

import java.util.concurrent.TimeUnit;

import com.google.common.base.Stopwatch;

public class App {

    public static void main(String[] args) {
        long count = 0;
        Stopwatch stopwatch = Stopwatch.createStarted();
        for(long i = 0; i < 1000000000; i++)
            count += 1;
        stopwatch.stop();
        var elapsedTime = stopwatch.elapsed(TimeUnit.MILLISECONDS) / 1000.0; 
        System.out.println("Count is " + count);
        System.out.printf("Execution time %.3f seconds", elapsedTime);
    }
}
