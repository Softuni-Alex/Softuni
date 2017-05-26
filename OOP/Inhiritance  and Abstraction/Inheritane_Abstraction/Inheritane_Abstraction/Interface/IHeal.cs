using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inheritane_Abstraction.Characters;

namespace Inheritane_Abstraction.Characters
{
    interface IHeal
    {

        void Heal(Characters target);
    }
}
