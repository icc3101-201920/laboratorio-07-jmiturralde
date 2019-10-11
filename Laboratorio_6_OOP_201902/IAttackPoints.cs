using System;
using System.Collections.Generic;
using System.Text;
using Laboratorio_6_OOP_201902.Enums;

namespace Laboratorio_6_OOP_201902
{
    interface IAttackPoints
    {
        int[] GetAttackPoints(EnumType line = EnumType.None);
        
    }
}
