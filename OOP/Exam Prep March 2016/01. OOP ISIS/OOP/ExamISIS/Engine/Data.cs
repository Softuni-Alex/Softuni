using ExamISIS.Interfaces;
using System;
using System.Collections.Generic;

namespace ExamISIS.Engine
{

    public class Data : IData
    {

        //Constructor
        public Data()
        {
            Groups = new LinkedList<IHackGroups>();
        }

        //Properties
        public ICollection<IHackGroups> Groups { get; }

        //Methods

        public void AddGroup(IHackGroups group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("Group cannot be null");
            }

            this.Groups.Add(group);
        }
    }
}