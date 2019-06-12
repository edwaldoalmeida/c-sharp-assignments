# Assignment #3: Carterer Schedule

Specific concepts exercised with this assignment:

* Interfaces
* Abstract Classes
* Indexers
* Sort (using IComparable)
* Delegates

Assignment requirements:

The caterer needs a schedule for the next month. The caterer delivers food, sets up the tables and cleans up. The caterer needs also to prepare food based on the wishes of the customer. Every customer has a contact name, city (take Kitchener, Cambridge, Waterloo if imagination does not help) and average age of the people at the party

For every party the caterer needs to

* Prepare Food
* Set up Tables
* Clean Up

Based on age, the parties can be divided into three categories:
Children (Average age 25 and under)
Seniors (Average age 60 or over) and
Adults in between these ages

For each group the caterer needs to:

* For children: Get unbreakable dishes
* For adults: Deliver hard liquor
* For seniors: check sugar content in the food

The caterer can only do one party per day. You will have to set up a schedule for a longer period of time (say 2 weeks)

Common Issues

* You will create a list of all appointments recorded
* Then you will go through all items in the list and output the data for every item
* in the list using ToString() method
* Then you will call all the methods you created so they can output their messages

Specific requirements:

1. Create an interface, which will declare the functionality of the base class including all methods and properties
2. Implement a base class as abstract (declaring supplementary tasks as abstract method)
3. Derive all classes from this abstract class, implementing, overloading and overriding methods as needed. Remember that abstract methods are virtual.
4. Create a class, which will hold all appointments. Make it using an indexer
5. Sort the list of appointments you made using List<>.Sort method. You must implement IComparable<> interface in the base class of the items you put in the list. Sort by year or by age (depending on which problem you extend)
6. Iterate through all appointments and perform all tasks. Hint: use delegates for the tasks, which are different for each item

<a rel="edwaldoalmeida.com" href="https://www.edwaldoalmeida.com">**Edwaldo Almeida**</a> @ 2019
