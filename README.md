# C# Assignments

This assignments were developed for class assignments and they date from July 2018. They are far from great software, but what makes me proud of them is that they are a Milestone when I was resuming my career with a post-grad at the Conestoga College.

With the Software Development Techniques class I've reviewed so many important topics for software development, such as:

* Data types
* Data structures
* Control Flow
* Object Orientation

And I've learnt some modern concepts as indicated in each assignment description.

## Assignment #3: Carterer Schedule

Specific concepts exercised in this assignment:

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

    Based on age, the parties can be divided into three categories: Children (Average age 25 and under), Seniors (Average age 60 or over) and Adults in between these ages

    For each group the caterer needs to:
    * For children: Get unbreakable dishes
    * For adults: Deliver hard liquor
    * For seniors: check sugar content in the food

    The caterer can only do one party per day. You will have to set up a schedule for a longer period of time (say 2 weeks)

    Common Issues
    * You will create a list of all appointments recorded
    * Then you will go through all items in the list and output the data for every item in the list using ToString() method
    * Then you will call all the methods you created so they can output their messages

    Specific requirements:
    1. Create an interface, which will declare the functionality of the base class including all methods and properties
    2. Implement a base class as abstract (declaring supplementary tasks as abstract method)
    3. Derive all classes from this abstract class, implementing, overloading and overriding methods as needed. Remember that abstract methods are virtual.
    4. Create a class, which will hold all appointments. Make it using an indexer
    5. Sort the list of appointments you made using List<>.Sort method. You must implement IComparable<> interface in the base class of the items you put in the list. Sort by year or by age (depending on which problem you extend)
    6. Iterate through all appointments and perform all tasks. Hint: use delegates for the tasks, which are different for each item

## Assignment #5: Generic Schedule

Specific concepts exercised in this assignment:

* GUI design in Visual Studio
* Data binding
* Error/Exception Handling
* Saving files in binary format and XML (with and withou serialization)
* LINQ

Assignment requirements:

    1. Create a one-window (one-page) application, which will have two distinct capabilities (placed in the separate areas of the screen):
       * Create a record to be placed in the scheduler
       * Display newly created record in the data grid
    2. After you finish entering data, save data to XML file on the disk
    3. Create a capability (button) in the application, which will load the data from the disk to
    the data grid
    4. Using LINQ create filtering capability in the application, allowing filtering data using
    any field of your choice
    5. Add error handling to the application which will display the input error if it occurs
    6. Add converter to your application, showing the items placed in the grid in red when they are large enough

Here are some screenshots of the app running:

![picture of the app main screen with 3 records](scheduleGeneric/pictures/picture1.png)

![picture of the app using the filter feature](scheduleGeneric/pictures/picture2.png)
