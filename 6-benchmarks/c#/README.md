# Benchmark Cases 

This project contains a set of benchmarks to compare the performance of different libraries and methods.

## Create Fake Data

This is a simple benchmark to compare the performance of different libraries to create fake data.

```
| Method        | Mean              | Error            | StdDev           |
|-------------- |------------------:|-----------------:|-----------------:|
| RegularCreate |          13.22 ns |         0.238 ns |         0.223 ns |
| BogusRuleFor  |     466,447.85 ns |     5,953.425 ns |     5,568.838 ns |
| BogusGenerate |     475,060.07 ns |     9,450.271 ns |    11,951.567 ns |
| FixtureCreate | 138,180,986.67 ns | 2,636,302.790 ns | 2,465,999.265 ns |
| FixtureBuild  | 140,929,491.18 ns | 2,789,289.261 ns | 4,504,182.232 ns |
```

## Create String

This is a simple benchmark to compare the performance of different libraries to create a string.

```
| Method         | Mean            | Error         | StdDev        |
|--------------- |----------------:|--------------:|--------------:|
| RegularCreate  |       0.0000 ns |     0.0000 ns |     0.0000 ns |
| RegularNewGuid |      45.1917 ns |     0.5001 ns |     0.4678 ns |
| FixtureCreate  |   3,183.5999 ns |    23.0440 ns |    21.5554 ns |
| BogusName		 | 402,038.6021 ns | 5,311.9270 ns | 4,708.8849 ns |
```

## Map Assemblies

This is a simple benchmark to compare the performance of different mapping assemblies.

```
| Method                  | Mean     | Error   | StdDev  |
|------------------------ |---------:|--------:|--------:|
| Local_AddProfiles       | 378.5 us | 3.26 us | 2.89 us |
| AddProfiles             | 380.5 us | 2.02 us | 1.89 us |
| AddMapsAssemblies       | 388.3 us | 3.37 us | 2.82 us |
| AddMapsTypes            | 391.4 us | 4.34 us | 3.85 us |
| Local_AddMapsTypes      | 398.9 us | 4.50 us | 3.98 us |
| Local_AddMapsAssemblies | 417.5 us | 8.35 us | 8.93 us |
```