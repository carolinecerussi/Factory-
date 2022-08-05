namespace Factory.Models
{
	public class EngineerMachine
	{
		public int EngineerMachineId {get;set;}

		public int MId {get;set;}

		public int EId {get;set;}

		public virtual Machine Machine {get;set;}

		public virtual Engineer Engineer {get;set;}
	}
}