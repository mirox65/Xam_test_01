using System;
using System.Collections.Generic;
using System.Text;

namespace Xam_test_01.Interfaces
{

    public interface IJednolikoUbrzanoGibanje : IKinematikaModel, IJednolikoPravocrtnoGibanje
    {
        string VNulaBrzna { get; }

        string VrijemeNa2 { get; }
    }
}
