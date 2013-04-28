using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

static class Messages
{
    static StringBuilder output = new StringBuilder();

    public static void EventAdded()
    {
        output.Append("Event added\n");
    }

    public static void EventDeleted(int x)
    {
        if (x == 0)
        {
            NoEventsFound();
        }
        else
        {
            output.AppendFormat("{0} events deleted\n", x);
        }
    }

    public static void NoEventsFound()
    {
        output.Append("No events found\n");
    }

    public static void PrintEvent(Event eventToPrint)
    {
        if (eventToPrint != null)
        {
            output.Append(eventToPrint + "\n");
        }
    }
}
