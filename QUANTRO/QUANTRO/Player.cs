using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANTRO
{
    public class Player
    {
       public string playerName;
       public string vaiTro;
       public bool isAlive;

        public Player(string name,string vaitro)
        {
            vaiTro = vaitro;
            playerName = name;
            isAlive = true;
        }
    }
}
