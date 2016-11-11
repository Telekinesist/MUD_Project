
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
			chests.Add(new Chest(50, weapons.GetRandomWeapon(95,97,98,99,100)));
            // stor sandsyglig hed for et junk og common våben
			chests.Add(new Chest(0, weapons.GetRandomWeapon(50,97,98,99,100)));
            // lige stor sandsyglighed for at få et junk og common våben
            chests.Add(new Chest(0, weapons.GetRandomWeapon(25, 97, 98, 99, 100)));
            // størge sandsyglighed for at få et common våben men stadigvæk for junk. 
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1,97,98,99,100)));
            // MEGET stor sandyslighed for common 
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 50, 98, 99, 100)));
            // lige stor sandsyglighed fopr common og rare 
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 25, 98, 99, 100)));
            // stor sandsyglighed for rare men stadigvæk sandsyglighed for common
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 2, 98, 99, 100)));
            //MEGET STOR sandsyglighed for et rare våben 
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 2, 50, 99, 100)));
            // lige stor sandsyglighed for rare og epic
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 2, 25, 99, 100)));
            // stor sandsyglighed for epic men en elle sandsyglighed for rare. 
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 2, 3, 99, 100)));
            // MEGET stor sandyslighed for epic 
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 2, 3, 50, 100)));
            // lige stor sandsyglighed for epic og legendery.
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 2, 3, 25, 100)));
            // stor sandsyglig hed for legedary men også en lille sandsyglig for legendary.
            chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 2, 2, 3, 100)));
            //MEGET STOR SANDSYGLIGHED FOR ET MEGA AWESOME VÅBEN. 

            chests.Add(new Chest(50, null));
            chests.Add(new Chest(25, null));


			monsters.Add(new Monster(1, "Rat", 10, 2));
            monsters.Add(new Monster(2, "Bigger Rat", 15, 4));
			monsters.Add(new Monster(8, "Spider", 64, 8));
            monsters.Add(new Monster(13, "Bat", , ));
            monsters.Add(new Monster(100, "Dracon", 200, 15));
             monsters.Add(new Monster(75, "Ogre",175,13));

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
