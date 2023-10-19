using System;
using System.Collections;
ArrayList  lst=new ArrayList();


lst.Add("Hello");
lst.Add("Bye");
lst.Add("Arzu");
lst.Add("Kaya");


foreach(String word in lst)
    {
    Console.WriteLine(word);   

    }

List<string> names = new List<string>();
names.Add("Huli");
names.Add("Seni");
names.Add("Arz");
for(int i = 0; i<names.Count; i++)
    {

    Console.WriteLine(names.ElementAt(i));
    if (names.ElementAt(i).SequenceEqual("Seni")){
        break;
        }
    }
