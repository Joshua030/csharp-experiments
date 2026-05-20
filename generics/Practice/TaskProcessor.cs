using Interfaces;

namespace generics;

public class TaskProcessor<TTask, TResult> where TTask : ITask<TResult>
{

    private TTask task;

    public TaskProcessor(TTask task)
    {
        this.task = task;
    }

    public TResult Execute()
    {
        return task.Perform();
    }

}
