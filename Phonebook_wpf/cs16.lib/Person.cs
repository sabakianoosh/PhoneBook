namespace cs16.lib;
public class Person
{
    
    public string Lastname {get; private set;}
    public string Phonenumber {get;private set;}
    public string Email {get; private set;}
    public string Firstname {get; private set;}


    public Person(string firstname,string lastname,string phonenumber,string email)
    {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Phonenumber = phonenumber;
        this.Email = email;
    }

     public override string ToString()
    {
        return $"{this.Firstname},{this.Lastname},{this.Phonenumber},{this.Email}";
    }
   public static  Person Parse(string line)
   {
       var token = line.Split(',');
       return new Person(token[0],token[1],token[2],token[3]);
   }
}
