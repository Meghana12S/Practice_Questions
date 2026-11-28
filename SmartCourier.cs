using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class Parcel
    {
        public int ParcelId { get; set; }
        public string ReceiverName { get; set; }
        public string Destination { get; set; }
        public int WeightKg { get; set; }
        public int RatePerKg { get; set; }

    }
    public class SmartCourier
    {
        public static List<Parcel> ParcelList = new List<Parcel>();
        public void AddParcel(int id, string receiver, string destination , int weight, int rate)
        {
            Parcel parcel = new Parcel();
            parcel.ParcelId = id;
            parcel.ReceiverName = receiver;
            parcel.Destination = destination;
            parcel.WeightKg = weight;
            parcel.RatePerKg = rate;
            ParcelList.Add(parcel);

        }
        public List<Parcel> GetParcelByDestination(string destination)
        {
            List<Parcel> result = new List<Parcel>();
            foreach(Parcel parcel in ParcelList)
            {
                result.Add(parcel);
            }
            return result;
        }
        public string CalculateShippingCharge(int id, string deliveryType)
        {
            bool found = false;
            foreach(Parcel parcel in ParcelList)
            {
                if(parcel.ParcelId == id)
                {
                    found = true;
                    break;
                }
            }
            if(found == null)
            {
                return "Parcel not found";
            }
            string type = deliveryType == null ? "" : deliveryType.ToLower();
            string label;
            double surCharge;
            if(type == "Standard")
            {
                label = "Standard Delivery";
                surCharge = 0;
            }
            else if(type == "Express")
            {
                label = "Express Delivery";
                surCharge = 25;
            }
            else if(type == "Overnight")
            {
                label = "Overnight Delivery";
                surCharge = 60;
            }
            else
            {
                return "Invalid delivery type";
            }
            double baseCharge = (double)found.WeightKg * found.RatePerKg;
            double total = baseCharge + (baseCharge * surCharge / 100);
            if(found.WeightKg > 20)
            {
                total += 100;
            }
            return "Shipping"  + label + ", Receiver:" + found.ReceiverName 
        }
    }
}
