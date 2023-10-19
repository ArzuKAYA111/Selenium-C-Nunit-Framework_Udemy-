using System;
using CSharpFundus;

Console.WriteLine("I am in the second program");
// Global Scop of Main

CSharpFundus.Program p1= new CSharpFundus.Program();

p1.getData();

/*
 * 
 
Burada Class main method vs. kullanmadan code yazdik ve bu kod execuatble bu C#'in biz ozelligi
//Global scope of Main  Main method koymadigimiz programlara C# Kendisi bir main method koyuyor buda global oluor.

That can be only one main entry in the entire project.

You just cannot have multiple classes. you can have But one time you can run only one thing.

    Bir class ta Main method var ise , digerinde yok ise ve ikiclass'i da settings ten compile yapsak ta c#   Global scope of Main olani execute eder digerini skip yapar.

    To make a program/class executable or not executable 
    right click on class file go to Properties select built action as Compile(To execute) or non(To skip)

 
 */
