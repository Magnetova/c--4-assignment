# Assignment 4 - Interfaces, Stacks, Queues, Generics, and Merge Sort. Project uses Assignment 3 solution.

## Author



## Description

The Jawas on Tatooine are pleased with the job you have done on the droid system so far. Since they started using it, they have decided that they would like a few new features added. They would like to be able to sort their list of droids in two different ways. It is your job to create these sorts for them.

They would like to sort the droids by category. If the list is printed from this sort, the program will display the droids in the following order: (Astromech, Janitor, Utility, Protocol). There does not need to be any order to the droids within those categories. Just all the Astromechs, then all the Janitors, and so on.

They would also like to sort the droids by the Total Cost ranging from the cheapest droid to the most expensive droid.

The menu options and methods that you add should only sort the droid collection. Printing it should still be delegated to the print menu option that already exists. This means that sorting it will overwrite the original order, and that's okay.

Details about how each sort will work are explained below.

You need to add menu options and methods to a finished assignment 3 to complete assignment 4, and add the above mentioned functionality.

Using the assignment link will give you my finished implementation of Assignment 3 as a starting place. If you would rather use your implementation of assignment 3, just delete all of my classes, and add your classes in it's place. (Or replace the code of my classes with the code from your classes). This way you are still working from the repository you get from the assignment list.

You are not required to use your implementation of Assignment 3. In fact, it would be easier for me to grade if you used mine, but you are free to use your own if that is easier for you.

You should add some dummy data to the program to make testing easier. Once the droid collection is instantiated, you should hard code the insertion of some droids into the collection. Do at least 2 of each type of droid for a total of 8, and make sure to add them in an order that is different from the sort results so that you know your sorts work. This will allow both you and I a way to test both sorts without having to use the UI to create droids.

The method by which both of these sorts get done is described below:

### Categorize by model (Modified Bucket sort)
In order to sort the list by category, you will do the following things:

* Create a generic stack class that can be used to store any type the user specifies. The implementation should be in the style of a linked list. (This is just like the generics we did in class. The Deitel, and Algorithms book has an implementation of a Generic Stack in Linked List Style.)
* Create a generic queue class that can be used to store any type the user specifies. The implementation should be in the style of a linked list. (The Deitel, and Algorithms book has an implementation of a Generic Queue in Linked List Style.)
* Add a method to your droid collection that will do this sort on the collection.
  * In the method, create an instance of the stack class for each type of droid (4 in total)
  * In the method, create a single instance of a queue who's type is high enough on the inheritance chain to store all of the droids (Just 1 of these). Don't make it of type 'object'. That is too high on the inheritance chain.
  * Loop through your list of droids, and for each one:
    * Determine what type of droid it by inspecting the instance type, and then Push the droid onto the appropriate stack. More information about how to inspect the instance type of an object can be found below.
    * Once all of the droids are on the various stacks, start Popping the droids off of the stacks and enqueue them in the Generic Queue. (Make sure you process the stacks in the correct order so that the order of the queue is the order specified above for the sort)
    * Once all of the droids are in the Queue, replace the original array of droids with the droids in the queue by dequeuing a droid one at a time, and placing it back into the original array.

I realize that this above sort could be done without using a queue, but I want you to use a queue in this program. Therefore you have to take from the stack and put into the queue, and then remove from the queue and put into the original array vs going straight from the stacks to the array.

Here is a diagram that attempts to show the general flow of the algorithm. On top is DroidCollections underlying droid array. The algorithm will then remove each droid from the array and push it on the appropriate stack. One for each droid. That is the vertical parts of the diagram. Then after the stacks are full, they will be popped off and enqueued in the single droid queue. This is the bottom part of the diagram. Lastly, the droids are removed from the queue and put back in the original array at the top.

