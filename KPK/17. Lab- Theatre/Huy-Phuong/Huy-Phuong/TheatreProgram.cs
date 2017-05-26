/*//////////////////////////////////////
    ///                                  ///
   ///   Author: Huy Phuong Nguyen,     ///
  ///   Qui Nhơn, Bình Định, Vietnam   ///
 ///   Email: huy_p_n@yahoo.vn        ///
///                                  ///
//////////////////////////////////////*/

namespace Huy_Phuong
{
    using Core;
    using UserInterface;
    using Interfaces;

    public class TheatreProgram
    {
        public static void Main()
        {
            IPerformanceDatabase database = new PerformanceDatabase();
            IUserInterface userInterface = new ConsoleUserInterface();
            Engine engine = new Engine(database, userInterface);
            engine.Run();
        }
    }
}