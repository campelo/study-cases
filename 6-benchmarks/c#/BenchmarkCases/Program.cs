using AutoBogus.FakeItEasy;
using AutoBogus;
using AutoBogus.NSubstitute;
using BenchmarkDotNet.Running;
using Hl7.Fhir.Model;
using Bogus;
using Microsoft.CodeAnalysis.FlowAnalysis;

// public static class Test{

//     private static AutoFaker<Practitioner> autoFaker = (new AutoFaker<Practitioner>()
//         .RuleFor(x => x.Name, [new HumanName(){Family = "Doe", Given = ["Jhon"]}]))
//         as AutoFaker<Practitioner>;

//     public static AutoFaker<T> GetAutoFaker<T>() where T : class
//     {
//         if (typeof(T) == typeof(Practitioner))
//         {
//             return autoFaker as AutoFaker<T>;
//         }

//         var faker = new AutoFaker<T>();

//                     var ps = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(TName));
//             foreach (var p in ps)
//             {
//                 faker.RuleFor(p.Name, f => autoFaker.Generate());
//             }

//         return faker;
//     }
// }

public class Program
{
    

    public static void Main(string[] args)
    {
        // var f = AutoFaker.Create(builder =>
        // {
        //     builder.WithBinder<NSubstituteBinder>();
        //     builder.WithRecursiveDepth(2);
        //     builder.WithTreeDepth(2);
        // });
        // // var name = Test.GetAutoFaker<TName>().Generate();
        // var name = Test.GetAutoFaker<ChildClass>().Generate();
        // var name = Test.GetAutoFaker<HumanName>().Generate();

        // Console.WriteLine(name.Given.First() + " " + name.Family);
        // Console.WriteLine(name);

        //_ = BenchmarkRunner.Run<MapAssemblies>();
        // _ = BenchmarkRunner.Run<CreateFakeData>();
        _ = BenchmarkRunner.Run<CreateString>();
    }

    
}

public class ChildClass {
    public TName Name { get; set; }
    public string JobTitle { get; set; }
    public string Phone { get; set; }

    public override string ToString()
    {
        return Name.Given + " " + Name.Family + " " + JobTitle + " " + Phone;
    }
}

public abstract class TAbstractName
    {
        
    }

    public class TName() : TAbstractName
    {
        public string Given { get; set; }
        public string Family { get; set; }
    }