namespace PageTerminal.Models
{
    public class HistoryCommands
    {
        public int page_number { get; set; }
        public int items_per_page { get; set; }
        public int items_count { get; set; }
        public SentCommand[] items { get; set; }
        public bool success { get; set; }
    }

    public class SentCommand
    {
        public int terminal_id { get; set; }
        public int command_id { get; set; }
        public int parameter1 { get; set; }
        public int parameter2 { get; set; }
        public int parameter3 { get; set; }
        public int parameter4 { get; set; }
        public string str_parameter1 { get; set; }
        public string str_parameter2 { get; set; }
        public int state { get; set; }
        public string state_name { get; set; }
        public string time_created { get; set; }
        public object time_delivered { get; set; }
        public int id { get; set; }
    }
}