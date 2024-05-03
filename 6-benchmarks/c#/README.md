# Benchmark Cases 

This project contains a set of benchmarks to compare the performance of different libraries and methods.

## Create Fake Data

This is a simple benchmark to compare the performance of different libraries to create fake data.

```
| Method                          | Mean              | Error            | StdDev           |
|-------------------------------- |------------------:|-----------------:|-----------------:|
| RegularCreate                   |          13.29 ns |         0.069 ns |         0.064 ns |
| BogusWithoutRule                |          43.57 ns |         0.292 ns |         0.273 ns |
| BogusWithRule                   |          59.16 ns |         0.941 ns |         0.880 ns |
| NSubstituteFixtureBuildWithOmit |      24,590.65 ns |       215.765 ns |       201.827 ns |
| FakeItEasyFixtureBuildWithOmit  |      25,402.94 ns |       223.623 ns |       209.177 ns |
| MoqFixtureBuildWithOmit         |      25,442.33 ns |       263.082 ns |       219.685 ns |
| MoqFixtureCreate                | 123,945,269.23 ns | 1,423,452.507 ns | 1,188,647.312 ns |
| MoqFixtureBuild                 | 126,969,521.43 ns | 1,739,241.895 ns | 1,541,792.638 ns |
| FakeItEasyFixtureCreateWithOmit | 129,693,011.76 ns | 2,475,227.590 ns | 2,541,876.497 ns |
| FakeItEasyFixtureBuild          | 133,268,445.00 ns | 2,648,433.755 ns | 3,049,940.251 ns |
| NSubstituteFixtureCreate        | 138,744,188.24 ns | 2,663,406.746 ns | 2,735,122.636 ns |
| NSubstituteFixtureBuild         | 140,750,393.33 ns | 2,597,975.163 ns | 2,430,147.580 ns |
```

## Create String

This is a simple benchmark to compare the performance of different libraries to create a string.

```
| Method                  | Mean          | Error      | StdDev     | Median        |
|------------------------ |--------------:|-----------:|-----------:|--------------:|
| StaticString            |     0.0088 ns |  0.0145 ns |  0.0136 ns |     0.0000 ns |
| RegularCreate           |     0.0242 ns |  0.0241 ns |  0.0465 ns |     0.0000 ns |
| YieldList               |     8.7463 ns |  0.1965 ns |  0.2485 ns |     8.6721 ns |
| BogusIntToString        |    23.0505 ns |  0.2990 ns |  0.2651 ns |    23.1014 ns |
| Singleton               |    24.3170 ns |  0.4903 ns |  0.8055 ns |    24.2251 ns |
| BogusName               |    44.6186 ns |  0.3577 ns |  0.2987 ns |    44.6669 ns |
| RegularNewGuid          |    46.5062 ns |  0.9306 ns |  1.1429 ns |    46.2268 ns |
| RandomToString          |    70.5602 ns |  0.7500 ns |  0.6263 ns |    70.3841 ns |
| BogusRandomAlphanumeric |   157.0048 ns |  3.0738 ns |  2.8752 ns |   155.5343 ns |
| FixtureCreateString     | 3,120.1152 ns | 35.2934 ns | 33.0135 ns | 3,107.4013 ns |
| FixtureCreateInt        | 3,502.1852 ns | 68.2896 ns | 91.1646 ns | 3,484.8408 ns |
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