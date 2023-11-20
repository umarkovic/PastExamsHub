using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Enums
{
    public enum AnswerValueType
    {
        Unknown = 0,

        SliderPercentage = 1, 
        SliderInteger = 2,
        Textfield = 3,
        MultipleChoice = 4
    }
}
