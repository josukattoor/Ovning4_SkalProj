using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            bool isExamineListAlive = true;
            Console.WriteLine("Enter a string with + or - like +Jossy or -Jossy:"
                  + "\n*. Return to main menu");
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();

            while (isExamineListAlive)
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

            switch (nav) 
                {
                case '+':
                    theList.Add(value);
                    Console.WriteLine($"Added '{value}' to the list.");
                        Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                        break;
                case '-':
                if (theList.Remove(value))
                {
                    Console.WriteLine($"Removed '{value}' from the list.");
                        Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");

                }
                    else
                {
                    Console.WriteLine($"'{value}' not found in the list. Enter a string with + like +Jossy to add it");
                }
                        break;
                case '*':
                        isExamineListAlive = false;
                        break;
                default:
                Console.WriteLine("Use only '+' or '-'.");
                        break;
                }
            }

        }
        //2. When does the list capacity increase? (So ​​the size of the underlying array)
        //When the count in the list is more than capacity , the capacity increases
        //3. By how much does the capacity increase?
        //When the count reached 4, capacity was 4. When count is increased again capacity is 8 ie, doubled. Similarly when count exceeded 8 capacity became 16. Again double.
        //4. Why doesn't the capacity of the list increase at the same rate as elements are added?
        //If capacity increases everytime it will result in reallocations all the time and therefore bad performance and memory usage.
        //5. Does capacity decrease when elements are removed from the list?
        //No. Capacity remains the same ven when elements are removed.
        //6. When is it advantageous to use a self-defined array instead of a list?
        // If we are not strict on memory usage we can use list instead of arrays
        // If we don't want dynamic resizing and know the size requirement for data structure then array can be used
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            bool isExamineQueueAlive = true;
            // Create a new Queue 
            Queue<string> icaQueue = new Queue<string>();

            Console.WriteLine("ICA opens, and the checkout queue is empty.");

            while (isExamineQueueAlive)
            {
                Console.WriteLine("1. Enqueue");
                Console.WriteLine("2. Dequeue");
                Console.WriteLine("*. Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter a name to join the queue: ");
                        string name = Console.ReadLine();
                        icaQueue.Enqueue(name);
                        Console.WriteLine($"{name} has joined the queue.");
                        break;
                    case "2":
                        if (icaQueue.Count > 0)
                        {
                            string firstPerson = icaQueue.Dequeue();
                            Console.WriteLine($"{firstPerson} has left the queue.");
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty.");
                        }
                        break;
                    case "*":
                        isExamineQueueAlive = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                // Print the current queue
                if (isExamineQueueAlive == true)
                {
                    Console.WriteLine("\nCurrent Queue:");
                    foreach (string person in icaQueue)
                    {
                        Console.WriteLine(person);
                    }
                }
            }
        }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            bool isExamineStackAlive = true;
            while (isExamineStackAlive)
            {
                Console.WriteLine("\n* Return to main menu");
                Console.Write("Enter a string with + to push to stack and - to pop from stack: ");
            string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) )
                {
                    Console.WriteLine("* Return to main menu");
                    Console.Write("Enter a string with + to push to stack and - to pop from stack: ");

                }
                else
                {
                    char nav = input[0];


                    Stack<char> charStack = new Stack<char>();

                    //Console.WriteLine("Stack Behavior:");

                   
                        switch (nav)
                        {
                            case '+':
                            if (!string.IsNullOrEmpty(input.Substring(1)))
                                {
                                foreach (char c in input.Substring(1))
                                {
                                    charStack.Push(c);
                                    Console.WriteLine($"Pushed '{c}' to the stack.");
                                }
                            }
                            Console.Write("Reversed string: ");
                            while (charStack.Count > 0)
                            {
                                Console.Write(charStack.Pop());
                            }
                            break;
                            case '-':
                            if (!string.IsNullOrEmpty(input.Substring(1)))
                            {
                                foreach (char c in input.Substring(1))
                                {
                                    charStack.Push(c);
                                }
                            }
                            if (charStack.Count > 0)
                                {
                                foreach (char c in input)
                                {
                                    if (charStack.Count > 0)
                                    {
                                        char poppedChar = charStack.Pop();
                                        Console.WriteLine($"Popped '{poppedChar}' from the stack.");
                                    }
                                }
                                }
                                else
                                {
                                    Console.WriteLine("Stack is empty. Cannot pop.");
                                }
                                break;
                            case '*':
                                isExamineStackAlive = false;
                                break;
                            default:
                                Console.WriteLine($"Use '+' to push or '-' to pop.");
                                break;
                        }
                }
            }

            Console.WriteLine(); // Print a newline for formatting
        }
    //1. Why is it not so smart to use a stack in this case?
    //Stack works based on FILO(First In Last Out).
    //In a real life situation like ICA queue it is not good to deal with the person who joined last before the one who joined first.
    //So it is not appropriate to use a stack here.
    static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

