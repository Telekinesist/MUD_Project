
using System.Collections.Generic;
using System.Media;
using WMPLib;

namespace MUD
{
	/**
	 * Contains all data and other information that have to be listed somewhere
	 */
	static class Data
	{
		public static bool makeNoise = false;
		public static Map world = new Map();
		public static Room getRoom(int id)
		{
			return world.Rooms[id];
		}
		public static Room room()
		{
			return world.Rooms[Player.room];
		}
		public static void addRoom(int roomId, Chest b = null, Monster c = null, string description = "")
		{
			world.addRoom(roomId, b, c, description);
		}
		//Links two rooms together
		public static void addEdge(int room1, int room2, string directionTag, string description = "")
		{
			world.Rooms[room1].addEdge(world.Rooms[room2], directionTag, description);
			world.Rooms[room2].addEdge(world.Rooms[room1], directionTag, description);
		}

		public static DiffWeapons weapons = new DiffWeapons();
		public static List<Chest> chests = new List<Chest>();
		public static List<Monster> monsters = new List<Monster>();

		public static SoundPlayer du = new SoundPlayer(@"..\du.wav");



		//Command lists
		public static List<string> showInv = new List<string>();
		public static List<string> move = new List<string>();
		public static List<string> attack = new List<string>();
		public static List<string> dodge = new List<string>();
		public static List<string> think = new List<string>();
		public static List<string> load = new List<string>();
		public static List<string> newGame = new List<string>();

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

			load.Add("load");
			load.Add("continue");

			newGame.Add("new game");
			newGame.Add("new");


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
			monsters.Add(new Monster(8, "Spider", 64, 8));
			monsters.Add(new Monster(1, "Grumpy monster", 10, 1, true));

			//Adds tracks and their paths
			BM.addTrack("door", @"\Door.mp3");
			BM.addTrack("mon", @"\Monsters.mp3");
			BM.addTrack("spid", @"\theme.mp3");

			BM.addSound("go", @"\OpenClose.wav");
			BM.addSound("heal", @"\Heal.wav");
			BM.addSound("pickUp", @"\PickUp.wav");
		}

		public static void createWorld()
		{
			//Creates test world
			/*addRoom(1, null, null, "You stand in a dark room with two doors. What will you do?");
			addRoom(2, chests[0], null, "Another dark room.");
			addRoom(3, chests[2], monsters[0], "This room is bright");
			addRoom(4, null, monsters[0], "There is only the door you came in through. This looks like a trap!");
			addRoom(5, null, monsters[1], "This room is filled with cobwebs");
			getRoom(1).addEdge("north", new Edge(getRoom(2)));
			getRoom(2).addEdge("south", new Edge(getRoom(1)));
			getRoom(3).addEdge("west", new Edge(getRoom(2)));
			getRoom(1).addEdge("east", new Edge(getRoom(3)));
			getRoom(2).addEdge("north", new Edge(getRoom(4)));
			getRoom(4).addEdge("south", new Edge(getRoom(2)));
			getRoom(1).addEdge("south", new Edge(getRoom(5)));
			getRoom(5).addEdge("north", new Edge(getRoom(1)));*/

			//Creates the game world
			//Monsters and chests not included untill Cim "fix" the lists
			//Each path is split into hundrets. Each subpath is split into tenths. That way it is easy to keep track of the branching rooms.
			addRoom(0, null, monsters[2], "You wake up");
			addRoom(100, null, null, "A forest");
			addRoom(200, null, null, "Bright room");
			addRoom(300, null, null, "");
			addRoom(301, null, monsters[0], "This; Room - is on faiyeaaaaaaa.\n...Crap.");
			addRoom(302, null, null, "You stand in a very cold room");
			addRoom(303, null, null, "\"This room has furniture!\" you think to yourself after you have calmed down over the shock.\nYou almost couldn't see the furniture for the sheer ammounts of cats");
			addRoom(304, null, null, "You exit a vomatorium into a stadium. It seems to be the olympics.");
			addRoom(305, null, monsters[1], "Oooh. This is a decently equipped weapon arsenal");
			//Prop spelled wrong. Add win feature thing for this room
			addRoom(306, null, null, "You stand in a brobdbargianly large hallway");
			addRoom(310, null, monsters[0], "It REALLY smells in here");
			addRoom(311, null, null, "You can hear... A bird?");

			addEdge(0, 300, "old", "old door");
			//Custom edge
			world.getRoomById(300).edges[0] = new Edge(world.getRoomById(0), "back", "back to the room you woke up in");
			addEdge(0, 200, "new", "brand new door");
			addEdge(0, 100, "rust", "rusted old door. This one probably makes a loud noise if you try to open it");
		}
	}

	/**
	 * Background Music
	 * Uses windows media player (sorry. I'm not feeling like importing a sound library)
	 * 
	 * Controls:
	 *		Add a track with ex BM.addTrack("door", @"\Door.aiff");
	 *		Play a track with ex BM.play("door");
	 *		Stop a track with ex BM.stop("door");
	 *		You need to wait 150 milliseconds before stopping a track.
	 *		
	 *	DON'T AKS. I KNOW HOW IT LOOKS. IT WORKED THE FIRST TIME, SO IT WAS MENT TO BE! (Again, sorry)
	 */
	public static class BM
	{
		//Dictionary with all music tracks
		public static Dictionary<string, music> tracks = new Dictionary<string, music>();
		//Adds a piece of music
		public static void addTrack(string name, string path)
		{
			tracks.Add(name, new music(path));
			tracks[name].track.settings.setMode("loop", true);
		}
		//These are inteded for sounds that play once.
		public static void addSound(string name, string path)
		{
			tracks.Add(name, new music(path));
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
			//Continues paused music. (I didn't actually test this. I don't need it)
			tracks[trackName].track.controls.play();
		}

	}

	/**
	 * Music object for background music.
	 * Contains name (for reference) and path
	 */
	public class music
	{
		public string path;
		public WindowsMediaPlayer track = new WindowsMediaPlayer();
		public music(string pathToTrack)
		{
			//Gets the path to parent directory and adds the local file path
			path = System.IO.Directory.GetParent(@"..\") + pathToTrack;
		}
	}
}
