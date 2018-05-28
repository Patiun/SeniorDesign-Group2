using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct StringData
{
    public string NLetters { get; set; }
    public bool endOfLine { get; set; }
    public bool finish { get;set; }

    public StringData(string NLetters, bool endOfLine, bool finish = false)
    {
        this.NLetters = NLetters;
        this.endOfLine = endOfLine;
        this.finish = finish;
    }
}

public class ContainerToType
{

    public List<string> simple;
    public List<string> varient;

    private const int substringPull = 3;
    private int currentStringPosition;
    
    public ContainerToType()
    {
        simple = new List<string>();
        varient = new List<string>();
        currentStringPosition = 0;

        int rand = Random.Range(1, 2);

        //if (rand == 1)
        //    SimpleGenerate();
        //else
        //    varientGenerate();

        SimpleGenerate();
    }

    private void SimpleGenerate()
    {
        simple.Add("threestep_authcommand.bui");
        simple.Add("");
        simple.Add("");
        simple.Add("Username: greatj");
        simple.Add("Password: *************");

        simple.Add("ACCESS TO SYSTEM");
        simple.Add("");
        simple.Add("struedit.bui -r -s -unauth");
        simple.Add("syslog = false;");
        simple.Add("");
        simple.Add("struct group_info init_groups = .usage = ATOMIC_INIT(2);");
        simple.Add("");
        simple.Add("struct groupinfo *groups_alloc(int getsetsize){");
        simple.Add("");
        simple.Add("struct group_info *group_info;");
        simple.Add("int nblock;");
        simple.Add("int i;");
        simple.Add("");
        simple.Add("nblocks = (gidsetsize + NGROUPSPERBLOCK -1)/NGROUP_PER_BLOCK;");
        simple.Add("nblocks = nblocks ? : 1;");
        simple.Add("sexytime = true;");

        simple.Add("Exiting out...");
        simple.Add("TakeCtrl -x");
    }

    private void varientGenerate()
    {
        simple.Add("twoStep_authcommand.bui");
        simple.Add("");
        simple.Add("");
        simple.Add("Username: ZeroCool");
        simple.Add("Password: *************");

        simple.Add("ACCESS TO SYSTEM");
        simple.Add("");
        simple.Add("struedit.bui -r -s -unauth");
        simple.Add("syslog = false;");
        simple.Add("");
        simple.Add("struct group_info init_groups = .usage = ATOMIC_INIT(2);");
        simple.Add("");
        simple.Add("struct groupinfo *groups_alloc(int getsetsize){");
        simple.Add("");
        simple.Add("struct group_info *group_info;");
        simple.Add("int nblock;");
        simple.Add("int i;");
        simple.Add("");
        simple.Add("nblocks = (gidsetsize + NGROUPSPERBLOCK -1)/NGROUP_PER_BLOCK;");
        simple.Add("nblocks = nblocks ? : 1;");
    }

    public StringData GetNSizeLetters()
    {
        StringData data;
        if (simple.Count == 0)
        {
            data = new StringData("", true, true);
            return data;
        }
        

        int sizeToPull = substringPull;
        string sentence = simple[0];
        
        if (sizeToPull > sentence.Length)
        {
            sizeToPull = sentence.Length;
        }

        string nLetters = sentence.Substring(0, sizeToPull);
        string removeLetters = sentence.Remove(0, sizeToPull);
        
        
        if (removeLetters.Length == 0)
        {
            data = new StringData(nLetters, true);
            simple.RemoveAt(0);
        }
        else
        {
            data = new StringData(nLetters, false);
            simple[0] = removeLetters;
        }

        return data;
    }

}
