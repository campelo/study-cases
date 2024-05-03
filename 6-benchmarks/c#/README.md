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
| StaticString            |      0.0000 ns |   0.0000 ns |   0.0000 ns |
| RegularCreate           |      0.0921 ns |   0.0042 ns |   0.0040 ns |
| YieldList               |     15.9201 ns |   0.0617 ns |   0.0547 ns |
| BogusIntToString        |     67.0603 ns |   0.1307 ns |   0.1021 ns |
| BogusName               |    153.8072 ns |   1.2702 ns |   1.1260 ns |
| BogusRandomAlphanumeric |    427.3547 ns |   2.0814 ns |   1.9470 ns |
| RegularNewGuid          |    477.0530 ns |   2.1823 ns |   1.9346 ns |
| RandomToString          |    509.2469 ns |   1.6844 ns |   1.4931 ns |
| FixtureCreateString     |  9,932.7364 ns |  56.8761 ns |  50.4191 ns |
| FixtureCreateInt        | 10,795.1849 ns | 144.9678 ns | 128.5101 ns |
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