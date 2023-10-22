public class SoftwareDeveloperJunior{

public string fullName {set; get;}
public int age {set; get; }
public list<string> languagesSpoken {set; get;}
public string contry {set; get;}

public SoftwareDeveloperJunior presentation (){
list<string> languages = new list<string>();
lenguages.add("English, spanish");
SoftwareDeveloperJunior presentation = new SoftwareDeveloperJunior
{
fullName = "Loren Feliz",
age = 20,
lenguageSpoken = languages,
contry = "Dominican Republic"
};
Console.Writeline(presentation);
return presentation;
    
}

}