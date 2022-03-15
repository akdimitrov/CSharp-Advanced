using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string trainerInfo = Console.ReadLine();
            while (trainerInfo != "Tournament")
            {
                string[] tokens = trainerInfo.Split();
                string trainer = tokens[0];
                string pokemon = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                if (trainers.Any(x => x.Name == trainer))
                {
                    trainers.First(x => x.Name == trainer).Pokemons.Add(new Pokemon(pokemon, element, health));
                }
                else
                {
                    trainers.Add(new Trainer(trainer, new Pokemon(pokemon, element, health)));
                }

                trainerInfo = Console.ReadLine();
            }

            string elementToCheck = Console.ReadLine();
            while (elementToCheck != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == elementToCheck))
                    {
                        trainer.NumberOfBadges++;
                        continue;
                    }

                    trainer.Pokemons.Select(x => x.Health -= 10).ToList();
                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                }

                elementToCheck = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
