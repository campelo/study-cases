# Benchmark Cases 

This project contains a set of benchmarks to compare the performance of different libraries and methods.

## Create Fake Data

This is a simple benchmark to compare the performance of different libraries to create fake data.

```
| Method                          | Mean              | Error            | StdDev           |
|-------------------------------- |------------------:|-----------------:|-----------------:|
| RegularCreate                   |          44.99 ns |         0.997 ns |         0.932 ns |
| BogusWithoutRule                |         145.95 ns |         1.152 ns |         1.078 ns |
| BogusWithRule                   |         207.42 ns |         4.203 ns |         4.497 ns |
| MoqFixtureBuildWithOmit         |      92,546.44 ns |       704.609 ns |       624.617 ns |
| NSubstituteFixtureBuildWithOmit |      93,719.29 ns |       997.107 ns |       832.629 ns |
| FakeItEasyFixtureBuildWithOmit  |      96,948.08 ns |     1,529.108 ns |     2,469.225 ns |
| MoqFixtureCreate                | 464,275,048.00 ns | 5,119,123.807 ns | 4,537,969.917 ns |
| FakeItEasyFixtureCreateWithOmit | 468,306,530.53 ns | 4,921,327.206 ns | 4,603,412.522 ns |
| MoqFixtureBuild                 | 472,407,468.54 ns | 6,770,017.247 ns | 5,653,271.017 ns |
| FakeItEasyFixtureBuild          | 489,277,382.38 ns | 2,497,992.341 ns | 2,085,936.740 ns |
| NSubstituteFixtureCreate        | 501,406,327.53 ns | 4,547,716.483 ns | 4,253,936.820 ns |
| NSubstituteFixtureBuild         | 517,150,622.50 ns | 3,279,398.237 ns | 2,907,101.118 ns |
```

## Create String

This is a simple benchmark to compare the performance of different libraries to create a string.

```
| Method                  | Mean           | Error       | StdDev      |
|------------------------ |---------------:|------------:|------------:|
| RegularCreate           |      0.0000 ns |   0.0000 ns |   0.0000 ns |
| StaticString            |      0.0923 ns |   0.0056 ns |   0.0050 ns |
| BogusIntToString        |     64.4741 ns |   1.0704 ns |   0.8939 ns |
| BogusName               |    151.9556 ns |   0.6868 ns |   0.6089 ns |
| BogusRandomAlphanumeric |    389.4184 ns |   3.4256 ns |   3.2043 ns |
| RegularNewGuid          |    481.6495 ns |   6.4125 ns |   5.3547 ns |
| RandomToString          |    505.1077 ns |   1.7401 ns |   1.5426 ns |
| FixtureCreateString     |  9,849.9974 ns | 166.4571 ns | 155.7041 ns |
| FixtureCreateInt        | 10,201.5911 ns | 101.9611 ns | 113.3295 ns |
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