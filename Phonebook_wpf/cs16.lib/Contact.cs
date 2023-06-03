
using System.IO;

namespace cs16.lib;
public class Contact
{
    public static List<Person> contacts;

     public Contact(string filename)
     {
         contacts = new List<Person>();
          string[] lines = File.ReadAllLines(filename);
        foreach(var line in lines)
        {
            var toks = line.Split(',');
            Person p = new Person (toks[0],toks[1],toks[2],toks[3]);
            contacts.Add(p);
        }
     }



    public static string delete(string name)
    {
        Person fp = null;
        foreach (var p  in contacts)
        {
            if (p.Firstname == name)
            {
                fp = p;
                break;
            }
        
        }
        if (fp == null)
        {
            return "not found";
        }
        contacts.Remove(fp);
        refreshfile();
        return allcontacts();
    }
    public static string allcontacts()
    {
     string result = "";
     foreach (var c in contacts)
     {
         result += c.ToString() + "\n";
     }
     return result;
    }

    public static string Add2(string fname ,string lname ,string phn ,string email)
    {
        Person np =new Person(fname,lname,phn,email);
        contacts.Add(np);
        refreshfile();
        return allcontacts();
    }

    public static void refreshfile()
    {
        File.WriteAllLines("contacts.csv",ToString1());
    }

  public static IEnumerable<string> ToString1()
    {
        List<string> pm = new List<string>();
        foreach (var p in contacts)
        {
            pm.Add(string.Join(',',p.Firstname,p.Lastname,p.Phonenumber,p.Email));
        }
        return pm;
    }
    public static string  searchphonenumber(string name)
    {
        foreach (var c in contacts)
        {
            if (name == c.Firstname || name == c.Lastname)
                return c.ToString();
        }
                return "not found";
        
    }

}
