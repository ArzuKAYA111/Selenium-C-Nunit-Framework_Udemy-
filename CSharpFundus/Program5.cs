using System;
using System.Security.Cryptography;

String [] arr = { "Hello","Bye","Arzu" };
int [] num= {1,2,3,4,5 };

string[] a1= new String[4];
a1[0]="Ing";
a1[1]="Tur";
a1[2]="Arb";
a1[3]="Spen";

for (int i = 0; i<arr.Length; i++)
	{
	Console.WriteLine(arr[i]);
	}
foreach (int no in num)
	{
	Console.WriteLine(no);
	if (no ==3)
		{
        Console.WriteLine($"no is {no} ");
        Console.WriteLine($"no is {no}  match is found");
        
        break;
		}
	else
		{
		Console.WriteLine("Loop is continue");
		}
	}