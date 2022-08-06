using System;
using System.Collections.Generic;

namespace Factory.Models
{
	public class Machine
	{
		public Machine()
		{
			this.JoinEntities = new HashSet<EngineerMachine>();
		}
		public int MId {get;set;}

		public string MName {get;set;}

		public virtual ICollection<EngineerMachine>JoinEntities{get;}
	}
}