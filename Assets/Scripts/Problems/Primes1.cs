using System.Linq;
using UnityEngine;

class Primes1 : IProblem
{
	private readonly int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

	public ProblemData GetProblem()
	{
		int prime = primes[Random.Range(0, primes.Length)];
		int not;
		do
		{
			not = Random.Range(4, 101);
		} while (primes.Contains(not));

		if (Random.Range(0, 2) == 0)
		{
			return new ProblemData("Is Prime", prime.ToString(), not.ToString());
		}
		else
		{
			return new ProblemData("Is Not Prime", not.ToString(), prime.ToString());
		}
	}
}
