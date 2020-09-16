using UnityEngine;

class Comparison1 : IProblem
{
	public ProblemData GetProblem()
	{
		int v1 = Random.Range(0, 101);
		int v2 = Random.Range(0, 101);
		string[] right;
		string[] wrong;
		// <, <=, =, >=, >
		if (v1 < v2)
		{
			right = new[] { "<", "<=" };
			wrong = new[] { "=", ">=", ">" };
		}
		else if (v1 == v2)
		{
			right = new[] { "<=", "=", ">=" };
			wrong = new[] { "<", ">" };
		}
		else
		{
			right = new[] { ">=", ">" };
			wrong = new[] { "<", "<=", "=" };
		}
		string answer = right[Random.Range(0, right.Length)];
		string wrongChoice = wrong[Random.Range(0, wrong.Length)];
		return new ProblemData($"Compare {v1} to {v2}", answer, wrongChoice);
	}
}
