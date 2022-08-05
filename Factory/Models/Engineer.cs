using System.Collections.Generic;

namespace Factory.Models
{
	public class Engineer
	{
		public Engineer()
		{
			this.JoinEntities = new HashSet<EngineerMachine>();
		}

		public int EId {get;set;}

		public string EName {get;set;}

		public string EExperience {get;set;}

		public virtual ICollection<EngineerMachine> JoinEntities {get;set}
	}

}