public class ProblemData
{
	public string Question, Correct, Wrong;

	public ProblemData(string question, string correct, string wrong)
	{
		Question = question;
		Correct = correct;
		Wrong = wrong;
	}
}

public interface IProblem
{
	ProblemData GetProblem();
}
