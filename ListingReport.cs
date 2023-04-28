namespace PA5
{
    public class ListingReport
    {
        Listing[] listings;

        public ListingReport(Listing[] listings){
            this.listings = listings;

        }

        public void PrintAllListings(){
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetDeleted() == false){
                    System.Console.WriteLine(listings[i].ToString());
                }
            }
        }

        public void PrintOpenListing(){
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetDeleted() == false){
                    if(listings[i].GetIsTaken() == "Open"){
                        System.Console.WriteLine(listings[i].ToString());
                    }
                }
            }
        }
        public int CountOpenListings(){
            int count = 0;
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetDeleted() == false){
                    if(listings[i].GetIsTaken() == "Open"){
                        System.Console.WriteLine(listings[i].ToString());
                        count++;
                    }
                }
            }

            return count;
        }
    }
}