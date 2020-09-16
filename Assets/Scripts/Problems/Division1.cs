using UnityEngine;

class Division1 : IProblem
{
	public ProblemData GetProblem()
	{
		int v2 = Random.Range(1, 13);
		int answer = Random.Range(0, 13);
		int v1 = v2 * answer;
		int wrong;
		do
		{
			wrong = Random.Range(0, 13);
		} while (wrong == answer);
		return new ProblemData($"{v1} ÷ {v2}", answer.ToString(), wrong.ToString());
	}
}
