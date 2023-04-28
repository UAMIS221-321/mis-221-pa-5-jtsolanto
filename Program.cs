using PA5;
//  namespace contains all of the classes and methods

internal class Program
{
    private static void Main(string[] args)
    {
        // This is the main loop of the program. It will continue to run until the user chooses to exit.
        // Create an array of trainers, listings, and bookings.
        Trainer[] trainers = new Trainer[400];
        Listing[] listings = new Listing[400];
        Booking[] bookings = new Booking[400];


        while (true)  //  while loop will continue to run as long as the user does not choose to exit the program.

        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            string[] options = {"Manage Trainer Data", "Manage Listing Data", "Book A Session", "Run Reports", "Exit Program"};
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < options.Length; i++)
                {
                    if (selectedOption == i) // If the current option is selected, highlight it.
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    System.Console.WriteLine(options[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();   // Get the user's input.


                switch (keyInfo.Key)    // Switch on the user's input.

                {
                    case ConsoleKey.UpArrow:
                    // If the user pressed the up arrow key, decrease the selected option.
                        selectedOption--;
                        if (selectedOption < 0)
                        {
                            // If the selected option is less than 0, set it to the maximum value.
                            selectedOption = options.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                     // If the user pressed the down arrow key, increase the selected option.
                        selectedOption++;
                        if (selectedOption >= options.Length)
                        {
                            // If the selected option is greater than or equal to the length of the options array, set it to the minimum value.
                            selectedOption = 0;
                        }
                        break;
                    case ConsoleKey.Enter: // If the user pressed the enter key, execute the selected option.
                        Console.Clear();
                        switch (selectedOption)
                        {
                            case 0:
                                ManageTrainer(trainers);  // If the selected option is 0, call the ManageTrainer method.
                                break;
                            case 1:
                                ManageListing(listings); // If the selected option is 1, call the ManageListing method.
                                break;
                            case 2:
                                ManageCustomer(trainers, listings, bookings); // If the selected option is 2, call the ManageCustomer method.
                                break;
                            case 3:
                                RunReports(trainers, listings, bookings); // If the selected option is 3, call the RunReports method.
                                break;
                            case 4:
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Black;
                                Environment.Exit(0); // If the selected option is 4, exit the program.
                                break;
                        }
                        break;
                }
            }
        }
    }
    static void ManageTrainer(Trainer[] trainers)  // This method manages the trainer data.

    {
        Console.Clear();

        TrainerUtility utility = new TrainerUtility(trainers);   // Create a TrainerUtility object.

        utility.GetAllTrainersFromFile();  // Get all of the trainers from the file.


        TrainerReport report = new TrainerReport(trainers); // Print all of the trainers to the console.
        report.PrintAllTrainers();
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            string[] options = { "Add a Trainer", "Edit a Trainer", "Delete a Trainer", "Exit Trainer Manager" };
            int selectedOption = 0;
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < options.Length; i++)
                {
                    if (selectedOption == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    System.Console.WriteLine(options[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption--;
                        if (selectedOption < 0)
                        {
                            selectedOption = options.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption++;
                        if (selectedOption >= options.Length)
                        {
                            selectedOption = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (selectedOption)
                        {
                            case 0:
                                utility.AddTrainer(); // If the user selected option 0, call the AddTrainer method.
                                break;
                            case 1:
                                utility.UpdateTrainer(); // If the user selected option 1, call the UpdateTrainer method.
                                break;
                            case 2:
                                utility.DeleteTrainer(); // If the user selected option 2, call the DeleteTrainer method.
                                break;
                            case 3:
                                return; // If the user selected option 3, return to the main menu.
                        }
                       break;
                }
            }
        }
    }

    static void ManageListing(Listing[] listings)
    {
        Console.Clear();    
        ListingUtility utility = new ListingUtility(listings);
        utility.GetAllListingsFromFile();
        ListingReport report = new ListingReport(listings);
        report.PrintAllListings();
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            string[] options = { "Add a Listing ", "Edit a Listing", "Delete a Listing", "Exit Listing Manager" };
            int selectedOption = 0;
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < options.Length; i++)
                {
                    if (selectedOption == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    System.Console.WriteLine(options[i]);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption--;
                        if (selectedOption < 0)
                        {
                            selectedOption = options.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption++;
                        if (selectedOption >= options.Length)
                        {
                            selectedOption = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (selectedOption)
                        {
                            case 0:
                                utility.AddListing(); // If the user selected option 0, call the AddListing method.
                                break;
                            case 1:
                                utility.UpdateListing(); // If the user selected option 1, call the UpdateListing method.
                                break;
                            case 2:
                                utility.DeleteListing(); // If the user selected option 2, call the DeleteListing method.
                                break;
                            case 3:
                                return; // If the user selected option 3, return to the main menu.
                        }
                        break;
                }
            }
        }
    }
   
    static void ManageCustomer(Trainer[] trainers, Listing[] listings, Booking[] bookings)
    {
        Console.Clear();
        BookingUtility utility = new BookingUtility(bookings);
        utility.GetAllTransactionsFromFile();
        int selectedOption = 0;
        string[] options = { "Manage a Transaction", "Book A Session", "Exit Transaction and Booking Manager" };

        while (true)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < options.Length; i++)
            {
                if (selectedOption == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                System.Console.WriteLine(options[i]);
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption--;
                    if (selectedOption < 0)
                    {
                        selectedOption = options.Length - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption++;
                    if (selectedOption >= options.Length)
                    {
                        selectedOption = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (selectedOption == 0)
                    {
                        BookingReport report = new BookingReport(bookings);
                        report.PrintAllBookings();
                        string[] reportOptions = { "Edit a Transaction", "Delete a Transaction", "Return to Menu Screen"};
                        int reportSelectedOption = 0;

                        while (true)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            for (int i = 0; i < reportOptions.Length; i++)
                            {
                                if (reportSelectedOption == i)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                System.Console.WriteLine(reportOptions[i]);
                            }

                            ConsoleKeyInfo reportKeyInfo = Console.ReadKey();

                            switch (reportKeyInfo.Key)
                            {
                                case ConsoleKey.UpArrow:
                                    reportSelectedOption--;
                                    if (reportSelectedOption < 0)
                                    {
                                        reportSelectedOption = reportOptions.Length - 1;
                                    }
                                    break;
                                case ConsoleKey.DownArrow:
                                    reportSelectedOption++;
                                    if (reportSelectedOption >= reportOptions.Length)
                                    {
                                        reportSelectedOption = 0;
                                    }
                                    break;
                                case ConsoleKey.Enter:
                                    Console.Clear();
                                    if (reportSelectedOption == 0)
                                    {
                                        utility.UpdateTransaction();
                                    }
                                    else if (reportSelectedOption == 1)
                                    {
                                        utility.DeleteTransaction();
                                    }
                                    else if (reportSelectedOption == 2)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        ReturnInvalid();
                                    }
                                    report = new BookingReport(bookings);
                                    report.PrintAllBookings();
                                    break;
                            }
                        }
                    }
                    else if (selectedOption == 1)
                    {
                        utility.Book(listings, trainers, bookings);
                    }
                    else if (selectedOption == 2)
                    {
                        return;
                    }
                    else
                    {
                        ReturnInvalid();
                    }
                    break;
                case ConsoleKey.Escape:
                    return;
            }
        }
    }

    static void RunReports(Trainer[] trainers, Listing[] listings, Booking[] bookings)
    {
        Console.Clear();
        string[] options = { "Individual Customer Sessions Report", "Historical Customer Sessions Report", "Historical Revenue Report", "Exit" };
        int selectedOption = 0;
        BookingReport report = new BookingReport(bookings);
        BookingUtility utility = new BookingUtility(bookings);
        utility.GetAllTransactionsFromFile();

        while (true)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < options.Length; i++)
            {
                if (selectedOption == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                System.Console.WriteLine(options[i]);
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption--;
                    if (selectedOption < 0)
                    {
                        selectedOption = options.Length - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption++;
                    if (selectedOption >= options.Length)
                    {
                        selectedOption = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    string answer = (selectedOption + 1).ToString();
                    if (answer == "1")
                    {
                        Console.Clear();
                        report.IndividualReport();
                    }
                    else if (answer == "2")
                    {
                        Console.Clear();
                        report.PrintCustomerSessions();
                        System.Console.WriteLine("");
                        System.Console.WriteLine("Listed above is the report for all customers");
                        System.Console.WriteLine("Press any key to continue back to the option screen");
                        Console.ReadKey();
                    }
                    else if (answer == "3")
                    {
                        string[] yearlyOptions = { "Combined Report", "Monthly Report", "Yearly Report", "Exit"};
                        int selectedYearlyOption = 0;
                        while (true)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            for (int i = 0; i < yearlyOptions.Length; i++) 
                            {
                                if (selectedYearlyOption == i) 
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                } 
                                else 
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                System.Console.WriteLine(yearlyOptions[i]);
                            }

                            ConsoleKeyInfo yearlyKeyInfo = Console.ReadKey();

                            switch (yearlyKeyInfo.Key) 
                            {
                                case ConsoleKey.UpArrow:
                                    {
                                        if (selectedYearlyOption == 0) 
                                        {
                                            selectedYearlyOption = yearlyOptions.Length - 1;
                                        } else {
                                            selectedYearlyOption--;
                                        }
                                        Console.Clear();
                                        for (int i = 0; i < yearlyOptions.Length; i++) 
                                        {
                                            if (selectedYearlyOption == i) {
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                            } else {
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                            System.Console.WriteLine(yearlyOptions[i]);
                                        }
                                        break;
                                    }
                                case ConsoleKey.DownArrow:
                                    {
                                        if (selectedYearlyOption == yearlyOptions.Length - 1) 
                                        {
                                            selectedYearlyOption = 0;
                                        } else {
                                            selectedYearlyOption++;
                                        }
                                        Console.Clear();
                                        for (int i = 0; i < yearlyOptions.Length; i++) 
                                        {
                                            if (selectedYearlyOption == i) 
                                            {
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.ForegroundColor = ConsoleColor.Black;
                                            } else 
                                            {
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                            System.Console.WriteLine(yearlyOptions[i]);
                                        }
                                        break;
                                    }
                                case ConsoleKey.Enter:
                                    {
                                        Console.Clear();
                                        string yearlyAnswer = (selectedYearlyOption + 1).ToString();
                                        if (yearlyAnswer == "1") 
                                        {
                                            report.CombinedReport(listings);
                                        } 
                                        else if (yearlyAnswer == "2") 
                                        {
                                            report.MonthlyReport(listings);
                                        } 
                                        else if (yearlyAnswer == "3") 
                                        {
                                            report.YearlyReport(listings);
                                        } 
                                        else if (yearlyAnswer == "4") 
                                        {
                                            return;
                                        } 
                                        else 
                                        {
                                            ReturnInvalid();
                                        }
                                        Console.Clear();
                                        break;
                                    }
                                }
                            } 
                        }  
                    else if (answer == "4")
                    {
                        return;
                    }
                    else
                    {
                        ReturnInvalid();
                    }
                    break;
            }
        } 
    }

    static void ReturnInvalid()
    { 
        System.Console.WriteLine("Invalid input, please try another option");
        PressContinue();
    }

    static void PressContinue()
    { 
        System.Console.WriteLine("...! Press any key to continue !...");
        Console.ReadKey();
    }     
}

