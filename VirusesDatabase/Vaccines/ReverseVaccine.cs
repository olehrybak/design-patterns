using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        public int Coefficient = 0;
        
        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "ReverseVaccine";
        }
        
        public virtual void VaccinateCat(Cat cat)
        {
            cat.Alive = false;
            Console.WriteLine($"Cat {cat.ID} died during vaccination using ReverseVaccine");
            Coefficient++;
        }
        
        public virtual void VaccinateDog(Dog dog)
        {
            dog.Immunity = Immunity;
            Console.WriteLine($"Dog {dog.ID} vaccinated using ReverseVaccine");
            Coefficient++;
        }
        
        public virtual void VaccinatePig(Pig pig)
        {
            if (randomElement.NextDouble() < (DeathRate * Coefficient))
            {
                pig.Alive = false;
                Console.WriteLine($"Pig {pig.ID} died during vaccination using ReverseVaccine");
            }
            else
            {
                char[] array = Immunity.ToCharArray();
                Array.Reverse(array);
                string immunityReversed = new string(array);
                pig.Immunity = Immunity + immunityReversed;
                Console.WriteLine($"Pig {pig.ID} vaccinated using ReverseVaccine");
            }
            Coefficient++;
        }
    }
}
