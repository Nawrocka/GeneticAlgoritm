using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAMaria
{
    public class testFunkcja
    {
        string targetString = "0000000";
        string validCharacters = "01";
        int populationSize = 200; //zmien aby móc określać wybor n punktow przestrzeni poszukiwań x
        float mutationRate = 0.01f;
        int elitism = 5;
        float bestFitness = 2 * (127 * 127 + 1);

        private GeneticAlgorithm<char> ga;
        private System.Random random;

        public void Start()
        {
            random = new System.Random();
            ga = new GeneticAlgorithm<char>(populationSize, targetString.Length, random, GetRandomCharacter, FitnessFunction, elitism, mutationRate);

            while (true)
            {
                Update();
                if (ga.BestFitness == bestFitness)
                {
                    Show();
                }
            }
        }

        public void Update()
        {
            ga.NewGeneration();
            //zaimplementuj zatrzymanie updatów, gdy spełnisz warunek if (ga.BestFitness == 1)

        }

        public char GetRandomCharacter()
        {
            int i = random.Next(validCharacters.Length);
            return validCharacters[i];
        }

        public float FitnessFunction(int index)
        {
            DNA<char> dna = ga.Population[index];
            List<char> charGenes = new List<char>();
            int decDna;


            for (int i = 0; i < dna.Genes.Length; i++)
            {
                charGenes.Add(dna.Genes[i]);  
            }

            string sGenes = new string(charGenes.ToArray());

            //z bin na dec
            try
            {
                decDna = Convert.ToInt32(sGenes, 2);
            }
            catch (Exception)
            {

                throw;
            }

            //obliczenie funkcji
            return 2 * (decDna * decDna + 1);

        }

        public void Show()
        {
            Console.WriteLine(ga.Generation);

            for (int i = 0; i < targetString.Length; i++)
            {
                Console.WriteLine(ga.Population[0].Genes[i]); //bo juz posortowane
            }
        }
    }
}