![Categorize by model diagram](https://barnesbrothers.net/cis237/assignmentImages/cis237_assignment_4_bucket_sort.png)
<br/><br/><br/><br/><br/><br/>

### Sort by Total Cost using Merge Sort
In order to sort the list by the Total Cost, you will do the following things:

* Create a MergeSort class with a sort method that takes in an array of type IComparable[]. This will allow the merge sort to sort any class array where the class implements IComparable thanks to polymorphism. (EX: If a class Employee implements IComparable, then an Employee[] can be sent to this merge sort since merge sort accepts a IComparable[] and Employee IS an IComparable.) Any implementation is fine for this class, but you should do an array version (NOT linked list), and use an auxiliary array to store temporary information. (The Deitel, and Algorithms book have a nice implementation that uses IComparable. I believe that they call it just Comparable in the Algorithms book because it is Java, but Java's Comparable operates the same as C#'s IComparable.)
* Add a method to your droid collection that will send the droidCollection's array over to the MergeSort class's sort method. Since your droidCollection array is of type IDroid or Droid, and the sort method accepts a IComparable, you will need to do the following steps to make everything work:
  * Make the interface IDroid, or the abstract class Droid (Depending on the Type of your collection's array) implement the built in interface called IComparable. (Yes! You can alter IDroid in this assignment if needed.) This change will require you to implement the CompareTo method in the Droid class as you are now implementing a new Interface. By having Droid implement the IComparable Interface, you can now send Droid arrays to the IComparable sort method since Droid IS an IComparable.
  * Implement CompareTo in the Droid class.
NOTE: If any of this is confusing, be sure to ask about it in class! I DO NOT want you hung up on what you are supposed to do.

You are free to do anything above an beyond what is listed here. The only "Requirements" are listed below.

Solution Must:
* Add some hard coded droids to the droid collection.
* Create Generic Stack class.
* Create Generic Queue class.
* Stack and Queue class must be Generic.
* Update Droid or IDroid to implement IComparable.
* Create MergeSort class.
* MergeSort class must have a sort method that takes in an IComparable array as the input.
* Update Program to allow options to sort by model, or by Total Cost.
* Add methods to the Droid Collection class to do each of the sorts.
* Use the Stack, and Queue to perform a modified bucket sort to categorize by model.
* Use the MergeSort to perform a sort on the TotalCost.

Below is the original Assignment 3 description for reference.

### Notes

If you choose to use your Assignment 3 Code, you may have to change the namespace of your assignment 3 files to assignment 4 in order to get everything working.

The code in the Algorithms book for Stack, Queue, and Merge Sort are in Java. It will take a little work to translate it to C#, but it should be VERY close. Also note that the implementations in the book might not contain ALL of the functionality you need, but should be really close. Be aware that you might want to add more functionality to the implementations.

Merge Sort REALLY hates null values. Be sure that the array you send to Merge Sort either does not contain nulls, or is altered to correctly ignore them.

Be sure to think about what the time complexity for the bucket sort will be. Think about how it compares to that of a normal sort such as Merge or Bubble. Also consider the space complexity of merge sort compared to that of bubble sort. You may see questions related to this on the next exam.

## Grading
| Feature                                 | Points |
|-----------------------------------------|--------|
| Add Hard Coded Droids                   | 5      |
| Add Stack Class                         | 10     |
| Add Queue Class                         | 10     |
| Stack And Queue are Generic             | 5      |
| Create MergeSort Algorithm              | 15     |
| MergeSort takes in an IComparable Array | 10     |
| Sorting By Category Works Correctly     | 15     |
| Sorting By Total Cost Works Correctly   | 15     |
| UI is updated correctly                 | 5      |
| Documentation                           | 5      |
| README                                  | 5      |
| **Total**                               | **100**|

## Outside Resources Used



## Known Problems, Issues, And/Or Errors in the Program

<br/><br/><br/><br/><br/><br/><br/><br/>

## Assignment 3 Description for reference

## Description

The Jawas on Tatooine have recently opened a droid factory and they want to hire you to write a program to hold a list of the available droids, and the price of each droid. The price is based on the type: (protocol, utility, janitor, or astromech), the material used, and the various options that a particular droid has. The Jawa will choose the various options for a specific droid when adding that droid to the list of droids.

The program will keep a list of Droids that are created. This list MUST be an Array. The array should be of a type that is high enough on the inheritance chain that all droids no matter what type they are can be stored in it (Think Polymorphism). Don't make it of type 'object'. That is too high on the inheritance chain. Also, just make the size of the array large enough that it can accommodate some droids. 100 is a good number that comes to mind. I'm not concerned with it being auto-resizing, or anything fancy.

A Jawa will be presented with a user interface to add a new Droid, or print the current Droid list. Adding a new Droid will require input from the Jawa to create the new droid. Once all of the needed information is added for the droid, the new droid will be added to the droid collection.

If a Jawa decides to print the collection of droids in inventory, the program should loop through all of the droids in the collection and print out all of the various properties of each droid as well as the total cost of the droid. You should try to use a combination of the ToString and TotalCost method/property along with Polymorphism to reduce the amount of code needed to print the results of each droid.
NOTE: You may want to print each droid as a block of text rather than trying to cram all of the various properties for the droid onto a single line.

All of the prices for the various aspects of a droid are left up to you to determine. If I was doing it though, I would probably have a small set price for each of the following general options, and not get too specific to save time. ie:
1. A price for the droid model (protocol, utility, etc.)
2. A few different material choices (Something Made up), each with a different price
3. A price for each additional option. One of the various option bools listed below. (3 options * $10 per option)
4. A price per quantity option such as: numberOfLanguages, and numberOfShips (3 ships * $10 per ship)

The program comes with an Interface IDroid that must be implemented by subclasses and can NOT be altered. You MUST use it as it. It contains a public method called CalculateTotalCost, and a public Property called TotalCost. CalculateTotalCost returns a void, so it's job is to access the properties of the droid and literally calculate the total cost and then store it in a class level variable. It does not return the Total Cost. It only Calculates it.
The TotalCost property is how you will get access to the total cost of the droid. This will be zero until CalculateTotalCost is called. Then it will have a value.
I didn't make CalculateTotalCost return the calculated value because I wanted you to have to implement both a method and a property in subclasses. Additionally, this should also demonstrate how an Interface acts as a contract and requires you to write things a certain way. Even if you don't agree with it.

You should put all of your UI into a UI class that will handle getting all of the necessary information from the Jawa, and display the feedback to the Jawa.

You should create a class for the collection of the Droids. The DroidCollection class should contain the array that holds the droids, and maintain any internal information needed to manage that array. It should have an add method that will do the work of determining which instance of a droid needs to be created and added to the array. The UI class will prompt for the needed information to add a droid, and then when it has all of the info, it will send it to the add method, which will then determine which type to add based on the 'model' that was entered. The add method might be a good place to do method overloading, though not required.

You should follow the concepts about inheritance talked about in class, and work hard at DRY (Don't Repeat Yourself) Principles.

## Classes

The program should have a base abstract class called Droid with the following variables, properties, constructors, methods, etc that implements the IDroid interface.

Droid:

* Variables: material (string), color (string), totalCost (decimal)
* Constructors: 2 parameter constructor (string, string)
* Property: TotalCost to return the cost of the droid (Required by the interface)
* Public Methods:
	* ToString: return a formatted string containing the properties of the droid.
	* CalculateTotalCost: Required by the interface to calculate and store the total cost.
* Protected Methods:
	* Your Choice - But think about what might be able to be protected to save you work in derived classes.

There should be two derived classes from the abstract class Droid with appropriate variables, methods and properties. Both of these droid types can be created by a Jawa.

Protocol:

* Variables: numberLanguages (int)
* Constant: costPerLanguage
* Constructors: 3 parameter constructor (string, string, int)
	* Uses the base class (Droid) constructor
* Public Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculate the totalCost based on the number of languages and droid type. Then add those values to any costs that can be calculated by the base class.

Utility:

* Variables: toolbox (bool), computerConnection (bool), scanner (bool)
* Constructors: 5 parameter constructor (string, string, bool, bool, bool)
	* Uses the base class (Droid) constructor
* Public Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculates totalCost by calculating the cost of each selected option and droid type. Then add those values to any costs that can be calculated by the base class.

There should be two more derived classes from the class Utility with appropriate variables, methods and properties.
NOTE: Even though Utility is the base class for these droids, Utility itself is still a valid droid option that can be created in the system.

Janitor:

* Variables: broom (bool), vacuum (bool)
* Constructors: 7 parameter constructor (string, string, bool, bool, bool, bool, bool)
	* Uses the base class (Utility) constructor
* Public Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculate totalCost by calculating the cost of each selected option and droid type. Then add those values to any costs that can be calculated by the base class.

Astromech:

* Variables: navigation (bool), numberShips (int)
* Constant: costPerShip
* Constructors: 7 parameter constructor (string, string, bool, bool, bool, bool, int)
	* Uses the base class (Utility) constructor
* Public Methods:
	* ToString: return a formatted string containing the variables
	* CalculateTotalCost: Calculate totalCost by calculating the cost of each selected option, the cost based on the number of ships, and the droid type. Then add those values to any costs that can be calculated by the base class.

![Droid Class Diagram](http://barnesbrothers.ddns.net/cis237/assignmentImages/DroidClassDiagram.jpg "Droid Class Diagram")

## Solution Requirements

Solution Must:

* Allow Jawa to add a new droid of either (Protocol, Utility, Janitor, or Astromech) to the list
* Allow Jawa to print the list of droids out.
* Do NOT make any changes to the IDroid interface.
* Create abstract class Droid that implements IDroid
* Derive two classes (Protocol and Utility) from the class Droid
* Derive two classes (Janitor and Astromech) from the class Utility
* Each derived class (Protocol, Utility, Janitor, and Astromnech) must either implement or override the ToString and CalculateTotalCost methods
* Create a UI class
* Create a DroidCollection class
* Use private, public and protected appropriately.
* Use abstract, virtual, and override appropriately.
* Have sufficient comments about what you are doing in the code.

### Notes

If you did not do well on Assignment 1, you may want to look at the Assignment 1 Key that I did for some help related to UI classes, Collection classes, arrays, and structure.

It may be beneficial for you to create extra methods within the droid sub classes. You are not limited to the ones mentioned. You may even find it useful to make some additional ones that are protected and virtual.

