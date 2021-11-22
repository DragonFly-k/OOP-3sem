using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    class Game
    {
        public string type;
        public string Type
        {
            get
            {
                return type;
            }
            set { }
        }
        public Game(string Type)
        {
            type = Type;
        }
        public override string ToString()
        {
            return Type;
        }
    }
}
