using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1 {
    class MonsterAttributes {
        public int id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string align { get; set; }
        public int challenge { get; set; }
        public int xp { get; set; }
        public double cr { get; set; }
        public int ac { get; set; }
        public int hp { get; set; }
        public string hitDice { get; set; }
        public string speeds { get; set; }
        public int str { get; set; }
        public int dex { get; set; }
        public int con { get; set; }
        public int intt { get; set; }
        public int wis { get; set; }
        public int cha { get; set; }
        public string savingThrows { get; set; }
        public string skills { get; set; }
        public string wri { get; set; }
        public string senses { get; set; }
        public string languages { get; set; }
        public string additional { get; set; }
        public string actions { get; set; }
        public string arctic { get; set; }
        public string coast { get; set; }
        public string desert { get; set; }
        public string forest { get; set; }
        public string grassland { get; set; }
        public string hill { get; set; }
        public string mountain { get; set; }
        public string swamp { get; set; }
        public string underdark { get; set; }
        public string underwater { get; set; }
        public string urban { get; set; }
        public string font { get; set; }
        public string addInfo { get; set; }

        public MonsterAttributes(List<string> myReaderList) {
            id = int.Parse(myReaderList[0]);
            name = myReaderList[1];
            size = myReaderList[2];
            type = myReaderList[3];
            align = myReaderList[4];
            challenge = int.Parse(myReaderList[5]);
            // nothing in column xp = int.Parse(myReaderList[6]);
            cr = double.Parse(myReaderList[7]);
            ac = int.Parse(myReaderList[8]);
            hp = int.Parse(myReaderList[9]);
            hitDice = myReaderList[10];
            speeds = myReaderList[11];
            str = int.Parse(myReaderList[12]);
            dex = int.Parse(myReaderList[13]);
            con = int.Parse(myReaderList[14]);
            intt = int.Parse(myReaderList[15]);
            wis = int.Parse(myReaderList[16]);
            cha = int.Parse(myReaderList[17]);
            savingThrows = myReaderList[18];
            skills = myReaderList[19];
            wri = myReaderList[20];
            senses = myReaderList[21];
            languages = myReaderList[22];
            additional = myReaderList[23];
            actions = myReaderList[24];
            arctic = myReaderList[25];
            coast = myReaderList[26];
            desert = myReaderList[27];
            forest = myReaderList[28];
            grassland = myReaderList[29];
            hill = myReaderList[30];
            mountain = myReaderList[31];
            swamp = myReaderList[32];
            underdark = myReaderList[33];
            underwater = myReaderList[34];
            urban = myReaderList[35];
            font = myReaderList[36];
            addInfo = myReaderList[37];
        }
    }
}
