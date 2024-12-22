Random rnd = new Random();

//default 60 seconds
int Seconds = 60;
//default false
bool Debug = false;
void displayHelp(string err) {
    if(!string.IsNullOrEmpty(err)) {
        Console.WriteLine($"ERROR: {err}");
    }
    Console.WriteLine("Usage - .\\klicky.exe [--seconds/-S (num)] [--debug/-D]");
}
void parseArgs() {
    for(int i = 0; i < args.Count(); i++) {
        switch(args[i]) {
            case "-D":
            case "--debug" :
                Debug = true;
                break;
            case "-S":
            case "--seconds":
                if(int.TryParse(args[i+1], out int _)) {
                    Seconds = Convert.ToInt32(args[i+1]);
                } else {
                    displayHelp("expected number for --seconds");
                }
                if(Debug) { Console.WriteLine($"DEBUG: Seconds set to {args[i+1]} via argument");}
                break;
        }
    }
}

parseArgs();
Console.WriteLine($"+ Starting Klicky at {Seconds} second interval");
while (true) {
    var interval = rnd.Next(Seconds)*1000;
    if(Debug) { Console.WriteLine($"DEBUG: Sleeping for {interval/1000} seconds ({interval} milliseconds)"); }
    
    Thread.Sleep(rnd.Next(interval));

    Mouse.SimulateMouseClick();
    if(Debug) { Console.WriteLine("DEBUG: Mouse Clicked"); }
    
}