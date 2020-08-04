using PersonalLibrary.Services.Interfaces;

namespace PersonalLibrary.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITaskRepository taskRepository)
        {
            Tasks = taskRepository;
        }

        public ITaskRepository Tasks { get; }
    }
}
