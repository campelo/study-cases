using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MapperLib;

public class LocalSource
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class LocalDestination
{
    public int Id { get; set; }
    public string Text { get; set; }
}

public class LocalAutoMapperProfile : Profile
{
    public LocalAutoMapperProfile()
    {
        CreateMap<LocalSource, LocalDestination>()
            .ForMember(tgt => tgt.Text, opt => opt.MapFrom(src => src.Name))
            .ReverseMap()
            .ForMember(tgt => tgt.Name, opt => opt.MapFrom(src => src.Text));
    }
}

public class Benchmark
{
    [Benchmark]
    public LocalDestination Local_AddMapsAssemblies()
    {
        IMapper _mapper;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(LocalAutoMapperProfile).Assembly);
        });
        _mapper = configuration.CreateMapper();

        var source = new LocalSource { Id = 1, Name = "Source" };
        return _mapper.Map<LocalSource, LocalDestination>(source);
    }

    [Benchmark]
    public LocalDestination Local_AddMapsTypes()
    {
        IMapper _mapper;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(LocalAutoMapperProfile));
        });
        _mapper = configuration.CreateMapper();

        var source = new LocalSource { Id = 1, Name = "Source" };
        return _mapper.Map<LocalSource, LocalDestination>(source);
    }

    [Benchmark]
    public LocalDestination Local_AddProfiles()
    {
        IMapper _mapper;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new LocalAutoMapperProfile());
        });
        _mapper = configuration.CreateMapper();

        var source = new LocalSource { Id = 1, Name = "Source" };
        return _mapper.Map<LocalSource, LocalDestination>(source);
    }

    [Benchmark]
    public Destination AddMapsAssemblies()
    {
        IMapper _mapper;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(AutoMapperProfile).Assembly);
        });
        _mapper = configuration.CreateMapper();

        var source = new Source { Id = 1, Name = "Source" };
        return _mapper.Map<Source, Destination>(source);
    }

    [Benchmark]
    public Destination AddMapsTypes()
    {
        IMapper _mapper;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(AutoMapperProfile));
        });
        _mapper = configuration.CreateMapper();

        var source = new Source { Id = 1, Name = "Source" };
        return _mapper.Map<Source, Destination>(source);
    }

    [Benchmark]
    public Destination AddProfiles()
    {
        IMapper _mapper;
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        });
        _mapper = configuration.CreateMapper();

        var source = new Source { Id = 1, Name = "Source" };
        return _mapper.Map<Source, Destination>(source);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmark>();
    }
}
