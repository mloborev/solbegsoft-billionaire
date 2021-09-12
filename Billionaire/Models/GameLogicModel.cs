using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billionaire.Models
{
    public class GameLogicModel
    {
            public int Id { get; set; }
            public string Question { get; set; }
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Answer4 { get; set; }
            public int TrueAnswer { get; set; }
    }




}
