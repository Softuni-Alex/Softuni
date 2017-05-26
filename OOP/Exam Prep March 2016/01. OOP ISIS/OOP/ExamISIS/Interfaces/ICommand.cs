namespace ExamISIS.Interfaces
{
    public interface ICommand
    {
        void ExecuteCommand(string input);

        void UpdateGroups();
    }
}