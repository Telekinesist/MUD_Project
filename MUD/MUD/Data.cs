
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
		//Variable for custom actions
		public static bool tookAction = true;


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
			move.Add("open");
			move.Add("pass");

			attack.Add("attack");
			attack.Add("fight");
			attack.Add("hit");
			attack.Add("kill");
			attack.Add("slay");
			attack.Add("slaughter");

			dodge.Add("dodge");
			dodge.Add("defend");
			dodge.Add("shield");

			think.Add("think");
			think.Add("meditate");
			think.Add("use braincells");

			load.Add("load");
			load.Add("continue");

			newGame.Add("new game");
			newGame.Add("new");
		}

		public static void addData()
		{
			chests.Add(new Chest(50, weapons.GetRandomWeapon(95, 97, 98, 99, 100)));
			// stor sandsyglig hed for et junk og common våben
			chests.Add(new Chest(0, weapons.GetRandomWeapon(50, 97, 98, 99, 100)));
			// lige stor sandsyglighed for at få et junk og common våben
			chests.Add(new Chest(0, weapons.GetRandomWeapon(25, 97, 98, 99, 100)));
			// størge sandsyglighed for at få et common våben men stadigvæk for junk. 
			chests.Add(new Chest(0, weapons.GetRandomWeapon(1, 97, 98, 99, 100)));
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
			monsters.Add(new Monster(100, "Dragon", 200, 15));
			monsters.Add(new Monster(75, "Ogre", 175, 13));
			monsters.Add(new Monster(1, "Grumpy monster", 10, 1, true));
			monsters.Add(new Monster(20, "Hairy Cat", 35, 2));
			monsters.Add(new Monster(43, "Nazi Übersturmbahn Führer", 100, 9));


			//Adds tracks and their paths
			BM.addTrack("door", @"\Door.mp3");
			BM.addTrack("mon", @"\Monsters.mp3");
			BM.addTrack("spid", @"\theme.mp3");
			BM.addTrack("instructions", @"\comm_shipnode.mp3");

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
			addRoom(0, null, monsters[5], "You wake up");
			getRoom(0).customOption = "sleepy_monster_rust_door";
			addRoom(100, null, null, "A forest. Wait, aren't I in a dungeon??");
			addRoom(101, null, monsters[1], "A new monster? Seriously?");
			addRoom(112, chests[1], null, "You look around, stunned. So many books!!!");
			addRoom(113, null, null, "You grow a pair of glasses and a lot of zits. You begin to slouch and correct everyone who isn't completely right");
			addRoom(114, chests[2], null, "You walk out into the light, gretted by a pair of fellow geeks. They point you to their D&D van. You are finally free. I guess?");
			addRoom(121, chests[1], monsters[1], "Your hand slowly begins to ascend into the wellknown salute, and on your arms grows a red armband with the forbidden insignia. Heil!");
			addRoom(122, chests[1], null, "Disgusted by the last rooms experience, you look around to see... Weapons? A whole lot of weapons? Sweet!");
			addRoom(130, null, null, "The door slams behind you, and the room goes dark. Uanble to re-open the door, you accept your fate... An eternity in lockdown.");
			addRoom(200, null, null, "You have always seen things from the bright side, however, this is really just too much brightness");
			addRoom(201, null, monsters[1], "Oh snap, a snappy monster!");
			addRoom(202, null, null, "You are brought back to the eighties through the might of Disco! Saaay.... That's actually kind of a catchy rythm");
			addRoom(203, null, null, "Your inner straightness begins to scream as you walk into the slightly boisterous, gay nightclub. What a sight!");
			addRoom(204, null, monsters[1], "Dang, a monster!");
			addRoom(250, null, monsters[2], "The door simply said BOSS");
			addRoom(251, chests[1], null, "You hear a familiar buzzing noise coming from that weird apperatus over there. Slowly you step into it and SWOOP! You appear to have teleported to freedom.");
			addRoom(300, null, null, "You press your whole weight against the door, and it makes a loud shriek as it slowly opens. You look into the next room, only to face another grim looking creature, this time fully awake. As if that wasn’t enough, you hear that the slumbering creature behind you is not slumbering any more. It starts to run against you, and you cry out loud with closed eyes as it leaps against you. To your big surprise, the creature doesn’t attack you, but rather the creature in the new room. Baffled, you watch them tear at each other, until the the formerly sleeping one stands victorious. You watch in silence as it walks back, and lies down to continue you sleeping. As you turn you back to it to continue forward, it seems as though it blinks at you.");
			addRoom(311, null, monsters[1], "Fack, a friggin' mobster!");
			addRoom(312, null, monsters[0], "This; Room - is on faiyeaaaaaaa.\n...Crap.");
			addRoom(313, null, null, "Although you have always yearned to be cool, this cool might be a tad too much. The ice dripping from your nose is a nice touch tho!");
			addRoom(314, null, null, "\"This room has furniture!\" you think to yourself after you have calmed down over the shock. You almost couldn't see the furniture for the sheer ammounts of cats");
			addRoom(315, null, null, "You exit a vomatorium into a stadium. It seems to be the olympics.");
			addRoom(316, null, monsters[1], "Oooh. This is a decently equipped weapon arsenal");
			addRoom(317, null, null, "You can feel the fresh air as you walk out into the light. You are finally free from the weird dungeon system");
			//Prop spelled wrong. Add win feature thing for this room
			addRoom(321, null, null, "The room has no floor, only water. You will have to swim to get to the next door.");
			addRoom(322, null, null, "Im so HOT, HOT damn! Literally, it's friggin' hot in here");
			addRoom(323, null, null, "A very green lookin' fella with pointy ears greet you. What even is this, some kind of LoTR rip-off?");
			addRoom(324, chests[1], null, "You can't see shit in here! Oh wait, don't we have PG rating? Fuck! Damn, did it again! Oh bugger...");
			addRoom(325, chests[1], null, "All around you is GOLD! SO MUCH GOLD! MUAHAAHAH, I'M RICH!!");
			addRoom(326, null, null, "You realize that everthing uptil now has just been a ruse. You feel your life being drained from you very being, slowly fading away...");
			addRoom(330, null, monsters[0], "It REALLY smells in here. Oh. That's an ogre...");


			addEdge(0, 300, "old", "old door");
			//Custom edge
			world.getRoomById(300).edges[0] = new Edge(world.getRoomById(0), "back", "back to the room you woke up in");
			addEdge(300, 311, "something", "leads to something");
			addEdge(311, 312, "red", "very red handle");
			addEdge(312, 313, "cool", "very cold handle");
			addEdge(313, 314, "cat", "miawing door");
			addEdge(314, 315, "roman", "door with roman numerals");
			addEdge(315, 316, "sharp", "door with sharp handle");
			addEdge(300, 321, "wet", "door with wet handle");
			addEdge(321, 322, "hot", "very hot handle");
			addEdge(322, 323, "text", "handle with weird text on it");
			addEdge(323, 324, "fog", "fog emmintaing from the door");
			addEdge(324, 325, "gold", "door with golden handle");
			addEdge(325, 326, "normal", "strikingly normal door");
			addEdge(323, 330, "smell", "door with a strong smell");
			addEdge(330, 316, "sharp", "door with sharp handle");
			addEdge(0, 200, "new", "brand new door");
			addEdge(200, 201, "shiny", "shiny keyhole");
			addEdge(201, 202, "sound", "sound comes from the door");
			addEdge(202, 203, "dildo", "dildo as handle");
			addEdge(203, 204, "regular", "regular looking door");
			addEdge(204, 250, "boss", "door with BOSS written on it");
			addEdge(0, 100, "rust", "rusted old door. This one probably makes a loud noise if you try to open it");
			addEdge(100, 101, "funny", "funny looking door");
			addEdge(101, 112, "book", "booklike door");
			addEdge(112, 113, "grimy", "grimy doorhandle");
			addEdge(113, 114, "D&D", "door with D&D logo");
			addEdge(113, 121, "nazi", "red door with swastika");
			addEdge(121, 122, "gun", "gunhandle on the door");
			addEdge(122, 130, "bars", "door with bars");
			addEdge(250, 130, "bars", "door with bars");
			addEdge(250, 251, "buzz", "door that buzzes");

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
