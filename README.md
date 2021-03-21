# Conversions and Method Overloading

## Table of contents

-   [Type Conversions](#type-conversions)
    -   [Implicit Conversions](#implicit-conversions)
    -   [Explicit Conversions (casts)](<#explicit-conversions-(casts)>)
    -   [Conversions with helper classes](#conversions-with-helper-classes)
-   [Method Overloading](#method-overloading)
    -   [By changing the number of parameters in a method](#by-changing-the-number-of-parameters-in-a-method)
    -   [By using different data types for parameters](#by-using-different-data-types-for-parameters)
    -   [By changing the order of parameters in a method](#by-changing-the-order-of-parameters-in-a-method)
-   [Resources](#resources)

## Type Conversions

C# is a typed language, which means that after a variable is declared, we cannot assign to it another variable type implicitly.

So how do we overcome that? The answer is: "Type conversions".

In this guide, we'll take a look at three of them.

### Implicit conversions

This conversion is done automatically without the need of doing it ourselves. Implicit conversions can be done when there's not a possibility of data loss. For example, converting from a less precise type to a more precise one (an integer to a double) or a derived (child) class to a base (parent) class.

```csharp
int lessPrecise = 10;
double morePrecise = lessPrecise;

Console.WriteLine($"Integer: {lessPrecise}"); // Integer: 10
Console.WriteLine($"Double: {morePrecise}"); // Double: 10
```

```csharp
class Animal {}
class Dog:Animal {}

Dog dog = new Dog();
Animal animal = dog;

Console.WriteLine($"Dog: {dog}"); // Dog: Conversions.Tutorial.Models.Dog
Console.WriteLine($"Animal: {animal}"); // Animal: Conversions.Tutorial.Models.Dog
```

### Explicit conversions (casts)

Whenever there's a possibility of data loss, casting becomes required. For example, converting from a more precise type to a less precise one (a double to an integer) or a base (parent) class to a derived (child) class.

```csharp
double morePreciseNum = 15.35;

// The line below will throw an error
//int lessPreciseNum = preciseNum;

// By adding a cast, the program will compile
int lessPreciseNum = (int)morePreciseNum;

Console.WriteLine($"Double: {morePreciseNum}"); // Double: 15.35
Console.WriteLine($"Integer: {lessPreciseNum}"); // Integer: 15
```

```csharp
class Animal {}
class Dog:Animal {}

Animal animalParent = new Animal();
// The line above will throw an error
// Dog dog = animal;

// By adding a cast, the program will compile
Dog dogChild = (Dog)animalParent;

Console.WriteLine($"Animal: {animalParent}"); // Animal: Conversions.Tutorial.Models.Dog
Console.WriteLine($"Dog: {dogChild}"); // Dog: Conversions.Tutorial.Models.Dog
```

```csharp
try
{
  Dog catDog = (Dog)catAnimal;
  Console.WriteLine(catDog);
}
catch (InvalidCastException ex)
{
  // Unable to cast object of type 'Conversions.Tutorial.Models.Cat'
  //to type 'Conversions.Tutorial.Models.Dog'
  Console.WriteLine(ex.Message);
  Console.WriteLine();
}
```

### Conversions with helper classes

When types are not compatible, we use helper classes such as `Convert` and methods like `Parse()` or `TryParse()`.

```csharp
string numberText = "123.45";
double numberConvert = Convert.ToDouble(numberText);
double numberParse = double.Parse(numberText);

Console.WriteLine($"Using Convert: {numberConvert}"); // Using Convert: 123.45
Console.WriteLine($"Using Parse: {numberParse}"); // Using Parse: 123.45
```

[Convert or Parse](https://stackoverflow.com/a/35838093/13358772)

## Method Overloading

Method overloading is the concept of being able to have multiple methods with the same name _but_ with different arguments.

Here are the ways on how to achieve method overloading:

### By changing the number of parameters in a method

```csharp
public static int Sum(int n1, int n2) =>	n1 + n2;

public static int Sum(int[] numbers) => numbers.Sum();
```

### By using different data types for parameters

```csharp
public static int Sum(int n1, int n2) =>	n1 + n2;

public static int Sum(double n1, int n2) => (int)(n1 + n2);
```

### By changing the order of parameters in a method

```csharp
public static int Sum(double n1, int n2) => (int)(n1 + n2);

public static int Sum(int n1, double n2) => (int)(n1 + n2);
```

Note that in order to call the methods above, we'll need to explicitly cast one of the numbers as double as integers can be implicitly converted to the double type

```csharp
public static void Main (string[] args) {
  int sumOne = Sum((double)1,5)); // Calls method Sum(double, int)
  int sumTwo = Sum(3,(double)5)); // Calls method Sum(int, double)
}
```

Note that we can't change the order of two parameters of the same datatype.

```csharp
public static int Sum(int n1, int n2) => n1 + n2;
// The line below won't compile
public static int Sum(int n2, int n1) => n1 + n2;
```

Note that only changing the return type won't work. Look at the example below.

```csharp
public static int Sum(int n1, n2) =>	n1 + n2;
// The line below won't compile
public static double Sum(int n1, n2) =>	n1 + n2;
```

## Resources

[Type Conversions - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions)

[Difference between Parse() and Convert - Stack Overflow](https://stackoverflow.com/a/35838093/13358772)

[InvalidCastException - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.invalidcastexception?view=net-5.0)

[Overload Methods - Pluralsight](https://www.pluralsight.com/guides/overload-methods-invoking-overload-methods-csharp)
