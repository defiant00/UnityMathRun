using UnityEngine;

class AllProblems : IProblem
{
	private readonly IProblem[] problems = {
		new Addition1(),
		new Addition2(),
		new Comparison1(),
		new Division1(),
		new Factor1(),
		new Multiplication1(),
		new Primes1(),
		new Subtraction1(),
		new Subtraction2()
	};

	public ProblemData GetProblem()
	{
		return problems[Random.Range(0, problems.Length)].GetProblem();
	}
}
