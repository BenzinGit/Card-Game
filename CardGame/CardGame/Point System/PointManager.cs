using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CardGame.Point_System
{
    internal static class PointManager
    {

        public static bool SavePoints(int points, int cash)
        {
            string xml = @"<Player> <Points>" + points+ " </Points>  <Cash> "+cash+" </Cash> </Player>   ";

            File.WriteAllText("playerstats.xml", xml);
            return true; 

        }



        public static Tuple<int, int> ReadPoints()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("playerstats.xml");


            XmlNode pointsNode = doc.DocumentElement.SelectSingleNode("/Player/Points");
            XmlNode cashNode = doc.DocumentElement.SelectSingleNode("/Player/Cash");

            int points = int.Parse(pointsNode.InnerText);
            int cash = int.Parse(cashNode.InnerText);



             return Tuple.Create(points, cash); 
        }


    }
}
