using cs16.lib;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
Contact List = new Contact("contacts.csv");

app.MapGet("/", Contact.allcontacts);
app.MapGet("/{name}", Contact.searchphonenumber);
app.MapGet("/delete/{name}",Contact.delete);
app.MapGet("/add/{fname}/{lname}/{phn}/{email}",Contact.Add2);


app.Run();
