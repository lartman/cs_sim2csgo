using System;
using System.CodeDom;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Text;
using IniFiles;

[Serializable]
public class Serializetest
{
    public int opencases;
    public string nickname;
    public int currentAvatar;
    public int currentLevel;
    public int currentXP;
    public int currentGem;
    public int shopXP;

    public bool[] collectionItemsz;
    public bool collectionScanned;
    public int collectionCurrentCount;
    public int collectionLastCount;
    public int uniqueid;
    public int id;
    public int quaility;
    public int worn;
    public int stattrak;


}
[Serializable]
public class saveInfo
{
    
}
namespace ConsoleApplication2 
{
    
    
           
    class Program
    {
        static void Main(string[] args)
        {
            IniFile cfg = new IniFile("config.cfg");
            string  FILE_PATH = cfg.ReadINI("Pathes", "plr_wpn_path");
            string  CSGO_PATH = cfg.ReadINI("Pathes", "csgo_path");
            IniFile csgo_cfg = new IniFile(CSGO_PATH+"7lcfg_csgo.ini");
           
            string[] ranks = new string[]
            {
                "Silver I",
                "Silver II",
                "Silver III",
                "Silver IV",
                "Silver Elite",
                "Silver Elite Master",
                "Gold Nova I",
                "Gold Nova II",
                "Gold Nova III",
                "Gold Nova Master",
                "Master Guardian I",
                "Master Guardian II",
                "Master Guardian Elite",
                "Distinguished Master Guardian",
                "Legendary Eagle",
                "Legendary Eagle Master",
                "Supreme Master First Class",
                "Global Elite"
                
            };
            Serializetest objectToSerialize;
            saveInfo objectToSerialize2;
            
            Console.Title = "cs_sim2csgo";
            Console.WriteLine("CS_Sim2CS:GO v0.1.0");
            Console.WriteLine("Deserializing playerWeapons.dat...");
            
            Stream stream = File.Open(FILE_PATH, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (Serializetest)bFormatter.Deserialize(stream);
            Console.WriteLine(objectToSerialize.nickname);
            Console.WriteLine("Avatar: "+objectToSerialize.currentAvatar);
            Console.WriteLine("Level: "+ranks[objectToSerialize.currentLevel]);
            Console.WriteLine("XP: "+objectToSerialize.currentXP);
            Console.WriteLine("Gem: "+objectToSerialize.currentGem);
            Console.WriteLine("shopXP: "+objectToSerialize.shopXP);
            Console.WriteLine("colectionItemz: "+objectToSerialize.collectionItemsz.Length);
          /*foreach (var i in objectToSerialize.collectionItemsz)
            {
                Console.Write(i+", ");
            }*/
            
            Console.WriteLine("collectionScanned: "+objectToSerialize.collectionScanned);
            Console.WriteLine("collectionCurrentCount: "+objectToSerialize.collectionCurrentCount);
            Console.WriteLine("collectionLastCount: "+objectToSerialize.collectionLastCount);
            Console.WriteLine(objectToSerialize.uniqueid);
            Console.WriteLine(objectToSerialize.id);
            Console.WriteLine(objectToSerialize.quaility);
            Console.WriteLine(objectToSerialize.worn);
            Console.WriteLine(objectToSerialize.stattrak);
            stream.Close();
            Console.WriteLine("Configurating 7lcfg_csgo.ini...");
            csgo_cfg.Write("GameSettings", "GamePlayerName",objectToSerialize.nickname);
            csgo_cfg.Write("GameSettings", "GameRankLevel",(objectToSerialize.currentLevel+1).ToString());
            
            
           /* Stream stream2 = File.Open("playerWeapons.dat", FileMode.Open);
            BinaryFormatter bFormatter2 = new BinaryFormatter();
            objectToSerialize2 = (saveInfo)bFormatter2.Deserialize(stream2);
            Console.WriteLine(objectToSerialize2.uniqueid);
            stream2.Close(); */

           Console.ReadLine();
        }

      

       
    }
}