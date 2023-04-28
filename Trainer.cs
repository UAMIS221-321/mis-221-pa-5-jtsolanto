namespace PA5
{
    public class Trainer
    {
        private int id;
        
        private string name;
        private string  mailingAddress;
        private string email;
        private bool deleted;

        static private int count;

        public Trainer(){
            
        }

        public Trainer(int id, string name, string mailingAddress, string email, bool deleted)
        {
            this.id = id;
            this.name = name;
            this.mailingAddress = mailingAddress;
            this.email = email;
            this.deleted = deleted;
        }

        public int GetID()
        {
            return id;
        }
        public void SetID()
        {
            this.id = count + 1;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetMailingAddress()
        {
            return mailingAddress;
        }
        public void SetMailingAddress(string mailingAddress)
        {
            this.mailingAddress = mailingAddress;
        }
        public string GetEmail(string email)
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        static public int GetCount()
        {
            return Trainer.count;
        }
        static public void SetCount(int count)
        {
            Trainer.count = count;
        }

        static public void IncCount()
        {
            Trainer.count++;
        }
        public bool GetDeleted()
        {
            return deleted;
        }
        public void Delete()
        {
            deleted = true;
        }

        public override string ToString()
        {
            if(deleted == false){
                return String.Format($"{id, -10}  {name, -40}  {mailingAddress, -40}  {email, -40}");
            }
            return "";
        }

        public string ToFile()
        {
            return $"{id}#{name}#{mailingAddress}#{email}#{deleted}";
        }

    }
}