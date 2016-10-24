using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using WMPLib;

namespace MUD
{
	/**
	 * Contains all data and other information that have to be listed somewhere
	 */
	static class Data
	{
		public static Map world = new Map();
		public static Room getRoom(int id)
		{
			return world.Rooms[id];
		}
		public static Room room()
		{
			return world.Rooms[Player.room];
		}

		public static DiffWeapons weapons = new DiffWeapons();
		public static List<Chest> chests = new List<Chest>();
		public static List<Monster> monsters = new List<Monster>();


		/*public static WindowsMediaPlayer door = new WindowsMediaPlayer();
		public static WindowsMediaPlayer mon = new WindowsMediaPlayer();
		public static WindowsMediaPlayer spid = new WindowsMediaPlayer();*/

		public static SoundPlayer du = new SoundPlayer(@"..\du.wav");



		//Command lists
		public static List<string> showInv = new List<string>();
		public static List<string> move = new List<string>();
		public static List<string> attack = new List<string>();
		public static List<string> dodge = new List<string>();
		public static List<string> think = new List<string>();

		public static void addCommands()
		{
			showInv.Add("inv");
			showInv.Add("inventory");
			showInv.Add("stat");

			move.Add("go");
			move.Add("move");
			move.Add("travel");
			move.Add("traverse");

			attack.Add("attack");
			attack.Add("fight");
			attack.Add("hit");
			attack.Add("kill");
			attack.Add("slay");

			dodge.Add("dodge");
			dodge.Add("defend");
			dodge.Add("shield");

			think.Add("think");
			think.Add("meditate");
			

			Interface.directions.Add("north");
			Interface.directions.Add("ssouth");
			Interface.directions.Add("east");
			Interface.directions.Add("west");
			Interface.directions.Add("up");
			Interface.directions.Add("down");
			Interface.directions.Add("right");
			Interface.directions.Add("left");
			Interface.directions.Add("n");
			Interface.directions.Add("s");
			Interface.directions.Add("e");
			Interface.directions.Add("w");
			Interface.directions.Add("u");
			Interface.directions.Add("d");
			Interface.directions.Add("r");
			Interface.directions.Add("l");
		}

		public static void addData()
		{
			chests.Add(new Chest(50, weapons.GetRandomWeapon()));
			chests.Add(new Chest(0, weapons.GetRandomWeapon()));
			chests.Add(new Chest(700, null));
			
			monsters.Add(new Monster(1, "Rat", 10, 2));
			monsters.Add( new MUD.Monster(8, "Spider", 64, 8));


			//Background music paths
			//This only works using absolute path. Therefore, I have to< get the parent directory of the local directory and then add the file. GetCurrentDirectory does not work
			/*door.URL = System.IO.Directory.GetParent(@"..\") + @"\Door.aiff";
			door.controls.stop();
			mon.URL = System.IO.Directory.GetParent(@"..\") + @"\Monsters.wav";
			mon.controls.stop();
			spid.URL = System.IO.Directory.GetParent(@"..\") + @"\theme.wav";
			spid.controls.stop();*/

			BM.addTrack("door", @"\Door.aiff");
			BM.addTrack("mon", @"\Monsters.wav");
			BM.addTrack("spid", @"\theme.wav");
		}

		public static void createWorld()
		{
			//Creates test world
			Data.world.addRoom(1, null, null, "You stand in a dark room with two doors. What will you do?");
			Data.world.addRoom(2, chests[0], null, "Another dark room.");
			Data.world.addRoom(3, chests[2], monsters[0], "This room is bright");
			Data.world.addRoom(4, null, monsters[0], "There is only the door you came in through. This looks like a trap!");
			Data.world.addRoom(5, null, monsters[1], "This room is filled with cobwebs");
			Data.getRoom(1).addEdge("north", new Edge(Data.getRoom(2)));
			Data.getRoom(2).addEdge("south", new Edge(Data.getRoom(1)));
			Data.getRoom(3).addEdge("west", new Edge(Data.getRoom(2)));
			Data.getRoom(1).addEdge("east", new Edge(Data.getRoom(3)));
			Data.getRoom(2).addEdge("north", new Edge(Data.getRoom(4)));
			Data.getRoom(4).addEdge("south", new Edge(Data.getRoom(2)));
			Data.getRoom(1).addEdge("south", new Edge(Data.getRoom(5)));
			Data.getRoom(5).addEdge("north", new Edge(Data.getRoom(1)));
			
		}
	}


	//Background music. 
	/**
	 * Controls:
	 *		Add a track with ex BM.addTrack("door", @"\Door.aiff");
	 *		Play a track with ex BM.play("door");
	 *		Stop a track with ex BM.stop("door");
	 *		You need to wait 150 milliseconds before stopping a track.
	 *		
	 *	DON'T AKS. IT WORKED THE FIRST TIME, SO IT WAS MENT TO BE!
	 */
	public static class BM
	{
		public static Dictionary<string, music> tracks = new Dictionary<string, music>();
		public static void addTrack(string name, string path)
		{
			tracks.Add(name, new music(path));
			tracks[name].track.settings.setMode("loop", true);
		}
		public static void play(string trackName)
		{
			//Defining the URL plays the music from the start
			tracks[trackName].track.URL = tracks[trackName].path;
			
		}
		public static void stop(string trackName)
		{
			//I use pause, because stopping ruins the sound player, and possible other things too
			tracks[trackName].track.controls.stop();
		}
		public static void contin(string trackName)
		{
			//Continues paused music. (I didn't actually test this)
			tracks[trackName].track.controls.play();
		}

	}
	public class music
	{
		public string path;
		public WindowsMediaPlayer track = new WindowsMediaPlayer();
		public music(string pathToTrack)
		{
			path = System.IO.Directory.GetParent(@"..\") + pathToTrack;
			
		}
	}
}
