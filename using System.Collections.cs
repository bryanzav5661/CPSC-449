using System.Collections;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class user
{
    public int id {get; set; } = string.Empty;
    
    public string FirstName {get; set; } = string.Empty;

    public string LastName {get; set; } = string.Empty;

    public string Email {get; set; } = string.Empty;

    public ICollection<Registraions> Registraions {get; set;} = new List<Registraions>();

}

public class Registration
{
    public int Id { get; set; }

    public int Eventid { get; set; }
    public Event Event { get; set; }
    public int Userid { get; set; }
    public User User { get; set; }

}