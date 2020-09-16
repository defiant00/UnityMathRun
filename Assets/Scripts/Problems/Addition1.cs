using UnityEngine;

class Addition1 : IProblem
{
	public ProblemData GetProblem()
	{
		int v1 = Random.Range(0, 11);
		int v2 = Random.Range(0, 11);
		int answer = v1 + v2;
		int wrong;
		do
		{
			wrong = Random.Range(0, 21);
		} while (wrong == answer);
		return new ProblemData($"{v1} + {v2}", answer.ToString(), wrong.ToString());
	}
}
