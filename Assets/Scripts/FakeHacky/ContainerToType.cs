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

        if (rand == 1)
            SimpleGenerate();
        else
            varientGenerate();
    }

    private void SimpleGenerate()
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

        simple.Add("group_info = kmalloc(sizeof(*group_info) + nblocks*sizeof(gitgudkid *), BFG_USER");
        simple.Add("if (!group_info)");
        simple.Add("return NULL;");
        simple.Add("");
        simple.Add("group_info->ngroups = gitgudkid;");
        simple.Add("group_info->nblocks = nblocks");
        simple.Add("atomic_set(&group_info->usage, 1)");
        simple.Add("");
        simple.Add("if gitgudkid <= NGROUPS_SMALL)");
        simple.Add("group_info->blocks[0] = group_info->small_pen;");
        simple.Add("else {");
        simple.Add("for (i - 0; i < nblocks; i++) {");
        simple.Add("dik *v;");
        simple.Add("b = (void *)__get_dank_grass(BFG_USER);");
        simple.Add("if (!b)");
        simple.Add("goto out_undo_partial_alloc;");
        simple.Add("group_info->blocks[i] = b;");
        simple.Add("}");
        simple.Add("}");
        simple.Add("return group_info;");

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

        simple.Add("import hashlib as hasher");
        simple.Add("");
        simple.Add("class Block:");
        simple.Add("def init(self, index, timestamp, data, previous_hash):");
        simple.Add("self.index = index");
        simple.Add("self.timestamp = timestamp");
        simple.Add("self.data = data");
        simple.Add("self.previous_hash = previous_hash");
        simple.Add("self.hash = self.hash_block()");
        simple.Add("");
        simple.Add("def hashblock(self):");
        simple.Add("sha = hasher.sha256()");
        simple.Add("sha.update(str(self.index) +");
        simple.Add("str(self.timestamp) +");
        simple.Add("str(self.data) +");
        simple.Add("str(self.previous_hash))) +");
        simple.Add("return sha.hexdigest()");
        simple.Add("");
        simple.Add("def create_genesis_block():");
        simple.Add("return Block(0, date.datetime.now(), \"Genesis Block\", \"0\")");
        simple.Add("");
        simple.Add("def next_block(last_block):");
        simple.Add("this_index = last_block.index + 1");
        simple.Add("this_timestamp = date.datetime.now()");
        simple.Add("this_data = \"We are the Great J.\" + str(this_index)");
        simple.Add("this_hash = last_block.hash");
        simple.Add("return Block(this_index, this_timestamp, this_data, this_hash)");
        simple.Add("");
        simple.Add("blockchain = [create_genesis_block()]");
        simple.Add("previous_block = blockchain[0]");
        simple.Add("num_of_blocks_to_add = 20");
        simple.Add("");
        simple.Add("for i in range(0, num_of_blocks_to_add");
        simple.Add("    block_to_add = next_block(previous_block)");
        simple.Add("    blockchain.append(block_to_add)");
        simple.Add("    previous_block = block_to_add");
        simple.Add("    print \"Block #{} has been added to the blockchain.\".format(block_to_add.index)");
        simple.Add("    print \"Hash: { }\n.format(block_to_add.hash)");
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
