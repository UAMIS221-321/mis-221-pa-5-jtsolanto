namespace PA5
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }
        public void GetAllTrainersFromFile()
        {
            StreamReader inFile = new StreamReader("trainer.txt");
            
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], bool.Parse(temp[4]));
                Trainer.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public void AddTrainer()
        {
            Trainer myTrainer = new Trainer();
            myTrainer.SetID();
            System.Console.WriteLine("-----Add New Trainer-----");
            System.Console.WriteLine("Please enter the trainer's first and last name:");
            myTrainer.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer's mailing address:");
            myTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer's email:");
            myTrainer.SetEmail(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();

            Save();
        }
        public int Find(int searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }

        public int BinaryFindTrainer(string searchVal) 
        {
            int left = 0;
            int right = Trainer.GetCount() - 1;

            while (left <= right) 
            {
                int mid = left + (right - left) / 2;
                int cmp = searchVal.CompareTo(trainers[mid].GetName());

                if (cmp == 0) 
                {
                    return trainers[mid].GetID();
                } 
                else if (cmp < 0) 
                {
                    right = mid - 1;
                } 
                else 
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
        
        public void Sort()
        {
            for(int i = 0; i < Trainer.GetCount() - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    if(trainers[j].GetName().CompareTo(trainers[min].GetName()) < 0 || trainers[j].GetName() == trainers[min].GetName())
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
            Trainer temp = trainers[x];
            trainers[x] = trainers[y];
            trainers[y] = temp;
        }
        public void Save()
        {
            StreamWriter outFile = new StreamWriter("trainer.txt");
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }

public void UpdateTrainer()
{
    System.Console.WriteLine("-----Update Trainer-----");
    System.Console.WriteLine("Please enter the ID of the trainer you would like to update");
    int searchVal = int.Parse(Console.ReadLine());
    int foundIndex = Find(searchVal);

    if(foundIndex != -1)
    {
        string[] options = { "Name", "Mailing Address", "Email" };
        int selectedOption = 0;

        while (true)
        {
            Console.Clear();
            System.Console.WriteLine($"Updating Trainer {searchVal}");
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
                System.Console.WriteLine($"{i+1}. {options[i]}");
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
                        System.Console.WriteLine("Please enter the trainer's name: ");
                        trainers[foundIndex].SetName(Console.ReadLine());
                    }
                    else if (selectedOption == 1)
                    {
                        System.Console.WriteLine("Please enter the trainer's mailing address: ");
                        trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                    }
                    else if (selectedOption == 2)
                    {
                        System.Console.WriteLine("Please enter the trainer's email: ");
                        trainers[foundIndex].SetEmail(Console.ReadLine());
                    }
                    else
                    {
                       // SayInvalid();
                        continue;
                    }
                    Save();
                    System.Console.WriteLine("Trainer updated successfully.");
                    Console.ReadKey();
                    return;
            }
        }
    }
    else
    {
        System.Console.WriteLine("The trainer you entered was not found. Sorry!");
        Console.ReadKey();
    }
}



        public void DeleteTrainer()
        {
            System.Console.WriteLine("-----Delete Trainer-----");
            System.Console.WriteLine("What is the ID of the trainer you would like to delete?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                trainers[foundIndex].Delete();
                Save();
                System.Console.WriteLine("Trainer deleted successfully");
            }
            else
            {
                System.Console.WriteLine("The trainer you entered was not found. Sorry!");
                Console.ReadKey();
            }
        }
    }
}