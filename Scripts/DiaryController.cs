using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiaryController : MonoBehaviour {

	//private variables
	private int pages = 20, 	//total pages in diary
				pageNumber = 0, //current page being viewed on left side
				pageChange = 2;	//turning the page increases page number by 2

	//private string array for diary entries
	private string[] diaryEntries;

	//public object references
	public Text EntryLeft, 			//text on left page
				EntryRight, 		//text on right page
				PageNumLeft, 		//page number of left page
				PageNumRight;		//page number of right page
	public GameObject menuControl;	//a stored reference to the menu controller

	// Use this for initialization
	void Start () {
		diaryEntries = new string[pages]; 	//instantiate array of length pages

		InitializeDiary ();					//initialize each index of the diary array

		setEntryText (pageNumber);			//set the visible diary entry text per index
	}

	//sets the left and right page entry text to the appropriate string from diaryEntries
	//input is page number of left page of diary
	void setEntryText(int entryNum){
		//set left side entry text and page number
		EntryLeft.text = diaryEntries [entryNum];
		PageNumLeft.text = setPageNumbers (entryNum);

		//increment page number
		entryNum++;	

		//set right side entry text and page number
		EntryRight.text = diaryEntries [entryNum];
		PageNumRight.text = setPageNumbers (entryNum);
	}

	//returns the correct page number for each page of the diary when called
	private string setPageNumbers(int pageNum){
		//shifts index page number by 1 to ensure page numbers start at 1
		return (pageNum + 1).ToString ();
	}

	//returns the player back to the main menu, i.e. exiting the diary
	public void closeDiary (){
		//calls swap menu function to disable the diary and reenable the main menu
		menuControl.GetComponent<SwapMenu> ().ChangeMenu ("main");
	}

	//public function called when player clicks on left side of left page "Turn Left" Button
	public void turnPageLeft(){
		//checks if diary is at entry 0
		if (pageNumber <= 0) {
			//in which case it sets the page number to the "last" entry
			pageNumber = pages;
		}

		//otherwise it decrements the page number by page change
		pageNumber -= pageChange;

		//and sets the entry text
		setEntryText (pageNumber);
	}

	//public function called when player clicks on right side of right page "Turn Right" Button
	public void turnPageRight(){
		//checks if player is at the end of the diary
		if ((pageNumber + pageChange) >= pages)
			//in which case it sets the page number to the "first" entry
			pageNumber = 0;
		else
			//otherwise it increments the page number by page change
			pageNumber += pageChange;

		//and sets the entry text
		setEntryText (pageNumber);
	}

	// Update is called once per frame
	void Update () {
		//do nothing
	}

	//quick and dirty initializing of diary entry array
	void InitializeDiary(){
		//first clears the text so the diary appears blank until a proper entry can be displayed
		EntryLeft.text = "";
		EntryRight.text = "";
		PageNumLeft.text = "";
		PageNumRight.text = "";

		//first pass through the diary initializes every entry to blank space
		for (int i = 0; i < pages; i++) {
			diaryEntries [i] = "";
		}

		//hard coded diary entries for examples.....
		diaryEntries [0] = "December 3rd, 2023\n\n\n" +
			"This was the day I discovered my powers.  It was just another Sunday I was 6 years old watching some kiddie show.  I remember watching a firefly go across the screen for some reason I tried to recreate it.  What started out as simple playing and childhood wonder turned into a glow in my hands.  Now as a kid I ran to go show my parents, I now question that decision...";
			
		diaryEntries [1] = "January 23, 2024\n\n\n" +
			"Another failed audition for a television show.  This made thee in a row.  Yeah I know I didn't write about the other two but this was the day I tuned 7 and the first in a long string of birthdays that my parents would forget in light of failures to show any kind of interesting or 'snazzy' power.  I guess a faint light just isn't interesting enough for people today.  If I was older this would have been something I would have known.  But this was also the day I was able to solidify the form a bit.  yay...";

		diaryEntries [2] = "April 15, 2024\n\n\n" +
			"Well this was the day I finally figured out why going to school was important, they have real teachers that give a damn about your education.  My parents received a call from what I now assume to be the police about pulling me out of school and not teaching me anything.  So they decided the best course of action was to home school me.  To them this meant that I spend all my time honing  my powers and they pretend I do school work.  this pretty much ended the rest of my social interaction with my peers for a while.";

		diaryEntries [8] = "February 4th, 2038...\n\n\n" +
			"My Doctor said it would be beneficial to keep a log of my daily events like a diary and to reflect on any significant days in my childhood.  Personally I do not see the importance but he says there is some good reason for it so who am I to argue, he's the one that went to college for this stuff.";

		diaryEntries [9] = "April 4, 2038\n\n\n" +
			"Damn, I woke up in a strange place again, I did this last week too, and I don't even remember drinking again.  Maybe I should tell my therapist but it isn't really his business about my party nights. But this time I had to walk over 4 miles just to get back to my apartment.  There wasn't even a bar nearby how long did I walk.";
		diaryEntries [10] = "May 26, 2038\n\n\n" +
			"My doctor says I need to be more upbeat, but how can I do that when I keep waking up in strange places.  Today as the third time this week and it is starting to piss me off.  I had to go into work in my pajamas because I would have been late otherwise.  I think I might need help for my apparent drinking problem, especially since I always tend to black out and don't remember the night before.  The sad part is I might be more used to waking up in an alley than my own bed.";
		diaryEntries [11] = "June 16, 2038\n\n\n" +
			"well after the tenth consecutive day of waking up not in my house I decided to go get some help so  went to rehab.  It didn't really work out that well especially since  never buy alcohol and have no recollection of going to a bar.  But I did get a 'sober companion' so maybe I can decease my alley sleeping schedule to once a month at most. Oh, I also found a new pet on the way home so maybe today will start looking up for me.";
	}
}
