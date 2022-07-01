using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }
        
        public virtual void VaccinateCat(Cat cat)
        {
            if (randomElement.NextDouble() < DeathRate)
            {
                cat.Alive = false;
                Console.WriteLine($"Cat {cat.ID} died during vaccination using Vaccinator3000");
            }
            else
            {
                for (int i = 0; i < 300; i++)
                {
                    cat.Immunity += Immunity[randomElement.Next(0, 4)];
                }
                Console.WriteLine($"Cat {cat.ID} vaccinated using Vaccinator3000");
            }
        }
        
        public virtual void VaccinateDog(Dog dog)
        {
            if (randomElement.NextDouble() < DeathRate)
            {
                dog.Alive = false;
                Console.WriteLine($"Dog {dog.ID} died during vaccination using Vaccinator3000");
            }
            else
            {
                for (int i = 0; i < 3000; i++)
                {
                    dog.Immunity += Immunity[randomElement.Next(0, 4)];
                }
                Console.WriteLine($"Dog {dog.ID} vaccinated using Vaccinator3000");
            }
        }
        
        public virtual void VaccinatePig(Pig pig)
        {
            if (randomElement.NextDouble() < (DeathRate * 3))
            {
                pig.Alive = false;
                Console.WriteLine($"Pig {pig.ID} died during vaccination using Vaccinator3000");
            }
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    pig.Immunity += Immunity[randomElement.Next(0, 4)];
                }
                Console.WriteLine($"Pig {pig.ID} vaccinated using Vaccinator3000");
            }
        }
    }
}
