using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLoader {
	private readonly static string[] LEFT_BRACKET = { "[" };
	private readonly static string[] RIGHT_BRACKET = {"]"};
	private readonly static string[] ENDLINES = { "\n", "\r\n", System.Environment.NewLine };
	private readonly static string[] ASSIGN_CHAR = { "=" };
	//private readonly static string[] ENCLOSING_CHAR = { "/" };
	private const char ENCLOSING_CHAR = '/';
	private const string LABEL_DIALOG = "dialog";
	private const string LABEL_MESSAGE = "say";
	private const string LABEL_QUEST = "quest";
	private const string LABEL_CHOICE = "choice";
	private const string LABEL_TELEPORT = "teleport";
	private const string LABEL_DELAY = "delay";
	private const string LABEL_OPTION = "option";
	private const string KEY_DIALOG_ID = "id";
	private const string KEY_ALLOW_RESUME = "resume";
	private const string KEY_REPEATABLE = "repeat";
	private const string KEY_SOURCE = "src";
	private const string KEY_TEXT = "text";
	public class DialogBlock {
		internal string id;
		internal bool repeat = false;
		internal bool resume = true;
		List<IDialogPart> sequence;
	}
	private interface IDialogPart {
		//void Show();
	}
	private class DialogMessage : IDialogPart {
		internal string source;
		internal string text;
		public DialogMessage(string data) {
			string[] lines = data.Split(ENDLINES, System.StringSplitOptions.RemoveEmptyEntries);
			foreach(string line in lines) {
				string[] divided = line.Split(ASSIGN_CHAR, System.StringSplitOptions.None);
				switch (divided[0]) {
					case KEY_SOURCE:
						source = divided[1];
						break;
					case KEY_TEXT:
						text = divided[1].Replace("\"","");
						break;
					default:
						Debug.Log("Invalid key \""+divided[0]+"\" in <"+LABEL_MESSAGE+"> tag");
						break;
				}
			}
		}
	}
	private class DialogTeleport : IDialogPart {
		internal const string KEY_LOCATION = "level";
		internal const string KEY_STARTING_POINT = "start";
		internal string location;
		internal string startingPoint;
	}
	private class DialogChoice : IDialogPart {
		internal const string KEY_HEADER = "header";
		internal string source;
		internal string text;
		internal string header;
		List<DialogChoiceOption> options;
	}
	private class DialogQuest : IDialogPart {
		internal enum BehaviourOnAccept {
			BREAK,//quit dialog, default resume settings
			CONTINUE,//continue dialog as before (no impact)
			BREAK_NO_RESUME,//quit dialog, disallow resuming
			BREAK_RETURN_LATER,//quit dialog, allow to resume later
			ENTER_BREAK,//enter quest lines, then quit dialog (default resume settings)
			ENTER_RESUME,//enter quest lines, then resume dialog
		}
		private const string KEY_ACCEPT_TEXT = "accept_text";
		private const string KEY_DECLINE_TEXT = "decline_text";
		private const string KEY_REJECTABLE = "decline_text";
		private const string KEY_QUEST_ID = "quest";
		private const string KEY_BEHAVIOUR_ON_ACCEPT = "then";
		string source;
		string acceptText;
		string declineText;
		bool rejectable;
		string questID;
	}
	private class DialogChoiceOption {
		private const string KEY_NEXT_DIALOG = "dest";
		private const string KEY_RETURN_ON_END = "return";
		string text;
		bool retunOnEnd;
		string nextDialog;
	}
	private static bool ParseBool(string s) {
		if (s == "yes" || s == "true") return true;
		else return false;
	}
	public static List<DialogBlock> LoadDialog(TextAsset dialogFile) {
		List<DialogBlock> data = new List<DialogBlock>();
		string[] separated = dialogFile.text.Split(LEFT_BRACKET, System.StringSplitOptions.None);
		DialogBlock currentDialogBlock = null;
		for (int ii = 0; ii < separated.Length; ii++) {
			if (currentDialogBlock == null) {
				string[] divided = separated[ii].Split(RIGHT_BRACKET, System.StringSplitOptions.None);
				if (divided.Length > 2) Debug.Log("Found spare > character");
				else if (divided[0] != LABEL_DIALOG) Debug.Log("Invalid XML label, expected <dialog> in toplevel");
				else {
					currentDialogBlock = new DialogBlock();
					data.Add(currentDialogBlock);
				}
			}
			else {
				if (separated[ii][0] == ENCLOSING_CHAR) {
					if (separated[ii].StartsWith(ENCLOSING_CHAR + LABEL_DIALOG)) {
						currentDialogBlock = null;
					}
					else {
						string[] divided = separated[ii].Split(RIGHT_BRACKET, System.StringSplitOptions.None);
						divided = divided[1].Split(ENDLINES,System.StringSplitOptions.RemoveEmptyEntries);
						foreach(string s in divided) {
							string[] div = s.Split(ASSIGN_CHAR, System.StringSplitOptions.None);
							switch (div[0]) {
								case KEY_DIALOG_ID:
									currentDialogBlock.id = div[1];
									break;
								case KEY_REPEATABLE:
									currentDialogBlock.repeat = ParseBool(div[1]);
									break;
								case KEY_ALLOW_RESUME:
									currentDialogBlock.resume = ParseBool(div[1]);
									break;
								default:
									Debug.Log("Invalid key \"" + div[0] + "\" in <" + LABEL_DIALOG + "> tag");
									break;
							}
						}
					}
				}
				else {
					ReadDialogPart(ref separated, ref ii);
				}
			}
		}
		return data;
	}
	private static IDialogPart ReadDialogPart(ref string[] parts,ref int current) {
		IDialogPart result = null;
		string[] divided = parts[current].Split(RIGHT_BRACKET, System.StringSplitOptions.None);
		switch (divided[0]) {
			case LABEL_DIALOG:
				Debug.Log("Invalid XML label, <dialog> only allowed in toplevel");
				break;
			case LABEL_MESSAGE:
				result = new DialogMessage(divided[1]);
				break;
			case LABEL_CHOICE:
				//divided = divided[1].Split(ENDLINES, System.StringSplitOptions.RemoveEmptyEntries);
				break;
			case LABEL_QUEST:
				//divided = divided[1].Split(ENDLINES, System.StringSplitOptions.RemoveEmptyEntries);
				break;
			case LABEL_DELAY:
				//divided = divided[1].Split(ENDLINES, System.StringSplitOptions.RemoveEmptyEntries);
				break;
			case LABEL_TELEPORT:
				//divided = divided[1].Split(ENDLINES, System.StringSplitOptions.RemoveEmptyEntries);
				break;
			default:
				Debug.Log("Unrecognised tag: <"+divided[0]+">");
				break;
		}
		return result;
	}
}
