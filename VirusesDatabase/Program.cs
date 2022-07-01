using System;
using System.Collections;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(Iterator iter)
            {
                while (iter.MoveNext())
                {
                    var current = iter.Current();
                    if(current != null)
                        Console.WriteLine(current);
                }
                Console.WriteLine();
                
            }
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };
                
                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"\nTesting {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        subject.GetVaccine(vaccine);
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function
                    var simpleIter = (new CreateIterator(simpleDatabase, genomeDatabase)).GetIterator();

                    Console.WriteLine();
                    // iterating over simpleDatabase
                    while(simpleIter.MoveNext())
                    {
                        var virus = simpleIter.Current();
                        if (virus != null)
                        {
                            foreach (var subject in subjects)
                            {
                                Console.WriteLine($"Testing {subject.GetType().Name} {subject.ID} with {virus.VirusName}");
                                subject.GetTested(virus);
                            }
                        }
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();
            
            Console.WriteLine("--------SIMPLE DATABASE---------");
            var simpleIter = (new CreateIterator(simpleDatabase, genomeDatabase)).GetIterator();
            mediaOutlet.Publish(simpleIter);
            Console.WriteLine();

            
            Console.WriteLine("--------EXCELL DATABASE---------");
            var excellIter = (new CreateIterator(excellDatabase, genomeDatabase)).GetIterator();
            mediaOutlet.Publish(excellIter);
            excellIter.Reset();
            Console.WriteLine();
            
            Console.WriteLine("--------EXCELL DATABASE WITH FILTER (DeathRate >15)---------");
            Func<VirusData, bool> func = data => data.DeathRate > 15;
            var excellFilterIter = new FilterIterator(excellIter, func);
            mediaOutlet.Publish(excellFilterIter);
            excellIter.Reset();
            Console.WriteLine();
            
            Console.WriteLine("--------EXCELL DATABASE WITH MAPPING (DeathRate + 10)---------");
            Func<VirusData, VirusData> mappingFunc = data => new VirusData(data.VirusName, data.DeathRate + 10, data.InfectionRate, data.Genomes);
            var excellMappingIter = new MappingIterator(excellIter, mappingFunc);
            var exccellMappingFilterIter = new FilterIterator(excellMappingIter, func);
            mediaOutlet.Publish(exccellMappingFilterIter);
            excellIter.Reset();
            Console.WriteLine();
            
            Console.WriteLine("--------OVERCOMPLICATED DATABASE---------");
            var overcomplicatedIter = (new CreateIterator(overcomplicatedDatabase, genomeDatabase)).GetIterator();
            mediaOutlet.Publish(overcomplicatedIter);
            overcomplicatedIter.Reset();
            
            Console.WriteLine("--------CONCATENATION OF EXCELL AND OVERCOMPLICATED DATABASES---------");
            var concatIter = new ConcatIterator(excellIter, overcomplicatedIter);
            mediaOutlet.Publish(concatIter);

            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
