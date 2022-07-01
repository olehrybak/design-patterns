using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }

        public virtual void VaccinateCat(Cat cat)
        {
            if (randomElement.NextDouble() < DeathRate)
            {
                cat.Alive = false;
                Console.WriteLine($"Cat {cat.ID} died during vaccination using AvadaVaccine");
            }
            else
            {
                cat.Immunity = Immunity;
                Console.WriteLine($"Cat {cat.ID} vaccinated using AvadaVaccine");
            }
        }
        
        public virtual void VaccinateDog(Dog dog)
        {
            dog.Immunity = Immunity;
            Console.WriteLine($"Dog {dog.ID} vaccinated using AvadaVaccine");
        }
        
        public virtual void VaccinatePig(Pig pig)
        {
            pig.Alive = false;
            Console.WriteLine($"Pig {pig.ID} died during vaccination using AvadaVaccine");
        }
    }
}
