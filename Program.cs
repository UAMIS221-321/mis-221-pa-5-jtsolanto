using PA5;
internal class Program
{
    private static void Main(string[] args)
    {
        // start //
        Trainer[] trainers = new Trainer[400];
        Listing[] listings = new Listing[400];
        Booking[] bookings = new Booking[400];

        while (true)
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
                                ManageTrainer(trainers);
                                break;
                            case 1:
                                ManageListing(listings);
                                break;
                            case 2:
                                ManageCustomer(trainers, listings, bookings);
                                break;
                            case 3:
                                RunReports(trainers, listings, bookings);
                                break;
                            case 4:
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Black;
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }
            }
        }
    }
    static void ManageTrainer(Trainer[] trainers)
    {
        Console.Clear();

        TrainerUtility utility = new TrainerUtility(trainers);
        utility.GetAllTrainersFromFile();

        TrainerReport report = new TrainerReport(trainers);
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
                                utility.AddTrainer();
                                break;
                            case 1:
                                utility.UpdateTrainer();
                                break;
                            case 2:
                                utility.DeleteTrainer();
                                break;
                            case 3:
                                return;
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
                                utility.AddListing();
                                break;
                            case 1:
                                utility.UpdateListing();
                                break;
                            case 2:
                                utility.DeleteListing();
                                break;
                            case 3:
                                return;
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
                                        SayInvalid();
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
                        SayInvalid();
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
                                            SayInvalid();
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
                        SayInvalid();
                    }
                    break;
            }
        } 
    }

    static void SayInvalid()
    { // states invalid if choice enetered is able to run
        System.Console.WriteLine("Invalid");
        PauseAction();
    }

    static void PauseAction()
    { // pauses the console for the user to be able to see what the computer outputs
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }     
}

