using System.Collections.Generic;

namespace WindowsFormsApp1 {
    public class MonsterAttributes {
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
    }

    public class PartyDetails{
        public string partyName { get; set; }
        public List<string> partyMemberNames { get; set; }
    }
}
