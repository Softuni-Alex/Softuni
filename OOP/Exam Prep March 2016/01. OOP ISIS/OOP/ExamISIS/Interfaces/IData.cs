using System.Collections.Generic;

namespace ExamISIS.Interfaces
{
    public interface IData
    {
        //set everything that is needed as data
        ICollection<IHackGroups> Groups { get; }

        void AddGroup(IHackGroups group);
    }
}
