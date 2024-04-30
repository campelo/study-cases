# Benchmark Cases 

This project contains a set of benchmarks to compare the performance of different libraries and methods.

## Create Fake Data

This is a simple benchmark to compare the performance of different libraries to create fake data.

```
| Method                   | Mean              | Error            | StdDev           | Median            |
|------------------------- |------------------:|-----------------:|-----------------:|------------------:|
| RegularCreate            |          21.98 ns |         1.824 ns |         5.377 ns |          24.70 ns |
| BogusRuleFor             |     480,302.59 ns |     8,624.955 ns |     8,470.859 ns |     478,606.05 ns |
| BogusGenerate            |     488,071.71 ns |     8,800.768 ns |     8,232.244 ns |     487,169.53 ns |
| FakeItEasyFixtureCreate  | 132,466,367.44 ns | 2,626,287.053 ns | 4,867,991.448 ns | 131,465,600.00 ns |
| FakeItEasyFixtureBuild   | 135,884,768.42 ns | 2,672,289.946 ns | 4,609,568.860 ns | 135,796,000.00 ns |
| MoqFixtureCreate         | 141,042,583.33 ns | 2,778,984.564 ns | 2,973,482.348 ns | 140,606,900.00 ns |
| MoqFixtureBuild          | 141,645,413.33 ns | 2,645,537.552 ns | 2,474,637.467 ns | 141,751,300.00 ns |
| NSubstituteFixtureCreate | 144,099,353.33 ns | 2,831,277.211 ns | 2,648,378.460 ns | 144,035,600.00 ns |
| NSubstituteFixtureBuild  | 145,155,437.50 ns | 2,738,184.999 ns | 2,689,263.797 ns | 145,935,100.00 ns |
```

## Create String

This is a simple benchmark to compare the performance of different libraries to create a string.

```
| Method         | Mean            | Error         | StdDev        |
|--------------- |----------------:|--------------:|--------------:|
| RegularCreate  |       0.0000 ns |     0.0000 ns |     0.0000 ns |
| RegularNewGuid |      45.1917 ns |     0.5001 ns |     0.4678 ns |
| FixtureCreate  |   3,183.5999 ns |    23.0440 ns |    21.5554 ns |
| BogusName      | 402,038.6021 ns | 5,311.9270 ns | 4,708.8849 ns |
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