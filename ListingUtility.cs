namespace PA5
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings)
        {
            this.listings = listings;
        }

        public void GetAllListingsFromFile()
        {
            StreamReader inFile = new StreamReader("listings.txt");
            
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], DateOnly.Parse(temp[2]), TimeOnly.Parse(temp[3]),int.Parse(temp[4]), temp[5], bool.Parse(temp[6]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void AddListing()
        {
            Listing mylistings = new Listing();
            
            mylistings.SetListID();
            System.Console.WriteLine("-----Add Listing-----");
            System.Console.WriteLine("Please enter the trainers name:");
            mylistings.SetTrainerName(Console.ReadLine());

    
            System.Console.WriteLine("Please enter the date of session:");
            string date = Console.ReadLine();
         
           
            System.Console.WriteLine("Please enter the time of session:");
            string time = Console.ReadLine();
            

            DateOnly parsedDate = DateOnly.Parse(date);
            TimeOnly parsedTime = TimeOnly.Parse(time);

            mylistings.SetDate(parsedDate);
            mylistings.SetTime(parsedTime);

            System.Console.WriteLine("Please enter the cost of session:");
            mylistings.SetCost(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Is the session open or booked?");
            mylistings.SetIsTaken(Console.ReadLine());

            listings[Listing.GetCount()] = mylistings;
            Listing.IncCount();

            Save();
        }
        public int Find(int searchVal)
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetListID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }
    
        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");
            for(int i = 0; i < Listing.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }
public void UpdateListing()
{
    Console.WriteLine("-----Update Listing-----");
    Console.WriteLine("Please enter the ID of the listing you would like to update");
    int searchVal = int.Parse(Console.ReadLine());
    int foundIndex = Find(searchVal);

    if (foundIndex != -1)
    {
        string[] options = { "Trainer Name", "Date of Session", "Time of Session", "Cost", "Availability" };
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
                Console.WriteLine((i + 1) + ". " + options[i]);
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
                            Console.WriteLine("Please enter the trainers name:");
                            listings[foundIndex].SetTrainerName(Console.ReadLine());
                            break;
                        case 1:
                            Console.WriteLine("Please enter the date of session:");
                            string date = Console.ReadLine();
                            DateOnly parsedDate = DateOnly.Parse(date);
                            listings[foundIndex].SetDate(parsedDate);
                            break;
                        case 2:
                            Console.WriteLine("Please enter the time of session (Please enter in military time (+12 if after 12:00)):");
                            string time = Console.ReadLine();
                            TimeOnly parsedTime = TimeOnly.Parse(time);
                            listings[foundIndex].SetTime(parsedTime);
                            break;
                        case 3:
                            Console.WriteLine("Please enter the cost of session:");
                            listings[foundIndex].SetCost(int.Parse(Console.ReadLine()));
                            break;
                        case 4:
                            Console.WriteLine("Is the session open or taken?");
                            listings[foundIndex].SetIsTaken(Console.ReadLine());
                            break;
                        default:
                            //SayInvalid();
                            break;
                    }
                    Save();
                    Console.WriteLine("Listing updated successfully.");
                    Console.ReadKey();
                    return;
            }
        }
    }
    else
    {
        Console.WriteLine("Listing not found.");
        Console.ReadKey();
    }
}


        public void DeleteListing()
        {
            System.Console.WriteLine("What is the ID of the listing you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                listings[foundIndex].Delete();
                Save();

            }
            else
            {
                System.Console.WriteLine("Trainer not found.");
                Console.ReadKey();

            }
        }
        public void SortDate()
        {
            for(int i = 0; i < Booking.GetCount() - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < Booking.GetCount(); j++)
                {
                    if(listings[min].GetDate().CompareTo(listings[j].GetDate()) > 0 || (listings[j].GetDate() == listings[min].GetDate()))
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
        }
        private void Swap(int x, int y)
        {
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }
        public int BinaryFindMonth(int searchVal) {
            SortDate();

            int left = 0;
            int right = Listing.GetCount() - 1;

            while (left <= right) {
                int mid = left + (right - left) / 2;
                int month = listings[mid].GetDate().Month;

                if (searchVal == month) {
                    return listings[mid].GetCost();
                } else if (searchVal < month) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }

            return -1;
        }

        public int BinaryFindYear(int searchVal) {
            SortDate();

            int left = 0;
            int right = Listing.GetCount() - 1;

            while (left <= right) {
                int mid = left + (right - left) / 2;
                int year = listings[mid].GetDate().Year;

                if (searchVal == year) {
                    return listings[mid].GetCost();
                } else if (searchVal < year) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            }

            return -1;
        }

        
    }
}