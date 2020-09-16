using UnityEngine;

class Subtraction2 : IProblem
{
	public ProblemData GetProblem()
	{
		int v1, v2;
		do
		{
			v1 = Random.Range(0, 101);
			v2 = Random.Range(0, 101);
		} while (v1 == 0 && v2 == 0);

		int larger = Mathf.Max(v1, v2);
		int smaller = Mathf.Min(v1, v2);

		int answer = larger - smaller;
		int wrong;
		do
		{
			wrong = Random.Range(0, larger + 1);
		} while (wrong == answer);

		return new ProblemData($"{larger} - {smaller}", answer.ToString(), wrong.ToString());
	}
}
