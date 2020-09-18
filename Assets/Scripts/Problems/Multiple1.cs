using UnityEngine;

class Multiple1 : IProblem
{
	public ProblemData GetProblem()
	{
		int factor = Random.Range(2, 13);
		int answer = Random.Range(1, 13) * factor;
		int wrong;
		do
		{
			wrong = Random.Range(1, factor * 12 + 1);
		} while (wrong % factor == 0);
		return new ProblemData($"Multiple of {factor}", answer.ToString(), wrong.ToString());
	}
}
