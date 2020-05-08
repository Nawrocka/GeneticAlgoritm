using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class TestShakespeare 
{
	string targetString = "Hello World!";
	string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,.|!#$%&/()=? ";
	int populationSize = 200;
	float mutationRate = 0.01f;
    int elitism = 5;

	private GeneticAlgorithm<char> ga;
	private System.Random random;

    public void Start()
	{
		random = new System.Random();
		ga = new GeneticAlgorithm<char>(populationSize, targetString.Length, random, GetRandomCharacter, FitnessFunction, elitism, mutationRate);
        
        while (true)
        {
            Update();
            if (ga.BestFitness == 1)
            {
                Show();
            }
        }
    }

	public void Update()
	{
		ga.NewGeneration();
        //zaimplementuj zatrzymanie updatów, gdy spe³nisz warunek if (ga.BestFitness == 1)

    }

    public char GetRandomCharacter()
	{
		int i = random.Next(validCharacters.Length);
		return validCharacters[i];
	}

	public float FitnessFunction(int index)
	{
		float score = 0;
		DNA<char> dna = ga.Population[index];

		for (int i = 0; i < dna.Genes.Length; i++)
		{
			if (dna.Genes[i] == targetString[i])
			{
				score += 1;
			}
		}

		score /= targetString.Length;

		score = (float)(Math.Pow(2, score) - 1) / (2 - 1);

		return score;
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
