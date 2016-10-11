using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MUD
{
	/**
	 * Handles savedata and settigns
	 */
	public static class Save
	{
		//Loads saved data
		//Set reset to 1 to load default values
		public static string[] load(byte reset = 0)
		{
			string[] data = new string[9];
			byte index = 0;
			XmlDocument x = new XmlDocument();
			x.Load(@"..\GameData.xml");
			data[index] = (x.DocumentElement.ChildNodes[reset].ChildNodes[0].Attributes["val"].Value);
			index++;
			data[index] = (x.DocumentElement.ChildNodes[reset].ChildNodes[1].ChildNodes[0].Attributes["val"].Value);
			index++;

			foreach(XmlAttribute cont in x.DocumentElement.ChildNodes[reset].ChildNodes[1].ChildNodes[1].Attributes)
			{
				data[index] = cont.Value;
				index++;
			}
			foreach (XmlAttribute cont in x.DocumentElement.ChildNodes[reset].ChildNodes[1].ChildNodes[2].Attributes)
			{
				data[index] = cont.Value;
				index++;
			}
			return data;
		}

		public static void printSave(string[] data)
		{
			foreach(string val in data)
			{
				C.d(val);
			}
		}
	}
}
