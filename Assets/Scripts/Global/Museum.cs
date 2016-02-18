﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Museum
{
    public static List<Floor> floors;
    // The current floor (starts at 0).
    public static int currentFloor = 0;

    public static void Load(string textFile)
    {
        // Load floors/rooms.
        List<Room> rooms1 = new List<Room>();
        rooms1.Add(new Room("ForestR1", "Extending"));
        rooms1.Add(new Room("SeaR1", "None"));
        rooms1.Add(new Room("WinterR1", "Extending"));
        List<Room> rooms2 = new List<Room>();
        rooms2.Add(new Room("ForestS1", "Extending"));
        rooms2.Add(new Room("ForestS2", "Extending"));
        rooms2.Add(new Room("SeaS1", "None"));

        floors = new List<Floor>();
        floors.Add(Floor.Empty);
        floors.Add(new Floor(rooms1));
        floors.Add(new Floor(rooms2));
        floors.Add(Floor.Empty);
    }

    public static Floor CurrentFloor
    {
        get
        {
            return floors[currentFloor];
        }
    }

    // Returns true when all rooms have been visited.
    public static bool CanContinue
    {
        get
        {
            // Can't continue on last floor.
            if (currentFloor == floors.Count - 1)
                return false;
            foreach (Room room in CurrentFloor.rooms)
            {
                if (!room.visited)
                    return false;
            }
            return true;
        }
    }

    public static void ToNextFloor()
    {
        if (currentFloor < floors.Count - 1)
            currentFloor++;
    }

    public static void ToRoom(int room)
    {
        CurrentFloor.currentRoom = room;

        // Mark room as visited.
        if (room > 0)
            CurrentFloor.rooms[room - 1].visited = true;
    }
}
