namespace PA5
{
    public class Listing
    {
        private int listID;
        private string trainerName;
        private DateOnly date;
        private TimeOnly time;
        private int cost;
        private string isTaken;
        private bool deleted;

        static private int count;

        public Listing(){

        }
        public Listing(int listID, string trainerName, DateOnly date, TimeOnly time, int cost, string isTaken, bool deleted){
            this.listID = listID;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.isTaken = isTaken;
            this.deleted = deleted;
        }

        public int GetListID(){
            return listID;
        }

        public void SetListID(){
            this.listID = count + 1;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public DateOnly GetDate(){
            return date;
        }
        public void SetDate(DateOnly date){
            this.date = date;
        }
        public TimeOnly GetTime(){
            return time;
        }
        public void SetTime(TimeOnly time){
            this.time = time;
        }
        public int GetCost(){
            return cost;
        }
        public void SetCost(int cost){
            this.cost = cost;
        }
        public string GetIsTaken(){
            return isTaken;
        }
        public void SetIsTaken(string isTaken){
            this.isTaken = isTaken;
        }
        static public int GetCount(){
            return Listing.count;
        }
        static public void SetCount(int count){
            Listing.count = count;
        }

        static public void IncCount(){
            Listing.count++;
        }
        public bool GetDeleted(){
            return deleted;
        }
        public void Delete(){
            deleted = true;
        }
        
        public override string ToString()
        {
            if(deleted == false){
                return String.Format($"{listID, -5} {trainerName, -20} {date, -20} {time, -20} {cost.ToString("C"), -20} {isTaken, -20}");
            }
            return "";
        }

        public string ToFile()
        {
            return $"{listID}#{trainerName}#{date}#{time}#{cost}#{isTaken}#{deleted}";
        }
    }
}