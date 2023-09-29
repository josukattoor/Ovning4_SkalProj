using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        /*
         * Questions:
1. How do the stack and the heap work? Please explain with an example or a sketch of it
basic function
        Stack is used when we want to store value types or refrence types.
        On the other hand heap is used when we want to store reference types. 
        */
        public void StackExample()
        {
            int x = 10; // Local variable 'x' is allocated on the stack
            int y = 5;  // Local variable 'y' is also allocated on the stack

            int result = x + y; // 'result' is a temporary variable allocated on the stack
        }


        /*'
         * when the function is called variables are added to stack and then removed when function exists. Since it is stack no need to explicitly manage the memory.
        
        */
        class MyClass
        {

        }
        public void HeapExample()
        {
        // Creating an object on the heap using 'new'
        MyClass myObject = new MyClass(); 

        // 'myObject' is a reference to the object, and it's allocated on the stack
        // The actual object data is stored on the heap

        // Explicitly releasing memory (not always required in C# due to garbage collection)
        // 'myObject' will be removed from the stack, and the object on the heap is marked for cleanup
        myObject = null;
        }
        /*
        2. What are Value Types and Reference Types and what differentiates them?
        Value types are stored directly on the memory in stack. Reference types are stored with a reference to actual data on the heap.
        3. The following methods (see image below) generate different responses. The first returns 3, the
        others return 4, why?
        In the code in first function, x is assigned 3 first and x is assigned to y. Then value of y is changed to 4. But function returns value of x ie, 3.
        In the second function x and y are instances of MyInt. Here since it is reference type both refer to same boject and when value of y.MyValue is assigned 4 it chnages the value of x as well. So function returns 4.
         
         */

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

            Console.WriteLine("ICA Queue, checkout queue is empty.");

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
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("* Return to main menu");
                    Console.Write("Enter a string with + to push to stack and - to pop from stack: ");

                }
                else
                {
                    char nav = input[0];


                    Stack<char> charStack = new Stack<char>();

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

            Console.WriteLine(); 
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
            //Used stack to keep track of each opening and closing parenthesis. When one opening is found it is pushed to stack and if its closing is not found the string is not well formed.

            bool isExamineParanthesisAlive = true;
            while (isExamineParanthesisAlive)
            {
                Console.Write("\n *. Return to main menu ");
                Console.Write("\n1.Check paranthesis is correct ");

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
                        Console.WriteLine("\nEnter string like (()) or ([)):");

                        string paramInput = Console.ReadLine();
                        Stack<char> stack = new Stack<char>();
                        if (!string.IsNullOrEmpty(paramInput))
                        {
                            foreach (char c in paramInput)
                            {
                                if (c == '(' || c == '{' || c == '[')
                                {
                                    stack.Push(c);
                                }
                                else if (c == ')' || c == '}' || c == ']')
                                {
                                    if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), c))
                                    {
                                        Console.WriteLine("The string is correct.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The string is incorrect.");

                                    }
                                }
                            }
                        }
                        break;
                    case '*':
                        isExamineParanthesisAlive = false;
                        break;
                    default:
                        Console.WriteLine("Enter string to check if parenthesis is correct.");
                        break;

                }

                }
        }
        static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '{' && closing == '}') ||
                   (opening == '[' && closing == ']');
        }
    }
    }


