namespace PageTerminal.Models
{
    public class Command
    {
        public Command(int selectCommand, int parametr1, int parametr2, int parametr3)
        {
            command_id = selectCommand;
            this.parameter1 = parametr1;
            this.parameter2 = parametr2;
            this.parameter3 = parametr3;
        }
        public int command_id { get; set; }
        public int parameter1 { get; set; }
        public int parameter2 { get; set; }
        public int parameter3 { get; set; }
        public int parameter4 { get; set; }
        public string str_parameter1 { get; set; }
        public string str_parameter2 { get; set; }
    }
}
