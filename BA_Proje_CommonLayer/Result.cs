using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Proje_CommonLayer
{
	public class Result<T>
	{
		public string ReturnMessage { get; set; }
		public bool Control { get; set; }
		public T StatusResult { get; set; }
	}
}
