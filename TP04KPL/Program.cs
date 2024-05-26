using System;

namespace DoorControlSystem
{
    // Enumeration for door triggers
    public enum Trigger
    {
        OpenDoor,
        LockDoor
    }

    // Enumeration for door status
    public enum Status
    {
        Locked,
        Unlocked
    }

    public class PostalCode
    {
        // Enumeration for regions
        public enum Region
        {
            Batununggal,
            Kujangsari,
            Mengger,
            Wates,
            Cijaura,
            Jatisari,
            Sekejati,
            Kebonwaru,
            Maleer,
            Samoja
        }

        // Array of postal codes corresponding to regions
        private static readonly string[] RegionPostalCodes = {
            "40266", "40287", "40267", "40256", "40287", "40286",
            "40286", "40286", "40272", "40274", "40273"
        };

        // Method to get the postal code for a specific region
        public static string GetPostalCode(Region region)
        {
            return RegionPostalCodes[(int)region];
        }
    }

    public class Door
    {
        // Property to hold the current status of the door
        public Status CurrentStatus { get; private set; }

        // Constructor initializes the door as locked
        public Door()
        {
            CurrentStatus = Status.Locked;
        }

        // Method to perform an action (open or lock the door)
        public void PerformAction(Trigger trigger)
        {
            switch (trigger)
            {
                case Trigger.OpenDoor:
                    CurrentStatus = Status.Unlocked;
                    break;
                case Trigger.LockDoor:
                    CurrentStatus = Status.Locked;
                    break;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Get and print the postal code for a specific region
            var region = PostalCode.Region.Sekejati;
            string postalCode = PostalCode.GetPostalCode(region);
            Console.WriteLine($"Postal code for {region}: {postalCode}");

            // Create a new Door object and lock it
            var door = new Door();
            door.PerformAction(Trigger.LockDoor);

            // Check and print the current status of the door
            if (door.CurrentStatus == Status.Unlocked)
            {
                Console.WriteLine("The door is unlocked.");
            }
            else if (door.CurrentStatus == Status.Locked)
            {
                Console.WriteLine("The door is locked.");
            }
        }
    }
}
