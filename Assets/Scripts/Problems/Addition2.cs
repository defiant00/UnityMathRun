using UnityEngine;

class Addition2 : IProblem
{
	public ProblemData GetProblem()
	{
		int v1 = Random.Range(0, 101);
		int v2 = Random.Range(0, 101);
		int answer = v1 + v2;
		int wrong;
		do
		{
			wrong = answer + Random.Range(-20, 21);
		} while (wrong == answer || wrong < 0);
		return new ProblemData($"{v1} + {v2}", answer.ToString(), wrong.ToString());
	}
}
