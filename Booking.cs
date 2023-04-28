namespace PA5
{
    public class Booking
    {
        private int id;
        private string customerName;
        private string customerEmail;
        private DateOnly trainingDate;
        private string status;
        private int trainerID;
        private string trainerName;
        private bool deleted;

        static private int count;

        public Booking(){

        }

        public Booking(int id, string customerName, string customerEmail, DateOnly trainingDate, int trainerID, string trainerName, string status, bool deleted){
            this.id = id;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
            this.deleted = deleted;

        }

         public int GetID(){
            return id;
        }

        public void SetID(){
            this.id = count + 1;
        }

        public string GetCustomerName(){
            return customerName;
        }

        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }

        public string GetCustomerEmail(){
            return customerEmail;
        }
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        public DateOnly GetTrainingDate(){
            return trainingDate;
        }
        public void SetTrainingDate(DateOnly trainingDate){
            this.trainingDate = trainingDate;
        }
        public string GetStatus(){
            return status;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        public int GetTrainerID(){
            return trainerID;
        }
        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        static public int GetCount(){
            return Booking.count;
        }
        static public void SetCount(int count){
            Booking.count = count;
        }

        static public void IncCount(){
            Booking.count++;
        }
        public bool GetDeleted(){
            return deleted;
        }
        public void Delete(){
            deleted = true;
        }

        public override string ToString()
        {
            return String.Format($"{id, -10} {customerName, -20} {customerEmail, -20} {trainingDate, -20} {trainerID, -20} {trainerName, -20} {status, -20}");
        }

        public string ToFile()
        {
            return $"{id}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}#{deleted}";
        }

    }
}